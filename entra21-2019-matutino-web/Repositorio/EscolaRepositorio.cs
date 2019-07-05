﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class EscolaRepositorio
    {
        Conexao conexao = new Conexao();



        public int Inserir(Escola escola)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO escola (nome) VALUES (@NOME)";
            comando.Parameters.AddWithValue("@NOME", escola.Nome);

            int id = Convert.ToInt32(comando.ExecuteScalar());

            comando.Connection.Close();

            return id;
        }
        public List<Escola> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM escola WHERE nome LIKE @BUSCA";
            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@BUSCA", busca);

            List<Escola>escolas = new List<Escola>();
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                Escola escola = new Escola();

               escola.Id = Convert.ToInt32(linha["id"]);
               escola.Nome = linha["nome"].ToString();
               escolas.Add(escola);
            }
            return escolas;
        }
    }
}
