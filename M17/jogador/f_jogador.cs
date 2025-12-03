using M17.jogador;
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
    public partial class f_jogador : Form
    {
        BaseDados bd;
        int id_jogador = 0;
        menujogadores menujogadores;
        string fotografia = "";

        public f_jogador(BaseDados bd, int id, menujogadores menujogadores)
        {
            InitializeComponent();
            this.bd = bd;
            this.menujogadores = menujogadores;
            CarregarDados();
        }
        public f_jogador(BaseDados bd)   // construtor para a outra classe
        {
            InitializeComponent();
            this.bd = bd;
            this.id_jogador = 0;
        }

        private void CarregarDados()
        {
            DataTable dados = bd.DevolveSQL("SELECT * FROM Jogador WHERE id_jogador=" + id_jogador);

            if (dados.Rows.Count == 0) return;

            DataRow linha = dados.Rows[0];

            tb_nomej.Text = linha["nome"].ToString();
            tb_nacionalidade.Text = linha["nacionalidade"].ToString();
            tb_posicao.Text = linha["posicao"].ToString();
            nmr_camisola.Value = Convert.ToInt32(linha["nmr_camisola"]);
            dtp_nascimento.Value = Convert.ToDateTime(linha["data_nascimento"]);
            tb_clube.Text = linha["id_clube"].ToString();
            tb_valor_mercado.Text = linha["valor_mercado"].ToString();
        }
        private void LimparForm()
        {
            tb_nomej.Text = "";
            tb_nacionalidade.Text = "";
            tb_posicao.Text = "";
            tb_valor_mercado.Text = "";
            nmr_camisola.Value = nmr_camisola.Minimum;
            dtp_nascimento.Value = DateTime.Now;
            pb_fotografia.Image = null;
            tb_clube.Text = "";
        }

        private void btn_procurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ficheiro = new OpenFileDialog();
            ficheiro.InitialDirectory = "C:\\";
            ficheiro.Multiselect = false;
            ficheiro.Filter = "Imagens |*.jpg;*.jpeg;*.png;*.bmp | Todos os ficheiros |*.*";
            if (ficheiro.ShowDialog() == DialogResult.OK)
            {
                string temp = ficheiro.FileName;
                if (System.IO.File.Exists(temp))
                {
                    pb_fotografia.Image = Image.FromFile(temp);
                    fotografia = temp;
                }
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Jogador novo = new Jogador(bd);
            if (id_jogador == 0)
            {
                //criar um objeto do tipo livro
                //preencher os dados do livro
                novo.nome = tb_nomej.Text;
                novo.data_nascimento = dtp_nascimento.Value;
                novo.nacionalidade = tb_nacionalidade.Text;
                novo.posicao = tb_posicao.Text;
                novo.nmr_camisola = (int)nmr_camisola.Value;
                novo.clube = tb_clube.Text;
                novo.valor_mercado = tb_valor_mercado.Text;
                novo.fotografia = Utils.PastaDoPrograma("M17A_Projeto") + @"\" + novo.nome;
                //validar os dados
                List<string> erros = novo.Validar();
                //se não tiver erros
                if (erros.Count > 0)
                {
                    //mostrar os erros
                    string mensagem = "";
                    foreach (string erro in erros)
                        mensagem += erro + "; ";
                    label_feedback.Text = mensagem;
                    label_feedback.ForeColor = Color.Red;
                    return;
                }
                //guardar na base de dados
                novo.Adicionar();
                //copiar a capa para a pasta do programa
                if (fotografia != "")
                {
                    if (System.IO.File.Exists(fotografia))
                        System.IO.File.Copy(fotografia, novo.fotografia, true);
                }
                //limpar o form
                LimparForm();
                //feedback user
                label_feedback.Text = "Clube adicionado com sucesso.";
                label_feedback.ForeColor = Color.Black;
                this.Close();
                menujogadores menu = new menujogadores(bd);
                menu.Show();

            }
            else
            {
                novo.id_jogador = id_jogador;
                novo.nome = tb_nomej.Text;
                novo.data_nascimento = dtp_nascimento.Value;
                novo.nacionalidade = tb_nacionalidade.Text;
                novo.posicao = tb_posicao.Text;
                novo.nmr_camisola = (int)nmr_camisola.Value;
                novo.clube = tb_clube.Text;
                novo.valor_mercado = tb_valor_mercado.Text;
                novo.fotografia = fotografia;
                novo.Editar();
                this.Close();
                menujogadores menu = new menujogadores(bd);
                menu.Show();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            this.Hide();
            menujogadores menu = new menujogadores(bd);
            menu.Show();
        }

        private void f_jogador_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM jogador WHERE id_jogador=" + id_jogador;
            DataTable temp = bd.DevolveSQL(sql);
            if (temp != null && temp.Rows.Count > 0)
            {
                DataRow linha = temp.Rows[0];
                tb_nomej.Text = linha["nome"].ToString();
                tb_nacionalidade.Text = linha["nacionalidade"].ToString();
                dtp_nascimento.Value = Convert.ToDateTime(linha["nascimento"]);
                tb_posicao.Text = linha["posicao"].ToString();
                nmr_camisola.Value = Convert.ToInt32(linha["nmr_camisola"]);
                tb_clube.Text = linha["clube"].ToString();
                tb_valor_mercado.Text = linha["valor_mercado"].ToString();
            }
        }
    }
}
