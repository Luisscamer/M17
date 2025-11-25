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
            //consultar a bd para recolher os dados do clube a editar
            tela.tb_nome.Text=
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

        //botao apagr clube
        private void bt_apagar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        void Eliminar()
        {
            if (nome == "")
            {
                MessageBox.Show("Tem de selecionar um clube primeiro.");
                return;
            }
            //confirmar
            if (MessageBox.Show("Tem a certeza que pretende apagar o clube selecionado?",
                "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                club apagar = new club(bd);
                apagar.nome = nome;
                apagar.Apagar();
                nome = "";
            }
        }
        public void Apagar()
        {
            //Isto é seguro porque o nlivro é um inteiro e não é inserido pelo utilizador
            string sql = "COLOCAR O CODIGO";
            bd.ExecutarSQL(sql);
        }
    }
}
