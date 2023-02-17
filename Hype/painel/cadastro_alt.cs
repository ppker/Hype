﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hype.script;

namespace Hype.painel
{
    public partial class cadastro_alt : UserControl
    {
        public cadastro_alt()
        {
            InitializeComponent();

            lb_data_entrada.Text = DateTime.Now.ToShortDateString();
            txt_quantidade_alt.SelectedIndex = 0;

            txt_nick.Enabled = false;
            txt_nick.BackColor = Color.FromArgb(235, 235, 235);
        }

        private void Cadastro()
        {
            switch (txt_quantidade_alt.SelectedIndex)
            {
                case 1:
                    NovaAlt_01();
                    break;
                case 2:
                    NovaAlt_02();
                    break;
                case 3:
                    NovaAlt_03();
                    break;
                case 4:
                    NovaAlt_04();
                    break;
                case 5:
                    NovaAlt_05();
                    break;

                default:
                    break;
            }
        }

        private void txt_quantidade_alt_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // HABILITA O CADASTRO PARA CADA QUANTIDADE
            switch (txt_quantidade_alt.SelectedIndex)
            {
                case 0:
                    PainelAlt_00();
                    break;
                case 1:
                    PainelAlt_01();
                    break;
                case 2:
                    PainelAlt_02();
                    break;
                case 3:
                    PainelAlt_03();
                    break;
                case 4:
                    PainelAlt_04();
                    break;
                case 5:
                    PainelAlt_05();
                    break;
                default:
                    break;
            }
        }

