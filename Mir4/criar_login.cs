﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mir4
{
    public partial class criar_login : Form
    {
        bool mouseDown;
        private Point offset;

        public criar_login()
        {
            InitializeComponent();
        }

        private void pl_top_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void pl_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point po = PointToScreen(e.Location);
                Location = new Point(po.X - offset.X, po.Y - offset.Y);
            }
        }

        private void pl_top_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }


        private void bt_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}