using M17.clube;
using System;
using System.Windows.Forms;

namespace M17
{
    public partial class menusecundario : Form
    {
        BaseDados bd;
        string clubeSelecionado = "";

        public menusecundario(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
        }

        private void menusecundario_Load(object sender, EventArgs e)
        {

        }

        // BOTÃO EDITAR CLUBE
        private void button2_Click(object sender, EventArgs e)
        {
            if (clubeSelecionado == "")
            {
                MessageBox.Show("Tem de selecionar um clube primeiro.");
                return;
            }

            // abre o formulário do clube já com BD
            Clube tela = new Clube(bd);

            // aqui deves preencher os campos com a BD
            // Exemplo:
            // DataRow linha = bd.DevolverDados("SELECT * FROM Clube WHERE nome=@nome", clubeSelecionado);
            // tela.SetDados(linha);

            tela.Show();
            this.Hide();
        }

        // BOTÃO NOVO CLUBE
        private void button3_Click(object sender, EventArgs e)
        {
            Clube tela = new Clube(bd);
            tela.Show();
            this.Hide();
        }

        // BOTÃO APAGAR
        private void bt_apagar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        void Eliminar()
        {
            if (clubeSelecionado == "")
            {
                MessageBox.Show("Tem de selecionar um clube primeiro.");
                return;
            }

            if (MessageBox.Show("Tem a certeza que pretende apagar o clube selecionado?",
                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Clube apagar = new Clube(bd);
                apagar.nome = clubeSelecionado;
                apagar.Apagar();
                clubeSelecionado = "";
            }
        }
    }
}
