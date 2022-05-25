﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Hype.Properties;
using Hype.painel;
using Hype.script;

namespace Hype
{
    public partial class membros_info : Form
    {
        public static membros_info Instance;

        public membros_info()
        {
            InitializeComponent();
            Instance = this;
        }

        public void addControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pl_todos.Controls.Clear();
            pl_todos.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void bt_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void membros_info_Load(object sender, EventArgs e)
        {
            perfil_membros uc = new perfil_membros();
            addControl(uc);

            this.FormBorderStyle = FormBorderStyle.None;            
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pl_top_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void FecharJanela()
        {
            Close();
        }
    }
}