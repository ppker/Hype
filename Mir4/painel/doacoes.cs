﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mir4.painel
{
    public partial class doacoes : UserControl
    {
        public doacoes()
        {
            InitializeComponent();
        }

        public void addControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pl_conteudo.Controls.Clear();
            pl_conteudo.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void bt_procurar_Click(object sender, EventArgs e)
        {
            membros_detalhes uc = new membros_detalhes();
            addControl(uc);
        }
    }
}