        #region BOTOOES
        private void bt_voltar_Click(object sender, EventArgs e)
        {
            alts uc = new alts();
            cla.Instance.addControl(uc);
        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                Alertas();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Código" + erro + "de Erro Interno ", "ERRO FATAL");
            }
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            LimparCadastro();
        }

        private void Alertas()
        {

            if (txt_quantidade_alt.SelectedIndex == 0)
            {
                txt_quantidade_alt.BorderColor = Color.Red;
                txt_quantidade_alt.BorderSize = 1;
            }

            if (txt_quantidade_alt.SelectedIndex == 1)
            {
                // ALT 01
                if (String.IsNullOrEmpty(txt_nick_alt_01.Texts))
                {
                    txt_nick_alt_01.BorderColor = Color.Red;
                    txt_nick_alt_01.BorderSize = 1;
                }
                else if (String.IsNullOrEmpty(txt_level_alt_01.Texts))
                {
                    txt_level_alt_01.BorderColor = Color.Red;
                    txt_level_alt_01.BorderSize = 1;
                }
                else if (txt_classe_alt_01.SelectedIndex == 0)
                {
                    txt_classe_alt_01.BorderColor = Color.Red;
                    txt_classe_alt_01.BorderSize = 1;
                }
                else if (String.IsNullOrEmpty(txt_foi_alt_01.Texts))
                {
                    txt_foi_alt_01.BorderColor = Color.Red;
                    txt_foi_alt_01.BorderSize = 1;
                }
                else
                {
                    try
                    {
                        Cadastro();
                        DialogResult dr = MessageBox.Show("Salvo Com Sucesso !", "Membros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        LimparCadastro();
                    }
                }
            }

            if (txt_quantidade_alt.SelectedIndex == 2)
            {
                // ALT 02
                if (String.IsNullOrEmpty(txt_nick_alt_02.Texts))
                {
                    txt_nick_alt_02.BorderColor = Color.Red;
                    txt_nick_alt_02.BorderSize = 1;
                }
                else if (String.IsNullOrEmpty(txt_level_alt_02.Texts))
                {
                    txt_level_alt_02.BorderColor = Color.Red;
                    txt_level_alt_02.BorderSize = 1;
                }
                else if (txt_classe_alt_02.SelectedIndex == 0)
                {
                    txt_classe_alt_02.BorderColor = Color.Red;
                    txt_classe_alt_02.BorderSize = 1;
                }
                else if (String.IsNullOrEmpty(txt_foi_alt_02.Texts))
                {
                    txt_foi_alt_02.BorderColor = Color.Red;
                    txt_foi_alt_02.BorderSize = 1;
                }
                else
                {
                    try
                    {
                        Cadastro();
                        DialogResult dr = MessageBox.Show("Salvo Com Sucesso !", "Membros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        LimparCadastro();
                    }
                }
            }

            if (txt_quantidade_alt.SelectedIndex == 3)
            {
                // ALT 03
                if (String.IsNullOrEmpty(txt_nick_alt_03.Texts))
                {
                    txt_nick_alt_03.BorderColor = Color.Red;
                    txt_nick_alt_03.BorderSize = 1;
                }
                else if (String.IsNullOrEmpty(txt_level_alt_03.Texts))
                {
                    txt_level_alt_03.BorderColor = Color.Red;
                    txt_level_alt_03.BorderSize = 1;
                }
                else if (txt_classe_alt_03.SelectedIndex == 0)
                {
                    txt_classe_alt_03.BorderColor = Color.Red;
                    txt_classe_alt_03.BorderSize = 1;
                }
                else if (String.IsNullOrEmpty(txt_foi_alt_03.Texts))
                {
                    txt_foi_alt_03.BorderColor = Color.Red;
                    txt_foi_alt_03.BorderSize = 1;
                }
                else
                {
                    try
                    {
                        Cadastro();
                        DialogResult dr = MessageBox.Show("Salvo Com Sucesso !", "Membros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        LimparCadastro();
                    }
                }
            }

            if (txt_quantidade_alt.SelectedIndex == 4)
            {

                // ALT 04
                if (String.IsNullOrEmpty(txt_nick_alt_04.Texts))
                {
                    txt_nick_alt_04.BorderColor = Color.Red;
                    txt_nick_alt_04.BorderSize = 1;
                }
                else if (String.IsNullOrEmpty(txt_level_alt_04.Texts))
                {
                    txt_level_alt_04.BorderColor = Color.Red;
                    txt_level_alt_04.BorderSize = 1;
                }
                else if (txt_classe_alt_04.SelectedIndex == 0)
                {
                    txt_classe_alt_04.BorderColor = Color.Red;
                    txt_classe_alt_04.BorderSize = 1;
                }
                else if (String.IsNullOrEmpty(txt_foi_alt_04.Texts))
                {
                    txt_foi_alt_04.BorderColor = Color.Red;
                    txt_foi_alt_04.BorderSize = 1;
                }
                else
                {
                    try
                    {
                        Cadastro();
                        DialogResult dr = MessageBox.Show("Salvo Com Sucesso !", "Membros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        LimparCadastro();
                    }
                }
            }

            if (txt_quantidade_alt.SelectedIndex == 5)
            {
                // ALT 05
                if (String.IsNullOrEmpty(txt_nick_alt_05.Texts))
                {
                    txt_nick_alt_05.BorderColor = Color.Red;
                    txt_nick_alt_05.BorderSize = 1;
                }
                else if (String.IsNullOrEmpty(txt_level_alt_05.Texts))
                {
                    txt_level_alt_05.BorderColor = Color.Red;
                    txt_level_alt_05.BorderSize = 1;
                }
                else if (txt_classe_alt_05.SelectedIndex == 0)
                {
                    txt_classe_alt_05.BorderColor = Color.Red;
                    txt_classe_alt_05.BorderSize = 1;
                }
                else if (String.IsNullOrEmpty(txt_foi_alt_05.Texts))
                {
                    txt_foi_alt_05.BorderColor = Color.Red;
                    txt_foi_alt_05.BorderSize = 1;
                }
                else
                {
                    try
                    {
                        Cadastro();
                        DialogResult dr = MessageBox.Show("Salvo Com Sucesso !", "Membros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        LimparCadastro();
                    }
                }
            }
        }

        private void CampoTextoAltDesativado(Control.ControlCollection control)
        {
            foreach (Control c in control)
            {
                if (c is RJTextBox)
                {
                    ((RJTextBox)c).Enabled = false;
                    ((RJTextBox)c).BackColor = Color.FromArgb(32, 34, 37);
                    ((RJTextBox)c).PlaceholderText = "";
                }

                if (c is RJComboBox)
                {
                    ((RJComboBox)c).Enabled = false;
                    ((RJComboBox)c).BackColor = Color.FromArgb(32, 34, 37);
                    ((RJComboBox)c).SelectedIndex = -1;

                }
            }
        }

        private void CampoTextoAltHabilitado(Control.ControlCollection control)
        {
            foreach (Control c in control)
            {
                if (c is RJTextBox)
                {
                    ((RJTextBox)c).Enabled = true;
                    ((RJTextBox)c).BackColor = Color.White;
                }

                if (c is RJComboBox)
                {
                    ((RJComboBox)c).Enabled = true;
                    ((RJComboBox)c).BackColor = Color.White;
                    ((RJComboBox)c).SelectedIndex = 0;
                }
            }
        }

        private void txt_quantidade_alt_Leave(object sender, EventArgs e)
        {
            txt_quantidade_alt.BorderColor = Color.Transparent;
            txt_quantidade_alt.BorderSize = 0;
        }

        private void txt_nick_alt_01_Leave(object sender, EventArgs e)
        {
            txt_nick_alt_01.BorderColor = Color.Transparent;
            txt_nick_alt_01.BorderSize = 0;
        }

        private void txt_level_alt_01_Leave(object sender, EventArgs e)
        {
            txt_nick_alt_01.BorderColor = Color.Transparent;
            txt_nick_alt_01.BorderSize = 0;
        }

        private void txt_classe_alt_01_Leave(object sender, EventArgs e)
        {
            txt_nick_alt_01.BorderColor = Color.Transparent;
            txt_nick_alt_01.BorderSize = 0;
        }

        private void txt_foi_alt_01_Leave(object sender, EventArgs e)
        {
            txt_foi_alt_01.BorderColor = Color.Transparent;
            txt_foi_alt_01.BorderSize = 0;
        }

        private void txt_nick_alt_02_Leave(object sender, EventArgs e)
        {
            txt_nick_alt_02.BorderColor = Color.Transparent;
            txt_nick_alt_02.BorderSize = 0;
        }

        private void txt_level_alt_02_Leave(object sender, EventArgs e)
        {
            txt_level_alt_02.BorderColor = Color.Transparent;
            txt_level_alt_02.BorderSize = 0;
        }

        private void txt_classe_alt_02_Leave(object sender, EventArgs e)
        {
            txt_classe_alt_02.BorderColor = Color.Transparent;
            txt_classe_alt_02.BorderSize = 0;
        }

        private void txt_foi_alt_02_Leave(object sender, EventArgs e)
        {
            txt_foi_alt_02.BorderColor = Color.Transparent;
            txt_foi_alt_02.BorderSize = 0;
        }

        private void txt_nick_alt_03_Leave(object sender, EventArgs e)
        {
            txt_nick_alt_03.BorderColor = Color.Transparent;
            txt_nick_alt_03.BorderSize = 0;
        }

        private void txt_level_alt_03_Leave(object sender, EventArgs e)
        {
            txt_level_alt_03.BorderColor = Color.Transparent;
            txt_level_alt_03.BorderSize = 0;
        }

        private void txt_classe_alt_03_Leave(object sender, EventArgs e)
        {
            txt_classe_alt_03.BorderColor = Color.Transparent;
            txt_classe_alt_03.BorderSize = 0;
        }

        private void txt_foi_alt_03_Leave(object sender, EventArgs e)
        {
            txt_foi_alt_02.BorderColor = Color.Transparent;
            txt_foi_alt_02.BorderSize = 0;
        }

        private void txt_nick_alt_04_Leave(object sender, EventArgs e)
        {
            txt_foi_alt_04.BorderColor = Color.Transparent;
            txt_foi_alt_04.BorderSize = 0;
        }

        private void txt_level_alt_04_Leave(object sender, EventArgs e)
        {
            txt_foi_alt_04.BorderColor = Color.Transparent;
            txt_foi_alt_04.BorderSize = 0;
        }

        private void txt_classe_alt_04_Leave(object sender, EventArgs e)
        {
            txt_foi_alt_04.BorderColor = Color.Transparent;
            txt_foi_alt_04.BorderSize = 0;
        }

        private void txt_foi_alt_04_Leave(object sender, EventArgs e)
        {
            txt_foi_alt_04.BorderColor = Color.Transparent;
            txt_foi_alt_04.BorderSize = 0;
        }

        private void txt_nick_alt_05_Leave(object sender, EventArgs e)
        {
            txt_foi_alt_05.BorderColor = Color.Transparent;
            txt_foi_alt_05.BorderSize = 0;
        }

        private void txt_level_alt_05_Leave(object sender, EventArgs e)
        {
            txt_foi_alt_05.BorderColor = Color.Transparent;
            txt_foi_alt_05.BorderSize = 0;
        }

        private void txt_classe_alt_05_Leave(object sender, EventArgs e)
        {
            txt_foi_alt_05.BorderColor = Color.Transparent;
            txt_foi_alt_05.BorderSize = 0;
        }

        private void txt_foi_alt_05_Leave(object sender, EventArgs e)
        {
            txt_foi_alt_05.BorderColor = Color.Transparent;
            txt_foi_alt_05.BorderSize = 0;
        }
        #endregion

        #region CADASTRO ALT
        private void NovaAlt_01()
        {
            configdb database = new configdb();
            database.openConnection();

            // INSERT TABELA CADASTRO ALT 01
            MySqlCommand objCmdCadastroAlt = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt.ExecuteNonQuery();

            database.closeConnection();
        }

        private void NovaAlt_02()
        {
            configdb database = new configdb();
            database.openConnection();

            // INSERT TABELA CADASTRO ALT 01
            MySqlCommand objCmdCadastroAlt = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt.ExecuteNonQuery();

            // INSERT TABELA CADASTRO ALT 02
            MySqlCommand objCmdCadastroAlt2 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt2.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt2.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt2.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt2.ExecuteNonQuery();

            database.closeConnection();
        }

        private void NovaAlt_03()
        {
            configdb database = new configdb();
            database.openConnection();

            // INSERT TABELA CADASTRO ALT 01
            MySqlCommand objCmdCadastroAlt = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt.ExecuteNonQuery();

            // INSERT TABELA CADASTRO ALT 02
            MySqlCommand objCmdCadastroAlt2 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt2.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt2.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt2.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt2.ExecuteNonQuery();

            // INSERT TABELA CADASTRO ALT 03
            MySqlCommand objCmdCadastroAlt3 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt3.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt3.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt3.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt3.ExecuteNonQuery();

            database.closeConnection();
        }

        private void NovaAlt_04()
        {
            configdb database = new configdb();
            database.openConnection();

            // INSERT TABELA CADASTRO ALT 01
            MySqlCommand objCmdCadastroAlt = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt.ExecuteNonQuery();

            // INSERT TABELA CADASTRO ALT 02
            MySqlCommand objCmdCadastroAlt2 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt2.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt2.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt2.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt2.ExecuteNonQuery();

            // INSERT TABELA CADASTRO ALT 03
            MySqlCommand objCmdCadastroAlt3 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt3.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt3.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt3.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt3.ExecuteNonQuery();

            // INSERT TABELA CADASTRO ALT 04
            MySqlCommand objCmdCadastroAlt4 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt4.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt4.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_04.Texts;
            objCmdCadastroAlt4.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_04.Texts;
            objCmdCadastroAlt4.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_04.Texts;
            objCmdCadastroAlt4.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_04.Texts;
            objCmdCadastroAlt4.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt4.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt4.ExecuteNonQuery();

            database.closeConnection();
        }
        
        private void NovaAlt_05()
        {
            configdb database = new configdb();
            database.openConnection();

            // INSERT TABELA CADASTRO ALT 01
            MySqlCommand objCmdCadastroAlt = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_01.Texts;
            objCmdCadastroAlt.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt.ExecuteNonQuery();

            // INSERT TABELA CADASTRO ALT 02
            MySqlCommand objCmdCadastroAlt2 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt2.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt2.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_02.Texts;
            objCmdCadastroAlt2.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt2.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt2.ExecuteNonQuery();

            // INSERT TABELA CADASTRO ALT 03
            MySqlCommand objCmdCadastroAlt3 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt3.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt3.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_03.Texts;
            objCmdCadastroAlt3.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt3.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt3.ExecuteNonQuery();

            // INSERT TABELA CADASTRO ALT 04
            MySqlCommand objCmdCadastroAlt4 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt4.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt4.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_04.Texts;
            objCmdCadastroAlt4.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_04.Texts;
            objCmdCadastroAlt4.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_04.Texts;
            objCmdCadastroAlt4.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_04.Texts;
            objCmdCadastroAlt4.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt4.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt4.ExecuteNonQuery();

            // INSERT TABELA CADASTRO ALT 05
            MySqlCommand objCmdCadastroAlt5 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_alt, level_alt, classe_alt, cla_alt, nick_principal, quantas_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroAlt5.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdCadastroAlt5.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_05.Texts;
            objCmdCadastroAlt5.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_05.Texts;
            objCmdCadastroAlt5.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_05.Texts;
            objCmdCadastroAlt5.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_05.Texts;
            objCmdCadastroAlt5.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroAlt5.Parameters.Add("@quantas_alt", MySqlDbType.Int32).Value = txt_quantidade_alt.Texts;

            objCmdCadastroAlt5.ExecuteNonQuery();

            database.closeConnection();
        }
        #endregion

        #region LIMPAR CADASTRO
        private void LimparCadastro()
        {
            txt_quantidade_alt.Enabled = false;
            txt_quantidade_alt.SelectedIndex = 0;


            LimparTextoAlt(pl_conta_alt_01.Controls);
            LimparTextoAlt(pl_conta_alt_02.Controls);
            LimparTextoAlt(pl_conta_alt_03.Controls);
            LimparTextoAlt(pl_conta_alt_04.Controls);
            LimparTextoAlt(pl_conta_alt_05.Controls);

            CampoTextoAltDesativado(this.pl_conta_alt_01.Controls);
        }

        private void LimparTextoAlt(Control.ControlCollection control)
        {
            foreach (Control c in control)
            {
                if (c is RJTextBox)
                {
                    ((RJTextBox)(c)).Texts = string.Empty;
                }

                if (c is RJComboBox)
                {
                    ((RJComboBox)(c)).SelectedIndex = -1;
                }
            }
        }
        #endregion

        #region PAINEIS DOS CADASTROS
        private void PainelAlt_00()
        {
            PainelContaALT();
        }

        private void PainelContaALT()
        {
            CampoTextoAltDesativado(this.pl_conta_alt_01.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_02.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_03.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_04.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_05.Controls);
        }

        private void PainelAlt_01()
        {
            txt_nick_alt_01.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_01.PlaceholderText = "Level";
            txt_foi_alt_01.PlaceholderText = "Foi para o clã";

            CampoTextoAltHabilitado(this.pl_conta_alt_01.Controls);

            CampoTextoAltDesativado(this.pl_conta_alt_02.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_03.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_04.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_05.Controls);
        }

        private void PainelAlt_02()
        {
            txt_nick_alt_01.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_01.PlaceholderText = "Level";
            txt_foi_alt_01.PlaceholderText = "Foi para o clã";

            txt_nick_alt_02.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_02.PlaceholderText = "Level";
            txt_foi_alt_02.PlaceholderText = "Foi para o clã";

            CampoTextoAltHabilitado(this.pl_conta_alt_01.Controls);
            CampoTextoAltHabilitado(this.pl_conta_alt_02.Controls);

            CampoTextoAltDesativado(this.pl_conta_alt_03.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_04.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_05.Controls);
        }

        private void PainelAlt_03()
        {
            txt_nick_alt_01.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_01.PlaceholderText = "Level";
            txt_foi_alt_01.PlaceholderText = "Foi para o clã";

            txt_nick_alt_02.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_02.PlaceholderText = "Level";
            txt_foi_alt_02.PlaceholderText = "Foi para o clã";

            txt_nick_alt_03.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_03.PlaceholderText = "Level";
            txt_foi_alt_03.PlaceholderText = "Foi para o clã";

            CampoTextoAltHabilitado(this.pl_conta_alt_01.Controls);
            CampoTextoAltHabilitado(this.pl_conta_alt_02.Controls);
            CampoTextoAltHabilitado(this.pl_conta_alt_03.Controls);

            CampoTextoAltDesativado(this.pl_conta_alt_04.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_05.Controls);

        }

        private void PainelAlt_04()
        {
            txt_nick_alt_01.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_01.PlaceholderText = "Level";
            txt_foi_alt_01.PlaceholderText = "Foi para o clã";

            txt_nick_alt_02.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_02.PlaceholderText = "Level";
            txt_foi_alt_02.PlaceholderText = "Foi para o clã";

            txt_nick_alt_03.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_03.PlaceholderText = "Level";
            txt_foi_alt_03.PlaceholderText = "Foi para o clã";

            txt_nick_alt_04.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_04.PlaceholderText = "Level";
            txt_foi_alt_04.PlaceholderText = "Foi para o clã";

            CampoTextoAltHabilitado(this.pl_conta_alt_01.Controls);
            CampoTextoAltHabilitado(this.pl_conta_alt_02.Controls);
            CampoTextoAltHabilitado(this.pl_conta_alt_03.Controls);
            CampoTextoAltHabilitado(this.pl_conta_alt_04.Controls);

            CampoTextoAltDesativado(this.pl_conta_alt_05.Controls);
        }

        private void PainelAlt_05()
        {
            txt_nick_alt_01.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_01.PlaceholderText = "Level";
            txt_foi_alt_01.PlaceholderText = "Foi para o clã";

            txt_nick_alt_02.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_02.PlaceholderText = "Level";
            txt_foi_alt_02.PlaceholderText = "Foi para o clã";

            txt_nick_alt_03.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_03.PlaceholderText = "Level";
            txt_foi_alt_03.PlaceholderText = "Foi para o clã";

            txt_nick_alt_04.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_04.PlaceholderText = "Level";
            txt_foi_alt_04.PlaceholderText = "Foi para o clã";

            txt_nick_alt_05.PlaceholderText = "Qual é o Nick ?";
            txt_level_alt_05.PlaceholderText = "Level";
            txt_foi_alt_05.PlaceholderText = "Foi para o clã";

            CampoTextoAltHabilitado(this.pl_conta_alt_01.Controls);
            CampoTextoAltHabilitado(this.pl_conta_alt_02.Controls);
            CampoTextoAltHabilitado(this.pl_conta_alt_03.Controls);
            CampoTextoAltHabilitado(this.pl_conta_alt_04.Controls);
            CampoTextoAltHabilitado(this.pl_conta_alt_05.Controls);
        }


        #endregion

        private void txt_buscar__TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_buscar.Texts))
            {
                Buscar();
            }
        }

        private void Buscar()
        {
            configdb database = new configdb();
            database.openConnection();

            MySqlCommand cmd = new MySqlCommand("select ID_MEMBROS, NICK from hypedb.cadastro_membro where NICK like @nick '%' ", database.getConnection());
            cmd.Parameters.AddWithValue("@nick", txt_buscar.Texts);


            database.closeConnection();
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
