using M17.clube;
using System;
using System.Data;
using System.Windows.Forms;

namespace M17
{
    public partial class menusecundario : Form
    {
        BaseDados bd;
        string clubeSelecionado = "";
        int id_clube = 0;

        public menusecundario(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
        }

        private void ListarClubes()
        {
            dgv_clubes.AllowUserToAddRows = false;
            dgv_clubes.ReadOnly = true;
            dgv_clubes.AllowUserToDeleteRows = false;
            dgv_clubes.MultiSelect = false;
            dgv_clubes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clube.clube c = new clube.clube(bd,"");
            dgv_clubes.DataSource = c.Listar();
        }

        private void menusecundario_Load(object sender, EventArgs e)
        {
            ListarClubes();
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
            f_clube tela = new f_clube(bd, id_clube,this,"");



            // aqui deves preencher os campos com a BD
            // Exemplo:
            // DataRow linha = bd.DevolverDados("SELECT * FROM Clube WHERE nome=@nome", clubeSelecionado);


            tela.Show();
            this.Hide();

        }

        // BOTÃO NOVO CLUBE
        private void button3_Click(object sender, EventArgs e)
        {
            f_clube tela = new f_clube(bd);
            tela.Show();
            this.Hide();
        }

        // BOTÃO APAGAR
        private void bt_apagar_Click(object sender, EventArgs e)
        {
            clube.clube c = new clube.clube(bd, "");
            c.nome = clubeSelecionado;
            c.Eliminar();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgv_clubes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int linha = e.RowIndex;

            clubeSelecionado = dgv_clubes.Rows[linha].Cells["nome"].Value.ToString();
            id_clube = Convert.ToInt32(dgv_clubes.Rows[linha].Cells["id_clube"].Value);
        }


    }
}
