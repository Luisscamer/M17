using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace M17.jogador
{
    internal class Jogador
    {
        public string nome { get; set; }

        public DateTime data_nascimento { get; set; }

        public string nacionalidade { get; set; }

        public string posicao { get; set; }

        public int nmr_camisola { get; set; }

        public string clube { get; set; }

        public string valor_mercado { get; set; }

        public string fotografia { get; set; }

        public int id_jogador { get; set; }

        BaseDados bd;
        int id_selecionado;

        public Jogador(BaseDados bd)
        {
            this.bd = bd;
            id_selecionado = 0;
        }
        public List<string> Validar()
        {
            List<string> erros = new List<string>();
            //validar titulo
            if (String.IsNullOrEmpty(nome) || nome.Length < 3)
            {
                erros.Add("O nome do jogador deve ter pelo menos 3 letras.");
            }
            //validar ano
            if (data_nascimento > DateTime.Now)
            {
                erros.Add("O jogador deve ter uma data de nascimento diferente da data atual.");
            }
            return erros;
        }
        public DataTable Listar()
        {
            return bd.DevolveSQL("SELECT id_jogador,nome,data_nascimento,nacionalidade,posicao,nmr_camisola,clube,valor_mercado,fotografia from jogador");
        }
        public override string ToString()
        {
            return this.nome;
        }
        public void Adicionar()
        {
            string sql = @"INSERT INTO Jogador
                  (nome, data_nascimento, nacionalidade, posicao, nmr_camisola, clube, valor_mercado, fotografia)
                  VALUES
                  (@nome, @data_nascimento, @nacionalidade, @posicao, @nmr_camisola, @clube, @valor_mercado, @fotografia)";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = SqlDbType.VarChar,
                    Value = this.nome
                },
                new SqlParameter()
                {
                    ParameterName = "@data_nascimento",
                    SqlDbType = SqlDbType.Date,
                    Value = this.data_nascimento
                },
                new SqlParameter()
                {
                    ParameterName = "@nacionalidade",
                    SqlDbType = SqlDbType.VarChar,
                    Value = this.nacionalidade
                },
                new SqlParameter()
                {
                    ParameterName = "@posicao",
                    SqlDbType = SqlDbType.VarChar,
                    Value = this.posicao
                },
                new SqlParameter()
                {
                    ParameterName = "@nmr_camisola",
                    SqlDbType = SqlDbType.Int,
                    Value = this.nmr_camisola
                },
                new SqlParameter()
                {
                    ParameterName = "@clube",
                    SqlDbType = SqlDbType.VarChar,
                    Value = this.clube
                },
                new SqlParameter()
                {
                    ParameterName = "@valor_mercado",
                    SqlDbType = SqlDbType.Int,
                    Value = this.valor_mercado
                },
                new SqlParameter()
                {
                    ParameterName = "@fotografia",
                    SqlDbType = SqlDbType.VarChar,
                    Value = this.fotografia
                }
            };

            bd.ExecutarSQL(sql, parametros);
        }

        public void Editar()
        {
            string sql = @"UPDATE Jogador SET
                    nome = @nome,
                    data_nascimento = @data_nascimento,
                    nacionalidade = @nacionalidade,
                    posicao = @posicao,
                    nmr_camisola = @nmr_camisola,
                    clube = @clube,
                    valor_mercado = @valor_mercado,
                    fotografia = @fotografia
                   WHERE id_jogador = @id_jogador";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = SqlDbType.VarChar,
                    Value = this.nome
                },
                new SqlParameter()
                {
                    ParameterName = "@data_nascimento",
                    SqlDbType = SqlDbType.Date,
                    Value = this.data_nascimento
                },
                new SqlParameter()
                {
                    ParameterName = "@nacionalidade",
                    SqlDbType = SqlDbType.VarChar,
                    Value = this.nacionalidade
                },
                new SqlParameter()
                {
                    ParameterName = "@posicao",
                    SqlDbType = SqlDbType.VarChar,
                    Value = this.posicao
                },
                new SqlParameter()
                {
                    ParameterName = "@nmr_camisola",
                    SqlDbType = SqlDbType.Int,
                    Value = this.nmr_camisola
                },
                new SqlParameter()
                {
                    ParameterName = "@clube",
                    SqlDbType = SqlDbType.VarChar,
                    Value = this.clube
                },
                new SqlParameter()
                {
                    ParameterName = "@valor_mercado",
                    SqlDbType = SqlDbType.Int,
                    Value = this.valor_mercado
                },
                new SqlParameter()
                {
                    ParameterName = "@fotografia",
                    SqlDbType = SqlDbType.VarChar,
                    Value = this.fotografia
                }
            };

            bd.ExecutarSQL(sql, parametros);
        }
        public void Apagar()
        {
            string sql = "DELETE FROM Jogador WHERE id_jogador = @id_jogador";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@id_jogador",
                    SqlDbType = SqlDbType.Int,
                    Value = this.id_jogador
                }
            };

            bd.ExecutarSQL(sql, parametros);
        }
        public void Eliminar()
        {
            if (id_selecionado <= 0)
            {
                MessageBox.Show("Tem de selecionar um jogador primeiro.");
                return;
            }

            if (MessageBox.Show("Tem a certeza que pretende eliminar o jogador selecionado?",
                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Jogador apagar = new Jogador(bd);
                apagar.id_jogador = id_selecionado;
                apagar.Apagar();

                id_selecionado = 0; // limpar seleção

                MessageBox.Show("Jogador apagado com sucesso.");
            }
        }

    }
}
