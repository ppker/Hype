﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hype.Properties;
using Hype.script;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hype.painel
{

    public partial class add_membros : UserControl
    {
        public static add_membros Instance;

        long idPerguntaAlt;
        string pergunta_expedicao = string.Empty;
        decimal novo_poder = 0;
        int novo_level = 0;

        public add_membros()
        {
            InitializeComponent();
            Instance = this;

            txt_quantidade_alt.SelectedIndex = 0;
        }

        private void AddMembros()
        {
            switch (txt_quantidade_alt.SelectedIndex)
            {
                case 0:
                    CadastroMembro();
                    break;
                case 1:
                    CadastroAlt_01();
                    break;
                case 2:
                    CadastroAlt_02();
                    break;
                case 3:
                    CadastroAlt_03();
                    break;
                case 4:
                    CadastroAlt_04();
                    break;
                case 5:
                    CadastroAlt_05();
                    break;
                default:
                    break;
            }
        }

        private void CadastroMembro()
        {
            configdb database = new configdb();
            database.openConnection();

            // INSERT TABELA PEGUNTA ALT
            MySqlCommand objCmdPerguntaAlt = new MySqlCommand("insert into hypedb.pergunta_alt (id_pergunta_alt, pergunta_alt) values (null, ?)", database.getConnection());

            objCmdPerguntaAlt.Parameters.Add("@pergunta_alt", MySqlDbType.VarChar, 5).Value = txt_quantidade_alt.Text;

            objCmdPerguntaAlt.ExecuteNonQuery();
            idPerguntaAlt = objCmdPerguntaAlt.LastInsertedId;

            // INSERT TABELA RECRUTAMENTO
            MySqlCommand objCmdRecrutamento = new MySqlCommand("insert into hypedb.recrutamento (id_recrutamento, data_entrada, vem_do_cla, foi_para_cla) values (null, ?, ?, ?)", database.getConnection());

            objCmdRecrutamento.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdRecrutamento.Parameters.Add("@vem_do_cla", MySqlDbType.VarChar, 256).Value = txt_vem.Texts;
            objCmdRecrutamento.Parameters.Add("@foi_para_cla", MySqlDbType.VarChar, 256).Value = txt_foi.Texts;

            objCmdRecrutamento.ExecuteNonQuery();
            long idRecruta = objCmdRecrutamento.LastInsertedId;

            // INSERT TABELA PEGUNTA EXPEDIÇÃO
            MySqlCommand objCmdExpedicao = new MySqlCommand("insert into hypedb.pergunta_expedicao (id_pergunta_expedicao, pergunta_expedicao) values (null, ?)", database.getConnection());

            objCmdExpedicao.Parameters.Add("@pergunta_expedicao", MySqlDbType.VarChar, 5).Value = pergunta_expedicao;

            objCmdExpedicao.ExecuteNonQuery();
            long idPerguntaExpedicao = objCmdExpedicao.LastInsertedId;

            // INSERT TABELA PROGRESSÃO
            MySqlCommand objCmdProgressao = new MySqlCommand("insert into hypedb.progressao (id_progressao, data_progressao, novo_poder, novo_level, antigo_poder, antigo_level) values (null, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdProgressao.Parameters.Add("@data_progressao", MySqlDbType.Date).Value = DateTime.Now;
            objCmdProgressao.Parameters.Add("@novo_poder", MySqlDbType.Decimal).Value = novo_poder;
            objCmdProgressao.Parameters.Add("@novo_level", MySqlDbType.Int32).Value = novo_level;
            objCmdProgressao.Parameters.Add("@antigo_poder", MySqlDbType.Decimal).Value = txt_poder.Texts;
            objCmdProgressao.Parameters.Add("@antigo_level", MySqlDbType.Int32).Value = txt_level.Texts;

            objCmdProgressao.ExecuteNonQuery();
            long idProgressao = objCmdProgressao.LastInsertedId;

            // INSERT TABELA CADASTRO MEMBROS
            MySqlCommand objCmdCadastroMembros = new MySqlCommand("insert into hypedb.cadastro_membro (id_membros, nick, level, poder, classe, patente, id_pergunta_alt, id_recrutamento, id_pergunta_expedicao, id_progressao) values (null, ?, ?, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdCadastroMembros.Parameters.Add("@nick", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdCadastroMembros.Parameters.Add("@level", MySqlDbType.Int32).Value = txt_level.Texts;
            objCmdCadastroMembros.Parameters.Add("@poder", MySqlDbType.Decimal).Value = txt_poder.Texts;
            objCmdCadastroMembros.Parameters.Add("@classe", MySqlDbType.VarChar, 256).Value = txt_classe.Text;
            objCmdCadastroMembros.Parameters.Add("@patente", MySqlDbType.VarChar, 256).Value = txt_patente.Text;
            objCmdCadastroMembros.Parameters.Add("@id_pergunta_alt", MySqlDbType.Int32).Value = idPerguntaAlt;
            objCmdCadastroMembros.Parameters.Add("@id_recrutamento", MySqlDbType.Int32).Value = idRecruta;
            objCmdCadastroMembros.Parameters.Add("@id_pergunta_expedicao", MySqlDbType.Int32).Value = idPerguntaExpedicao;
            objCmdCadastroMembros.Parameters.Add("@id_progressao", MySqlDbType.Int32).Value = idProgressao;

            objCmdCadastroMembros.ExecuteNonQuery();

            database.closeConnection();
        }

        private void CadastroAlt_01()
        {
            CadastroMembro();

            configdb database = new configdb();
            database.openConnection();
           
            MySqlCommand objCmdAlt1 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_principal, nick_alt, level_alt, classe_alt, cla_alt, id_pergunta_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdAlt1.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdAlt1.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdAlt1.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_01.Texts;
            objCmdAlt1.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_01.Texts;
            objCmdAlt1.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_01.Text;
            objCmdAlt1.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_01.Texts;
            objCmdAlt1.Parameters.Add("@id_pergunta_alt", MySqlDbType.Int32).Value = idPerguntaAlt;

            objCmdAlt1.ExecuteNonQuery();

            database.closeConnection();
        }

        private void CadastroAlt_02()
        {
            CadastroAlt_01();

            configdb database = new configdb();
            database.openConnection();

            MySqlCommand objCmdAlt2 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_principal, nick_alt, level_alt, classe_alt, cla_alt, id_pergunta_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdAlt2.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdAlt2.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdAlt2.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_02.Texts;
            objCmdAlt2.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_02.Texts;
            objCmdAlt2.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_02.Text;
            objCmdAlt2.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_02.Texts;
            objCmdAlt2.Parameters.Add("@id_pergunta_alt", MySqlDbType.Int32).Value = idPerguntaAlt;

            objCmdAlt2.ExecuteNonQuery();

            database.closeConnection();
        }

        private void CadastroAlt_03()
        {
            CadastroAlt_02();

            configdb database = new configdb();
            database.openConnection();

            MySqlCommand objCmdAlt2 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_principal, nick_alt, level_alt, classe_alt, cla_alt, id_pergunta_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdAlt2.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdAlt2.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdAlt2.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_03.Texts;
            objCmdAlt2.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_03.Texts;
            objCmdAlt2.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_03.Text;
            objCmdAlt2.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_03.Texts;
            objCmdAlt2.Parameters.Add("@id_pergunta_alt", MySqlDbType.Int32).Value = idPerguntaAlt;

            objCmdAlt2.ExecuteNonQuery();

            database.closeConnection();
        }

        private void CadastroAlt_04()
        {
            CadastroAlt_03();

            configdb database = new configdb();
            database.openConnection();

            MySqlCommand objCmdAlt2 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_principal, nick_alt, level_alt, classe_alt, cla_alt, id_pergunta_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdAlt2.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdAlt2.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdAlt2.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_04.Texts;
            objCmdAlt2.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_04.Texts;
            objCmdAlt2.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_04.Text;
            objCmdAlt2.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_04.Texts;
            objCmdAlt2.Parameters.Add("@id_pergunta_alt", MySqlDbType.Int32).Value = idPerguntaAlt;

            objCmdAlt2.ExecuteNonQuery();

            database.closeConnection();
        }

        private void CadastroAlt_05()
        {
            CadastroAlt_04();

            configdb database = new configdb();
            database.openConnection();

            MySqlCommand objCmdAlt2 = new MySqlCommand("insert into hypedb.cadastro_alt (id_alt, data_entrada, nick_principal, nick_alt, level_alt, classe_alt, cla_alt, id_pergunta_alt) values (null, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdAlt2.Parameters.Add("@data_entrada", MySqlDbType.Date).Value = DateTime.Now;
            objCmdAlt2.Parameters.Add("@nick_principal", MySqlDbType.VarChar, 256).Value = txt_nick.Texts;
            objCmdAlt2.Parameters.Add("@nick_alt", MySqlDbType.VarChar, 256).Value = txt_nick_alt_05.Texts;
            objCmdAlt2.Parameters.Add("@level_alt", MySqlDbType.Int32).Value = txt_level_alt_05.Texts;
            objCmdAlt2.Parameters.Add("@classe_alt", MySqlDbType.VarChar, 256).Value = txt_classe_alt_05.Text;
            objCmdAlt2.Parameters.Add("@cla_alt", MySqlDbType.VarChar, 256).Value = txt_foi_alt_05.Texts;
            objCmdAlt2.Parameters.Add("@id_pergunta_alt", MySqlDbType.Int32).Value = idPerguntaAlt;

            objCmdAlt2.ExecuteNonQuery();

            database.closeConnection();
        }


        // BOTÕES
        private void bt_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                AddMembros();
                DialogResult dr = MessageBox.Show("Salvo Com Sucesso !", "Membros", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Código" + erro + "de Erro Interno ", "ERRO FATAL");
            }
            finally
            {
                LimparCadastro();

                rd_nao.Checked = true;
            }
        }

        private void VoltarMembros()
        {
            membros uc = new membros();
            cla.Instance.addControl(uc);
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            LimparCadastro();
        }

        private void bt_voltar_Click(object sender, EventArgs e)
        {

            try
            {
                VoltarMembros();
                LimparCadastro();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Código" + erro + "de Erro Interno ", "ERRO FATAL");
            }


        }

        public void LimparTextos(Control.ControlCollection control)
        {
            foreach (Control c in control)
            {
                if (c is RJTextBox)
                {
                    ((RJTextBox)(c)).Texts = string.Empty;
                }
            }

            foreach (Control c in control)
            {
                if (c is ComboBox)
                {
                    ((ComboBox)(c)).SelectedIndex = -1;
                }
            }
        }

        private void rd_sim_CheckedChanged(object sender, EventArgs e)
        {
            txt_quantidade_alt.Enabled = true;

            txt_quantidade_alt.SelectedIndex = 1;
        }

        private void rd_nao_CheckedChanged(object sender, EventArgs e)
        {
            txt_quantidade_alt.Enabled = false;
            txt_quantidade_alt.SelectedIndex = 0;

            LimparTextos(pl_conta_alt_01.Controls);
            LimparTextos(pl_conta_alt_02.Controls);
            LimparTextos(pl_conta_alt_03.Controls);
            LimparTextos(pl_conta_alt_04.Controls);
            LimparTextos(pl_conta_alt_05.Controls);

            CampoTextoAltDesativado(this.pl_conta_alt_01.Controls);
        }

        private void LimparCadastro()
        {
            txt_quantidade_alt.Enabled = false;
            txt_quantidade_alt.SelectedIndex = 0;

            LimparTextos(pl_conta_principal.Controls);

            LimparTextos(pl_conta_alt_01.Controls);
            LimparTextos(pl_conta_alt_02.Controls);
            LimparTextos(pl_conta_alt_03.Controls);
            LimparTextos(pl_conta_alt_04.Controls);
            LimparTextos(pl_conta_alt_05.Controls);

            CampoTextoAltDesativado(this.pl_conta_alt_01.Controls);
        }

        private void txt_quantidade_alt_SelectedIndexChanged(object sender, EventArgs e)
        {            
            // QUANTIDADE DE ALT QUE FOI SELECIONADO 
            switch (txt_quantidade_alt.SelectedIndex)
            {
                case 0:
                    PainelAlt00();
                    break;
                case 1:
                    PainelAlt01();
                    break;
                case 2:
                    PainelAlt02();
                    break;
                case 3:
                    PainelAlt03();
                    break;
                case 4:
                    PainelAlt04();
                    break;
                case 5:
                    PainelAlt05();
                    break;
                default:
                    break;
            }
        }

        private void PainelContaALT()
        {
            if (txt_quantidade_alt.SelectedIndex == 0)
                rd_nao.Checked = true;

            CampoTextoAltDesativado(this.pl_conta_alt_01.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_02.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_03.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_04.Controls);
            CampoTextoAltDesativado(this.pl_conta_alt_05.Controls);
        }

        private void CampoTextoAltDesativado(Control.ControlCollection control)
        {
            foreach (Control c in control)
            {
                if (c is RJTextBox)
                {
                    ((RJTextBox)c).Enabled = false;
                    ((RJTextBox)c).BackColor = Color.FromArgb(39, 44, 70);
                    ((RJTextBox)c).PlaceholderText = "";
                }

                if (c is ComboBox)
                {
                    ((ComboBox)c).Enabled = false;
                    ((ComboBox)c).BackColor = Color.FromArgb(39, 44, 70);
                    ((ComboBox)c).SelectedIndex = -1;

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

                if (c is ComboBox)
                {
                    ((ComboBox)c).Enabled = true;
                    ((ComboBox)c).BackColor = Color.White;
                }
            }
        }

        private void PainelAlt00()
        {
            PainelContaALT();
        }

        private void PainelAlt01()
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

        private void PainelAlt02()
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

        private void PainelAlt03()
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

        private void PainelAlt04()
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

        private void PainelAlt05()
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


    }
}
