using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace M17.clube
{
    internal class clube : IItem
    {
        public string nome { get; set; }
        public string alcunha { get; set; }
        public int fundacao { get; set; }
        public string estadio { get; set; }
        public string patrocinio { get; set; }
        public int ranking { get; set; }
        public string presidente { get; set; }
        public string logotipo { get; set; }

        public int id_clube { get; set; }
        BaseDados bd;
        string nomeselecionado;
        
        public clube(BaseDados bd , string clubeSelecionado)
        {
            this.bd=bd;
            this.nomeselecionado = clubeSelecionado;
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
        public DataTable Listar()
        {
            return bd.DevolveSQL("SELECT id_clube,nome,fundacao as [Ano de fundação],patrocinio,ranking,presidente from clube");
        }
        public override string ToString()
        {
            return this.nome;
        }

        public void Adicionar()
        {
            string sql = @"INSERT INTO Clube(nome,alcunha,fundacao,estadio,patrocinio,ranking,presidente,logotipo) VALUES 
                        (@nome,@alcunha,@fundacao,@estadio,@patrocinio,@ranking,@presidente,@logotipo)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@id_clube",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.id_clube
                },
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
                    SqlDbType=System.Data.SqlDbType.Int,
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
        public void Editar()
        {

            string sql = @"UPDATE Clube set nome=@nome,alcunha=@alcunha,fundacao=@fundacao,
                            estadio=@estadio,patrocinio=@patrocinio,ranking=@ranking,
                            presidente=@presidente,logotipo=@logotipo   
                            where id_clube=@id_clube";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@id_clube",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.id_clube
                },
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
                    SqlDbType=System.Data.SqlDbType.Int,
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
        public void Eliminar()
        {
            if (nomeselecionado == "")
            {
                MessageBox.Show("Tem de selecionar um clube primeiro.");
                return;
            }

            if (MessageBox.Show("Tem a certeza que pretende apagar o clube selecionado?",
                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clube apagar = new clube(bd,nomeselecionado);
                apagar.nome = nomeselecionado;
                apagar.Apagar();

                nomeselecionado = "";
                Listar();
            }
        }

        public void Apagar()
        {
            string sql = "DELETE FROM Clube WHERE nome=@nome";
            List<SqlParameter> parametros = new List<SqlParameter>()
        {
            new SqlParameter("@nome", this.nome)
        };
            bd.ExecutarSQL(sql, parametros);
        }
    }
}
