using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M17.clube
{
    internal class Class1
    {
        public string nome { get; set; }
        public string alcunha { get; set; }
        public int fundacao { get; set; }
        public string estadio { get; set; }
        public string patrocinio { get; set; }

        public int ranking { get; set; }

        public string presidente { get; set; }

        public string logotipo { get; set; }

        public club()
        {
            InitializeComponent();
        }
        // botao cancelar
        private void button2_Click(object sender, EventArgs e)
        {
            LimparForm();
            bt_editar.Visible = false;
        }

        //botao guardar
        private void button4_Click(object sender, EventArgs e)
        {
            //criar um objeto do tipo livro
            club novo = new club(bd);
            //preencher os dados do livro
            novo.nome = tb_nome.Text;
            novo.alcunha = tb_alcunha.Text;
            novo.fundacao = int.Parse(dtp_fundacao.Text);
            novo.estadio = tb_estadio.Text;
            novo.patrocinio = tb_patrocinio.Text;
            novo.ranking = int.Parse(n_ranking.Text);
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
        public List<string> Validar()
        {
            List<string> erros = new List<string>();
            //validar titulo
            if (String.IsNullOrEmpty(nome) || nome.Length < 3)
            {
                erros.Add("O clube deve ter pelo menos 3 letras.");
            }
            //validar ano
            if (fundacao <= 0 || fundacao > DateTime.Now.Year)
            {
                erros.Add("O clube deve ter um ano de fundacao superior a 0 e inferior ao ano atual.");
            }
            return erros;
        }
    }
}
