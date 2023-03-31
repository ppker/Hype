﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Hype.script;
using Hype.Painel.Home;

namespace Hype.Painel.Eventos
{
    public partial class doacao : UserControl
    {
        // ID`S
        string id_membro = eventos.Instance.id_membro;
        string id_doacao = eventos.Instance.id_doacao;
        string id_eventos = eventos.Instance.id_eventos;

        // SEMANAS DOACÖES
        bool semana_01 = true;
        bool semana_02 = false;
        bool semana_03 = false;
        bool semana_04 = false;

        // OURO
        string totalDoacao;

        // SELECIONAR CLA 
        public string nome_cla = home.Instance.nome_cla;

        public doacao()
        {
            InitializeComponent();
        }

        #region TABELAS
        private void TabelaEvento()
        {
            configdb database = new configdb();
            database.openConnection();

            MySqlCommand cmd = new MySqlCommand("select c.ID_MEMBROS, d.ID_DOACAO, eve.ID_EVENTOS, cl.NOME_CLA, eve.ANO_EVENTO, eve.MES_EVENTO, c.NICK, d.SEMANA_01, d.SEMANA_02, d.SEMANA_03, d.SEMANA_04, d.TOTAL, d.ANOTACAO from hypedb.cadastro_membro c join hypedb.recrutamento re on re.ID_RECRUTAMENTO = c.ID_RECRUTAMENTO join hypedb.doacao d on d.ID_MEMBROS = c.ID_MEMBROS join hypedb.eventos eve on eve.ID_EVENTOS = d.ID_EVENTOS join hypedb.cadastro_cla cl on cl.ID_CLA = re.ID_CLA where c.ID_MEMBROS like '"+ id_membro +"' ", database.getConnection());

            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }

            database.closeConnection();

            if (dataGridView1.Rows.Count == 0)
            {
                txt_sem_dados.Visible = true;

                dataGridView1.Visible = false;
            }
            else
            {
                txt_sem_dados.Visible = false;

                dataGridView1.Visible = true;
            }

            Tabela();
        }

