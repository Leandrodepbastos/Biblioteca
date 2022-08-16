using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_BookStore
{
    public partial class frm_Principal : Form
    {
        public frm_Principal()
        {
            InitializeComponent();
        }


        

        private void associadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Associado obj_frm_Associado = new frm_Associado();
            obj_frm_Associado.ShowDialog();
        }


        private void tm_Principal_Tick(object sender, EventArgs e)
        {
            toolStripStatus_Data.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            toolStripStatus_Hora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
