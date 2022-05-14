﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mir4.painel;

namespace Mir4.painel
{
    public partial class progressao : UserControl
    {
        public progressao()
        {
            InitializeComponent();
        }

        private void bt_membros_Click(object sender, EventArgs e)
        {       
            membros uc = new membros();
            cla.Instance.addControl(uc);
        }

        private void bt_ouro_Click(object sender, EventArgs e)
        {
            ouro uc = new ouro();
            cla.Instance.addControl(uc);
        }

        private void bt_alts_Click(object sender, EventArgs e)
        {
            alts uc = new alts();
            cla.Instance.addControl(uc);
        }
    }
}
