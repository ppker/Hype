﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Hype.script;
using MySql.Data.MySqlClient;

namespace Hype.Painel.Cadastro
{
    public partial class cadastro_login : UserControl
    {
        public static cadastro_login Instance;

        // ID`S
        public string id_loginCad;

        public cadastro_login()
        {
            InitializeComponent();

            Instance = this;
        }

        private void Alertas()
        {
            // CADASTRO LOGIN
            if (String.IsNullOrEmpty(txt_login.Texts))
            {
                txt_login.BorderColor = Color.Red;
                txt_login.BorderSize = 3;
            }
            else if (String.IsNullOrEmpty(txt_email.Texts))
            {
                txt_email.BorderColor = Color.Red;
                txt_email.BorderSize = 3;
            }
            else if (txt_email.Texts != txt_email_conf.Texts)
            {
                txt_email_conf.BorderColor = Color.Red;
                txt_email_conf.BorderSize = 3;
            }
            else if (String.IsNullOrEmpty(txt_senha.Texts))
            {
                txt_senha.BorderColor = Color.Red;
                txt_senha.BorderSize = 3;
            }
            else if (txt_senha.Texts != txt_senha_conf.Texts)
            {
                txt_senha_conf.BorderColor = Color.Red;
                txt_senha_conf.BorderSize = 3;
            }
            else
            {
                Salvar();
            }
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tem Certeza Que Deseja Sair ?", "CANCELAR", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            switch (dr)
            {
                case DialogResult.Yes:
                    cla.Instance.Close();
                    break;
                case DialogResult.No:

                    break;
                default:
                    break;
            }
        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            Alertas();
        }

        private void Salvar()
        {
            try
            {
                configdb database = new configdb();
                database.openConnection();

                // INSERT TABELA CADASTRO MEMBROS
                MySqlCommand objCmdLogin = new MySqlCommand("insert into hypedb.login (id_login, usuario, email, senha) values (null, ?, ?, ?)", database.getConnection());

                objCmdLogin.Parameters.Add("@usuario", MySqlDbType.VarChar, 256).Value = txt_login.Texts;
                objCmdLogin.Parameters.Add("@email", MySqlDbType.VarChar, 256).Value = txt_email.Texts;
                objCmdLogin.Parameters.Add("@senha", MySqlDbType.VarChar, 256).Value = txt_senha.Texts;

                objCmdLogin.ExecuteNonQuery();              

                MessageBox.Show("Novo Login Criado Com Sucesso !", "NOVO LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                database.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO INTERNO: " + ex, "ERRO INTERNO !", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            finally
            {
                // DEPOIS DO CADASTRO FECHAR A JANELA, PARA FAZER O LOGIN 
                cla.Instance.Close();
            }
        }
    }
}
