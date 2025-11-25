using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M17.clube
{
    public partial class club : Form 
    {
        public string nome { get ; set; }
        public string alcunha { get; set; }
        public int fundacao { get; set; }
        public string estadio { get; set; }
        public string patrocinio { get; set; }
        public int ranking { get; set; }
        public string presidente { get; set; }
        public string logotipo { get; set; }
        BaseDados bd;

        public club(BaseDados bd)
        {
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

        private void tb_nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_guardar_Click(object sender, EventArgs e)
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
        public void Adicionar()
        {
            string sql = @"INSERT INTO Livros(titulo,autor,editora,isbn,ano,data_aquisicao,preco,capa) VALUES 
                        (@titulo,@autor,@editora,@isbn,@ano,@data_aquisicao,@preco,@capa)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@alcunha",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.alcunha
                },
                new SqlParameter()
                {
                    ParameterName="@fundacao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.fundacao
                },
                new SqlParameter()
                {
                    ParameterName="@estadio",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.estadio
                },
                new SqlParameter()
                {
                    ParameterName="@patrocinio",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.patrocinio
                },
                new SqlParameter()
                {
                    ParameterName="@ranking",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ranking
                },
                new SqlParameter()
                {
                    ParameterName="@presidente",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.presidente
                },
                new SqlParameter()
                {
                    ParameterName="@logotipo",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.logotipo
                }
            };
            bd.ExecutarSQL(sql, parametros);
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {   
            LimparForm();
        }
    }
}