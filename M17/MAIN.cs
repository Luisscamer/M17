using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M17
{
    public partial class MAIN : Form
    {

        BaseDados bd;

        public MAIN()
        {
            InitializeComponent();
            bd = new BaseDados("Bd_projeto");
        }

        private void clubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menusecundario menu = new menusecundario(bd);
            menu.Show();
        }
    }
}
