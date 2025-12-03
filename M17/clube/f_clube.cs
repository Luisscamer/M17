using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M17.clube
{
    public partial class f_clube : Form
    {

        BaseDados bd;
        string nomeselecionado;
        int id_editar = 0;
        menuclubes m;
        string logotipo = "";



        // para o botao ediatr mandar as informcaoes para o outro form
        //public Clube(BaseDados bd, string clubeSelecionado,menusecundario m)
        //{
        //    InitializeComponent();
        //    this.bd = bd;
        //    this.nomeselecionado = clubeSelecionado;
        //    this.m = m;
        //}
        public f_clube(BaseDados bd, int id,menuclubes m,string clubeSelecionado)
        {
            InitializeComponent();
            this.bd = bd;
            id_editar = id;
            this.m = m;
            CarregarDados();
        }

        public f_clube(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            
        }

        // limpar form 

        private void LimparForm()
        {
            tb_nome.Text = "";
            tb_alcunha.Text = "";
            dtp_fundacao.Text = "";
            tb_estadio.Text = "";
            pb_logotipo.Image = null;
            tb_patrocinio.Text = "";
            n_ranking.Text = "";
            tb_presidente.Text = "";
        }


        private void tb_nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            clube novo = new clube(bd,"");
            if (id_editar == 0)
            {
                //criar um objeto do tipo livro
                //preencher os dados do livro
                novo.nome = tb_nome.Text;
                novo.alcunha = tb_alcunha.Text;
                novo.fundacao = (int)dtp_fundacao.Value.Year;
                novo.estadio = tb_estadio.Text;
                novo.patrocinio = tb_patrocinio.Text;
                novo.ranking = (int)n_ranking.Value; ;
                novo.presidente = tb_presidente.Text;
                novo.logotipo = Utils.PastaDoPrograma("M17A_Projeto") + @"\" + novo.nome;
                //validar os dados
                List<string> erros = novo.Validar();
                //se não tiver erros nos dados
                if (erros.Count > 0)
                {
                    //mostrar os erros
                    string mensagem = "";
                    foreach (string erro in erros)
                        mensagem += erro + "; ";
                    lb_feedback.Text = mensagem;
                    lb_feedback.ForeColor = Color.Red;
                    return;
                }
                //guardar na base de dados
                novo.Adicionar();
                //copiar a capa para a pasta do programa
                if (logotipo != "")
                {
                    if (System.IO.File.Exists(logotipo))
                        System.IO.File.Copy(logotipo, novo.logotipo, true);
                }
                //limpar o form
                LimparForm();
                //feedback user
                lb_feedback.Text = "Clube adicionado com sucesso.";
                lb_feedback.ForeColor = Color.Black;
                this.Close();
                menuclubes menu = new menuclubes(bd);
                menu.Show();

            }
            else
            {
                novo.id_clube = id_editar;
                novo.nome = tb_nome.Text;
                novo.alcunha = tb_alcunha.Text;
                novo.fundacao = (int)dtp_fundacao.Value.Year;
                novo.estadio = tb_estadio.Text;
                novo.patrocinio = tb_patrocinio.Text;
                novo.ranking = (int)n_ranking.Value;
                novo.presidente = tb_presidente.Text;
                novo.logotipo = logotipo;
                novo.Editar();
                this.Close();
                menuclubes menu = new menuclubes(bd);
                menu.Show();


            }

        }
        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            this.Hide();
            menuclubes menu = new menuclubes(bd);
            menu.Show();
        }

        // botao procurar
        private void button1_Click(object sender, EventArgs e)
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
                    pb_logotipo.Image = Image.FromFile(temp);
                    logotipo = temp;
                }
            }
        }
        private void CarregarDados()
        {
            DataTable dados = bd.DevolveSQL("SELECT * FROM clube WHERE id_clube=" + id_editar);

            if (dados.Rows.Count == 0) return;

            DataRow linha = dados.Rows[0];
            tb_nome.Text = linha["nome"].ToString();
            tb_alcunha.Text = linha["alcunha"].ToString();
            int ano = int.Parse(linha["fundacao"].ToString());
            dtp_fundacao.Value = new DateTime(ano, 1, 1);
            tb_estadio.Text = linha["estadio"].ToString();
            tb_patrocinio.Text = linha["patrocinio"].ToString();
            tb_presidente.Text = linha["presidente"].ToString();
        }
        private void Clube_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM clube WHERE id_clube=" + id_editar;
            DataTable temp = bd.DevolveSQL(sql);
            if (temp != null && temp.Rows.Count > 0)
            {
                DataRow linha = temp.Rows[0];
                tb_nome.Text = linha["nome"].ToString();
                tb_alcunha.Text = linha["alcunha"].ToString();
                int ano = int.Parse(linha["fundacao"].ToString());
                dtp_fundacao.Value = new DateTime(ano, 1, 1);
                tb_estadio.Text = linha["estadio"].ToString();
                tb_patrocinio.Text = linha["patrocinio"].ToString();
                tb_presidente.Text = linha["presidente"].ToString();
            }
        }
    }
}