using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.IdentityModel.Protocols;

namespace M17
{
    /// <summary>
    /// Responsável por executar comandos SQL na base de dados
    /// </summary>

    public class BaseDados
    {
        string strligacao;
        string NomeBD;
        string CaminhoBD;
        SqlConnection ligacaoSQL;


        //construtor
        // Estabelece a ligação à BD, caso não exista cria a BD
        public BaseDados(string NomeBD)
        {
            this.NomeBD = NomeBD;
            strligacao = System.Configuration.ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            // Verificar a pasta do projeto
            CaminhoBD = Utils.PastaDoPrograma("M17_Projeto");
            CaminhoBD += @"\" + NomeBD + ".mdf";
            // Verificar se a bd existe
            if (System.IO.File.Exists(CaminhoBD) == false)
            {
                // Se não existir
                // criar a bd
                //TODO: verificar se a bd existe no catálogo
                CriarBD();
            }
            // Ligação à BD
            ligacaoSQL = new SqlConnection(strligacao);
            ligacaoSQL.Open();
            ligacaoSQL.ChangeDatabase(this.NomeBD);
        }


        // desconstrutor
        BaseDados()
        {
            //fechar a ligação à bd
        }

        void CriarBD()
        {
            //ligação ao servidor
            ligacaoSQL = new SqlConnection(strligacao);
            ligacaoSQL.Open();

            // verificar se a bd já existe no catalogo
            string sql = $@"
                        IF EXISTS(SELECT * FROM master.sys.databases
                                      WHERE name='{this.NomeBD}')
                           BEGIN
                                USE [master]
                                EXEC sp_detach_db {this.NomeBD};
                            END
                        ";

            SqlCommand comando = new SqlCommand(sql, ligacaoSQL);
            comando.ExecuteNonQuery();

            //criar a bd
            sql = $"CREATE DATABASE {this.NomeBD} ON PRIMARY (NAME={this.NomeBD},FILENAME='{this.CaminhoBD}')";
            comando = new SqlCommand(sql, ligacaoSQL);
            comando.ExecuteNonQuery();
            // Associação a ligação à base de dados criada
            ligacaoSQL.ChangeDatabase(this.NomeBD);
            // criar as tabelas
            // criar tabela clube
            sql = @"CREATE TABLE Clube (
                    id_clube INT IDENTITY PRIMARY KEY,
                    nome VARCHAR(100) NOT NULL,
                    alcunha VARCHAR(100),
                    fundacao INT ,
                    estadio VARCHAR(150), 
                    patrocinio VARCHAR(150),
                    ranking INT,
                    presidente VARCHAR(100),
                    logotipo VARCHAR(500)
                    );

                CREATE TABLE Jogador (
                    idjogador INT IDENTITY PRIMARY KEY,
                    nome VARCHAR(150) NOT NULL,
                    data_nascimento DATE NOT NULL CHECK (data_nascimento < GETDATE()),
                    nacionalidade VARCHAR(100),
                    posicao VARCHAR(50),
                    nmr_camisola INT CHECK (nmr_camisola > 0),
                    clube VARCHAR(100) NOT NULL,
                    valor_mercado INT,
                    fotografia VARCHAR(500),
                    FOREIGN KEY (clube) REFERENCES Clube(nome)
                );

                
                ";

            //TODO: faltam as tabelas jogos e jogador
            comando = new SqlCommand(sql, ligacaoSQL);
            comando.ExecuteNonQuery();
            comando.Dispose();

        }

        // função para executar comando sql (insert/delete/update/create/alter...)
        public void ExecutarSQL(string sql, List<SqlParameter> parametros = null)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoSQL);
            if (parametros != null)
                comando.Parameters.AddRange(parametros.ToArray());
            comando.ExecuteNonQuery();
            comando.Dispose();
        }

        // função para executar um select e devolver os registos da bd
        public DataTable DevolveSQL(string sql, List<SqlParameter> parametros = null)
        {
            DataTable dados = new DataTable();
            SqlCommand comando = new SqlCommand(sql, ligacaoSQL);
            if (parametros != null)
                comando.Parameters.AddRange(parametros.ToArray());
            SqlDataReader registos = comando.ExecuteReader();
            dados.Load(registos);
            registos.Close();
            comando.Dispose();
            return dados;
        }


    }
}
