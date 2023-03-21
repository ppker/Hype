﻿using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using Hype.script;
using MySql.Data.MySqlClient;
using Hype.Painel;

namespace Hype
{
    public partial class login : Form
    {
        public static login Instance;

        public bool _novoCad = false;

        public login()
        {
            InitializeComponent();

            Instance = this;
        }

        private void Alertas()
        {
            // LOGIN
            if (String.IsNullOrEmpty(txt_login.Texts))
            {
                txt_login.BorderColor = Color.Red;
                txt_login.BorderSize = 3;
            }
            else if (String.IsNullOrEmpty(txt_senha.Texts))
            {
                txt_senha.BorderColor = Color.Red;
                txt_senha.BorderSize = 3;
            }
            else
            {
                Entrar();
            }
        }

        #region BOTÕES
        private void bt_entrar_Click(object sender, EventArgs e)
        {
            Alertas();
        }

        private void Entrar()
        {
            try
            {
                // BANCO DE DADOS
                configdb database = new configdb();
                database.openConnection();

                // INSERT TABELA CADASTRO MEMBROS
                MySqlCommand objCmdLogin = new MySqlCommand("select usuario, senha from hypedb.login where usuario=@usuario and senha=@senha ", database.getConnection());

                objCmdLogin.Parameters.AddWithValue("@usuario",txt_login.Texts);
                objCmdLogin.Parameters.AddWithValue("@senha", txt_senha.Texts);
                
                var login = objCmdLogin.ExecuteScalar();

                if(login != null)
                {
                    this.Hide();
                    new cla().Show();                    
                }
                else
                {
                    MessageBox.Show("Usuario ou Senha Não Econtrado !", "LOGIN FALHOU !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                

                database.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO INTERNO: " + ex, "ERRO INTERNO !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                LimparCampo(pl_login.Controls);
            }
        }

        // NOVO CADASTRO
        private void lb_novo_cad_Click(object sender, EventArgs e)
        {
            _novoCad = true;

            this.Hide();
            new cla().ShowDialog();
            this.Close();

            MessageBox.Show(_novoCad.ToString());
        }

        private void lb_novo_cad_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lb_novo_cad_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        // FECHAR JANELA
        private void bt_fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Campo Texto
        private void txt_login_Enter(object sender, EventArgs e)
        {
            txt_login.BorderSize = 1;
        }

        private void txt_login_Leave(object sender, EventArgs e)
        {
            txt_login.BorderColor = Color.Transparent;
            txt_login.BorderSize = 0;
        }

        private void txt_senha_Enter(object sender, EventArgs e)
        {
            txt_senha.BorderSize = 1;
        }

        private void txt_senha_Leave(object sender, EventArgs e)
        {
            txt_senha.BorderColor = Color.Transparent;
            txt_senha.BorderSize = 0;
        }
        #endregion

        #region Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pl_top_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void LimparCampo(Control.ControlCollection control)
        {
            foreach (Control c in control)
            {
                if (c is RJTextBox)
                {
                    ((RJTextBox)(c)).Texts = string.Empty;
                }
            }
        }
    }
}