        private void Tabela()
        {
            dataGridView1.Columns[0].Visible = false; // ID_MEMBROS
            dataGridView1.Columns[1].Visible = false; // ID_DOACAO
            dataGridView1.Columns[2].Visible = false; // ID_EVENTOS
            dataGridView1.Columns[3].Visible = false; // NOME_CLA
            dataGridView1.Columns[4].HeaderText = "ANO";
            dataGridView1.Columns[5].HeaderText = "MÊS";
            dataGridView1.Columns[6].HeaderText = "NICK";
            dataGridView1.Columns[7].HeaderText = "SEMANA 01";
            dataGridView1.Columns[8].HeaderText = "SEMANA 02";
            dataGridView1.Columns[9].HeaderText = "SEMANA 03";
            dataGridView1.Columns[10].HeaderText = "SEMANA 04";
            dataGridView1.Columns[11].Visible = false; // TOTAL
            dataGridView1.Columns[12].Visible = false; // ANOTACAO

            dataGridView1.Columns["MES_EVENTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["SEMANA_01"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["SEMANA_02"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["SEMANA_03"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["SEMANA_04"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.DataPropertyName == "ANO_EVENTO")
                    column.Width = 80;
                else if (column.DataPropertyName == "MES_EVENTO")
                    column.Width = 100;
                else if (column.DataPropertyName == "NICK")
                    column.Width = 250;
                else if (column.DataPropertyName == "SEMANA_01")
                    column.Width = 150;
                else if (column.DataPropertyName == "SEMANA_02")
                    column.Width = 150;
                else if (column.DataPropertyName == "SEMANA_03")
                    column.Width = 150;
                else if (column.DataPropertyName == "SEMANA_04")
                    column.Width = 150;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MostrarDadosTabela();
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Cursor = Cursors.Hand;
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Cursor = Cursors.Default;
        }

        private void MostrarDadosTabela()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataRowView dr = (DataRowView)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                    // ANOTAÇÃO
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Código" + erro + "de Erro Interno ", "ERRO FATAL");
            }
            finally
            {
                doacao uc = new doacao();
                cla.Instance.addControl(uc);
            }
        }

        private void AtualizarTabela()
        {
            configdb database = new configdb();
            database.openConnection();

            MySqlCommand cmd = new MySqlCommand("select c.ID_MEMBROS, d.ID_DOACAO, eve.ID_EVENTOS, cl.NOME_CLA, eve.ANO_EVENTO, eve.MES_EVENTO, c.NICK, d.SEMANA_01, d.SEMANA_02, d.SEMANA_03, d.SEMANA_04, d.TOTAL, d.ANOTACAO from hypedb.cadastro_membro c join hypedb.recrutamento re on re.ID_RECRUTAMENTO = c.ID_RECRUTAMENTO join hypedb.doacao d on d.ID_MEMBROS = c.ID_MEMBROS join hypedb.eventos eve on eve.ID_EVENTOS = d.ID_EVENTOS join hypedb.cadastro_cla cl on cl.ID_CLA = re.ID_CLA where c.ID_MEMBROS like '" + id_membro + "' ", database.getConnection());

            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }

            database.closeConnection();

            if (dataGridView1.Rows.Count == 0)
            {
                txt_sem_dados.Visible = true;

                dataGridView1.Visible = false;
            }
            else
            {
                txt_sem_dados.Visible = false;

                dataGridView1.Visible = true;
            }            
        }

        private void DadosDoacao()
        {
            configdb database = new configdb();
            database.openConnection();

            MySqlCommand cmd = new MySqlCommand("select c.ID_MEMBROS, d.ID_DOACAO, eve.ID_EVENTOS, cl.NOME_CLA, eve.ANO_EVENTO, eve.MES_EVENTO, c.NICK, d.SEMANA_01, d.SEMANA_02, d.SEMANA_03, d.SEMANA_04, d.TOTAL, d.ANOTACAO from hypedb.cadastro_membro c join hypedb.recrutamento re on re.ID_RECRUTAMENTO = c.ID_RECRUTAMENTO join hypedb.doacao d on d.ID_MEMBROS = c.ID_MEMBROS join hypedb.eventos eve on eve.ID_EVENTOS = d.ID_EVENTOS join hypedb.cadastro_cla cl on cl.ID_CLA = re.ID_CLA where c.ID_MEMBROS like '" + id_membro + "' ", database.getConnection());

            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                // ID`S
                id_membro = dr["ID_MEMBROS"].ToString();
                id_eventos = dr["ID_EVENTOS"].ToString();
                id_doacao = dr["ID_DOACAO"].ToString();

                // SEMANAS
                if (semana_01)
                {
                    txt_doacao_01.Texts = dr["SEMANA_01"].ToString();

                    semana_01 = false;
                    semana_02 = true;
                }

                if (semana_02)
                {
                    txt_doacao_02.Texts = dr["SEMANA_02"].ToString();

                    if (txt_doacao_02.Texts == "0,00")
                    {
                        txt_doacao_02.Texts = string.Empty;
                    }
                    else
                    {
                        txt_doacao_02.Texts = dr["SEMANA_02"].ToString();

                        semana_02 = false;
                        semana_03 = true;
                    }
                }

                if (semana_03)
                {
                    txt_doacao_03.Texts = dr["SEMANA_03"].ToString();

                    if (txt_doacao_03.Texts == "0,00")
                    {
                        txt_doacao_03.Texts = string.Empty;
                    }
                    else
                    {
                        txt_doacao_03.Texts = dr["SEMANA_03"].ToString();

                        semana_03 = false;
                        semana_04 = true;
                    }
                }

                if (semana_04)
                {
                    txt_doacao_04.Texts = dr["SEMANA_04"].ToString();

                    if (txt_doacao_04.Texts == "0,00")
                    {
                        txt_doacao_04.Texts = string.Empty;
                    }
                    else
                    {
                        txt_doacao_04.Texts = dr["SEMANA_04"].ToString();                        

                        semana_04 = false;
                        semana_01 = true;

                        Limpar(); // Novo Mês  
                    }
                }                
            }

            database.closeConnection();
        }
        #endregion

        #region ALERTAS
        private void Alertas()
        {
            if(semana_01)
            {
                /*
                if (String.IsNullOrEmpty(txt_doacao_01.Texts))
                {
                    txt_doacao_01.BorderColor = Color.Red;
                    txt_doacao_01.BorderSize = 3;
                }
                else if (conftext.IsNumero(txt_doacao_01.Texts) == false)
                {
                    txt_doacao_01.BorderColor = Color.Red;
                    txt_doacao_01.BorderSize = 3;

                    MessageBox.Show("Somente Numeros !", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                }
                */
                try
                {
                    Semana_01();

                    CampoDoacao(lb_semana_02, txt_doacao_02, lb_semana_01, txt_doacao_01, lb_semana_03, txt_doacao_03, lb_semana_04, txt_doacao_04);

                    semana_02 = true;
                    semana_01 = false;
                }
                finally
                {
                    AtualizarTabela();
                }
            }

            if (semana_02)
            {
                /*
                if (String.IsNullOrEmpty(txt_doacao_02.Texts))
                {
                    txt_doacao_02.BorderColor = Color.Red;
                    txt_doacao_02.BorderSize = 3;
                }
                else if (conftext.IsNumero(txt_doacao_02.Texts) == false)
                {
                    txt_doacao_02.BorderColor = Color.Red;
                    txt_doacao_02.BorderSize = 3;

                    MessageBox.Show("Somente Numeros !", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                }
                */
                try
                {
                    Semana_02();

                    CampoDoacao(lb_semana_03, txt_doacao_03, lb_semana_01, txt_doacao_01, lb_semana_02, txt_doacao_02, lb_semana_04, txt_doacao_04);

                    semana_03 = true;
                    semana_01 = false;
                    semana_02 = false;
                }
                finally
                {
                    AtualizarTabela();
                }
            }

            if (semana_03)
            {
                if (String.IsNullOrEmpty(txt_doacao_03.Texts))
                {
                    txt_doacao_03.BorderColor = Color.Red;
                    txt_doacao_03.BorderSize = 3;
                }
                else if (conftext.IsNumero(txt_doacao_03.Texts) == false)
                {
                    txt_doacao_03.BorderColor = Color.Red;
                    txt_doacao_03.BorderSize = 3;

                    MessageBox.Show("Somente Numeros !", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        Salvar();
                    }
                    finally
                    {
                        AtualizarTabela();
                    }
                }
            }

            if (semana_04)
            {
                if (String.IsNullOrEmpty(txt_doacao_04.Texts))
                {
                    txt_doacao_04.BorderColor = Color.Red;
                    txt_doacao_04.BorderSize = 3;
                }
                else if (conftext.IsNumero(txt_doacao_04.Texts) == false)
                {
                    txt_doacao_04.BorderColor = Color.Red;
                    txt_doacao_04.BorderSize = 3;

                    MessageBox.Show("Somente Numeros !", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        Salvar();                        
                    }
                    finally
                    {
                        AtualizarTabela();                        
                    }
                }
            }
        }
        #endregion

        #region BOTÕES
        private void bt_voltar_Click(object sender, EventArgs e)
        {
            eventos uc = new eventos();
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

        private void Semana_01()
        {
            // BANCO DE DADOS
            configdb database = new configdb();
            database.openConnection();

            double de = (Convert.ToDouble(txt_doacao_01.Texts));
            totalDoacao = de.ToString();

            // INSERT TABELA EVENTOS
            MySqlCommand objCmdEventos = new MySqlCommand("insert into hypedb.eventos (id_eventos, mes_evento, ano_evento, id_membros) values (null, ?, ?, ?)", database.getConnection());

            objCmdEventos.Parameters.Add("@mes_evento", MySqlDbType.VarChar, 256).Value = DateTime.Now.ToString("MMMM");
            objCmdEventos.Parameters.Add("@ano_evento", MySqlDbType.Year).Value = DateTime.Now.Year;
            objCmdEventos.Parameters.Add("@id_membros", MySqlDbType.Int32).Value = id_membro;

            objCmdEventos.ExecuteNonQuery();
            long idEventos = objCmdEventos.LastInsertedId;

            // INSERT TABELA DOAÇÃO
            MySqlCommand objCmdDoacao = new MySqlCommand("insert into hypedb.doacao (id_doacao, semana_01, semana_02, semana_03, semana_04, total, anotacao, id_eventos, id_membros) values (null, ?, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

            objCmdDoacao.Parameters.Add("@semana_01", MySqlDbType.Decimal).Value = txt_doacao_01.Texts;
            objCmdDoacao.Parameters.Add("@semana_02", MySqlDbType.Decimal).Value = 0;
            objCmdDoacao.Parameters.Add("@semana_03", MySqlDbType.Decimal).Value = 0;
            objCmdDoacao.Parameters.Add("@semana_04", MySqlDbType.Decimal).Value = 0;
            objCmdDoacao.Parameters.Add("@total", MySqlDbType.Decimal).Value = totalDoacao;
            objCmdDoacao.Parameters.Add("@anotacao", MySqlDbType.VarChar, 256).Value = "";
            objCmdDoacao.Parameters.Add("@id_eventos", MySqlDbType.Int32).Value = idEventos;
            objCmdDoacao.Parameters.Add("@id_membros", MySqlDbType.Int32).Value = id_membro;

            objCmdDoacao.ExecuteNonQuery();

            DialogResult dr = MessageBox.Show("Doação Efetuada Com Sucesso !", "Semana 1", MessageBoxButtons.OK, MessageBoxIcon.Information);

            database.closeConnection();
        }

        private void Semana_02()
        {
            // BANCO DE DADOS
            configdb database = new configdb();
            database.openConnection();

            double de = (Convert.ToDouble(txt_doacao_01.Texts) + Convert.ToDouble(txt_doacao_02.Texts));
            totalDoacao = de.ToString();

            // INSERT TABELA DOAÇÃO
            MySqlCommand objCmdDoacao = new MySqlCommand("update hypedb.doacao set semana_01=@semana_01, semana_02=@semana_02, semana_03=@semana_03, semana_04=@semana_04, total=@total where (id_doacao=@id_doacao) and (id_eventos=@id_eventos) and (id_membros=@id_membros)", database.getConnection());

            objCmdDoacao.Parameters.AddWithValue("@id_doacao", id_doacao);
            objCmdDoacao.Parameters.AddWithValue("@id_eventos", id_eventos);
            objCmdDoacao.Parameters.AddWithValue("@id_membros", id_membro);
            objCmdDoacao.Parameters.Add("@semana_01", MySqlDbType.Decimal).Value = txt_doacao_01.Texts;
            objCmdDoacao.Parameters.Add("@semana_02", MySqlDbType.Decimal).Value = txt_doacao_02.Texts;
            objCmdDoacao.Parameters.Add("@semana_03", MySqlDbType.Decimal).Value = 0;
            objCmdDoacao.Parameters.Add("@semana_04", MySqlDbType.Decimal).Value = 0;
            objCmdDoacao.Parameters.Add("@total", MySqlDbType.Decimal).Value = totalDoacao;

            objCmdDoacao.ExecuteNonQuery();

            DialogResult dr = MessageBox.Show("Doação Efetuada Com Sucesso !", "Semana 2", MessageBoxButtons.OK, MessageBoxIcon.Information);

            database.closeConnection();
        }

        private void Salvar()
        {
            // BANCO DE DADOS
            configdb database = new configdb();
            database.openConnection();

            if (semana_01)
                {
                double de = (Convert.ToDouble(txt_doacao_01.Texts));
                totalDoacao = de.ToString();

                // INSERT TABELA EVENTOS
                MySqlCommand objCmdEventos = new MySqlCommand("insert into hypedb.eventos (id_eventos, mes_evento, ano_evento, id_membros) values (null, ?, ?, ?)", database.getConnection());

                objCmdEventos.Parameters.Add("@mes_evento", MySqlDbType.VarChar, 256).Value = DateTime.Now.ToString("MMMM");
                objCmdEventos.Parameters.Add("@ano_evento", MySqlDbType.Year).Value = DateTime.Now.Year;
                objCmdEventos.Parameters.Add("@id_membros", MySqlDbType.Int32).Value = id_membro;

                objCmdEventos.ExecuteNonQuery();
                long idEventos = objCmdEventos.LastInsertedId;

                // INSERT TABELA DOAÇÃO
                MySqlCommand objCmdDoacao = new MySqlCommand("insert into hypedb.doacao (id_doacao, semana_01, semana_02, semana_03, semana_04, total, anotacao, id_eventos, id_membros) values (null, ?, ?, ?, ?, ?, ?, ?, ?)", database.getConnection());

                objCmdDoacao.Parameters.Add("@semana_01", MySqlDbType.Decimal).Value = txt_doacao_01.Texts;
                objCmdDoacao.Parameters.Add("@semana_02", MySqlDbType.Decimal).Value = 0;
                objCmdDoacao.Parameters.Add("@semana_03", MySqlDbType.Decimal).Value = 0;
                objCmdDoacao.Parameters.Add("@semana_04", MySqlDbType.Decimal).Value = 0;
                objCmdDoacao.Parameters.Add("@total", MySqlDbType.Decimal).Value = totalDoacao;
                objCmdDoacao.Parameters.Add("@anotacao", MySqlDbType.VarChar, 256).Value = "";
                objCmdDoacao.Parameters.Add("@id_eventos", MySqlDbType.Int32).Value = idEventos;
                objCmdDoacao.Parameters.Add("@id_membros", MySqlDbType.Int32).Value = id_membro;

                objCmdDoacao.ExecuteNonQuery();

                DialogResult dr = MessageBox.Show("Doação Efetuada Com Sucesso !", "Semana 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (semana_02)
            {
                double de = (Convert.ToDouble(txt_doacao_01.Texts) + Convert.ToDouble(txt_doacao_02.Texts));
                totalDoacao = de.ToString();

                // INSERT TABELA DOAÇÃO
                MySqlCommand objCmdDoacao = new MySqlCommand("update hypedb.doacao set semana_01=@semana_01, semana_02=@semana_02, semana_03=@semana_03, semana_04=@semana_04, total=@total where (id_doacao=@id_doacao) and (id_eventos=@id_eventos) and (id_membros=@id_membros)", database.getConnection());

                objCmdDoacao.Parameters.AddWithValue("@id_doacao", id_doacao);
                objCmdDoacao.Parameters.AddWithValue("@id_eventos", id_eventos);
                objCmdDoacao.Parameters.AddWithValue("@id_membros", id_membro);
                objCmdDoacao.Parameters.Add("@semana_01", MySqlDbType.Decimal).Value = txt_doacao_01.Texts;
                objCmdDoacao.Parameters.Add("@semana_02", MySqlDbType.Decimal).Value = txt_doacao_02.Texts;
                objCmdDoacao.Parameters.Add("@semana_03", MySqlDbType.Decimal).Value = 0;
                objCmdDoacao.Parameters.Add("@semana_04", MySqlDbType.Decimal).Value = 0;
                objCmdDoacao.Parameters.Add("@total", MySqlDbType.Decimal).Value = totalDoacao;

                objCmdDoacao.ExecuteNonQuery();

                DialogResult dr = MessageBox.Show("Doação Efetuada Com Sucesso !", "Semana 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (semana_03)
            {
                double de = (Convert.ToDouble(txt_doacao_01.Texts) + Convert.ToDouble(txt_doacao_02.Texts) + Convert.ToDouble(txt_doacao_03.Texts));
                totalDoacao = de.ToString();

                // INSERT TABELA DOAÇÃO
                MySqlCommand objCmdDoacao = new MySqlCommand("update hypedb.doacao set semana_01=@semana_01, semana_02=@semana_02, semana_03=@semana_03, semana_04=@semana_04, total=@total where (id_doacao=@id_doacao) and (id_eventos=@id_eventos) and (id_membros=@id_membros)", database.getConnection());

                objCmdDoacao.Parameters.AddWithValue("@id_doacao", id_doacao);
                objCmdDoacao.Parameters.AddWithValue("@id_eventos", id_eventos);
                objCmdDoacao.Parameters.AddWithValue("@id_membros", id_membro);
                objCmdDoacao.Parameters.Add("@semana_01", MySqlDbType.Decimal).Value = txt_doacao_01.Texts;
                objCmdDoacao.Parameters.Add("@semana_02", MySqlDbType.Decimal).Value = txt_doacao_02.Texts;
                objCmdDoacao.Parameters.Add("@semana_03", MySqlDbType.Decimal).Value = txt_doacao_03.Texts;
                objCmdDoacao.Parameters.Add("@semana_04", MySqlDbType.Decimal).Value = 0;
                objCmdDoacao.Parameters.Add("@total", MySqlDbType.Decimal).Value = totalDoacao;

                objCmdDoacao.ExecuteNonQuery();

                DialogResult dr = MessageBox.Show("Doação Efetuada Com Sucesso !", "Semana 3", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (semana_04)
            {
                double de = (Convert.ToDouble(txt_doacao_01.Texts) + Convert.ToDouble(txt_doacao_02.Texts) + Convert.ToDouble(txt_doacao_03.Texts) + Convert.ToDouble(txt_doacao_04.Texts));
                totalDoacao = de.ToString();

                // INSERT TABELA DOAÇÃO
                MySqlCommand objCmdDoacao = new MySqlCommand("update hypedb.doacao set semana_01=@semana_01, semana_02=@semana_02, semana_03=@semana_03, semana_04=@semana_04, total=@total where (id_doacao=@id_doacao) and (id_eventos=@id_eventos) and (id_membros=@id_membros)", database.getConnection());

                objCmdDoacao.Parameters.AddWithValue("@id_doacao", id_doacao);
                objCmdDoacao.Parameters.AddWithValue("@id_eventos", id_eventos);
                objCmdDoacao.Parameters.AddWithValue("@id_membros", id_membro);
                objCmdDoacao.Parameters.Add("@semana_01", MySqlDbType.Decimal).Value = txt_doacao_01.Texts;
                objCmdDoacao.Parameters.Add("@semana_02", MySqlDbType.Decimal).Value = txt_doacao_02.Texts;
                objCmdDoacao.Parameters.Add("@semana_03", MySqlDbType.Decimal).Value = txt_doacao_03.Texts;
                objCmdDoacao.Parameters.Add("@semana_04", MySqlDbType.Decimal).Value = txt_doacao_04.Texts;
                objCmdDoacao.Parameters.Add("@total", MySqlDbType.Decimal).Value = totalDoacao;

                objCmdDoacao.ExecuteNonQuery();

                DialogResult dr = MessageBox.Show("Doação Efetuada Com Sucesso !", "Semana 4", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            database.closeConnection();
        }
        #endregion

        #region CAMPO TEXTO
        private void Limpar()
        {
            txt_doacao_01.Texts = string.Empty;
            txt_doacao_02.Texts = string.Empty;
            txt_doacao_03.Texts = string.Empty;
            txt_doacao_04.Texts = string.Empty;
        }

        private void CampoDoacao(Label lb1, RJTextBox text1, Label lb2, RJTextBox text2, Label lb3, RJTextBox text3, Label lb4, RJTextBox text4)
        {
            lb1.ForeColor = Color.White;
            text1.BackColor = Color.White;
            text1.Enabled = true;

            lb2.ForeColor = Color.FromArgb(24, 25, 28);
            text2.BackColor = Color.FromArgb(24, 25, 28);
            text2.Enabled = false;

            lb3.ForeColor = Color.FromArgb(24, 25, 28);
            text3.BackColor = Color.FromArgb(24, 25, 28);
            text3.Enabled = false;

            lb4.ForeColor = Color.FromArgb(24, 25, 28);
            text4.BackColor = Color.FromArgb(24, 25, 28);
            text4.Enabled = false;
        }

        private void txt_doacao_01_Enter(object sender, EventArgs e)
        {
            txt_doacao_01.BorderSize = 1;
        }

        private void txt_doacao_02_Enter(object sender, EventArgs e)
        {
            txt_doacao_02.BorderSize = 1;
        }

        private void txt_doacao_03_Enter(object sender, EventArgs e)
        {
            txt_doacao_03.BorderSize = 1;
        }

        private void txt_doacao_04_Enter(object sender, EventArgs e)
        {
            txt_doacao_04.BorderSize = 1;
        }
        #endregion

        private void novo_evento_Load(object sender, EventArgs e)
        {
            CampoDoacao(lb_semana_01, txt_doacao_01, lb_semana_02, txt_doacao_02, lb_semana_03, txt_doacao_03, lb_semana_04, txt_doacao_04);

            DadosDoacao();
            TabelaEvento();            

            // COLORIR O TITULO DA TABELA
            dataGridView1.EnableHeadersVisualStyles = false;
        }


    }
}
