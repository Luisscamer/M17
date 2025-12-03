using M17.jogador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M17
{
    public partial class menujogadores : Form
    {
        BaseDados bd;
        int id_selecionado = 0;
        int id_jogador = 0;
        public menujogadores(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
        }

        private void bt_editar_Click(object sender, EventArgs e)
        {
            if (id_selecionado == 0)
            {
                MessageBox.Show("Tem de selecionar um jogador primeiro.");
                return;
            }
            // abre o formulário do jogador já com BD
            f_jogador tela = new f_jogador(bd);
            // aqui deves preencher os campos com a BD
            // Exemplo:
            // DataRow linha = bd.DevolverDados("SELECT * FROM Clube WHERE nome=@nome", clubeSelecionado);
            tela.Show();
            this.Hide();
        }

        private void bt_adicionar_Click(object sender, EventArgs e)
        {
            f_jogador tela = new f_jogador(bd);
            tela.Show();
            this.Close();
        }

        private void br_apagar_Click(object sender, EventArgs e)
        {
            string nomeSelecionado = dgv_jogadores.CurrentRow.Cells["nome"].Value.ToString();
            jogador.Jogador j = new jogador.Jogador(bd);
            j.nome = nomeSelecionado;
            j.Eliminar();
        }

        private void bt_imprimir_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }
    }
}
