using M17.clube;
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
    public partial class menusecundario : Form
    {
        public menusecundario()
        {
            InitializeComponent();
        }

        private void menusecundario_Load(object sender, EventArgs e)
        {

        }

        //botao editar club
        private void button2_Click(object sender, EventArgs e)
        {
            club tela = new club();
            tela.Show();
            this.Hide();
        }

        // botao novo cluve
        private void button3_Click(object sender, EventArgs e)
        {
            club tela = new club();
            tela.Show();
            this.Hide();
        }
    }
}
