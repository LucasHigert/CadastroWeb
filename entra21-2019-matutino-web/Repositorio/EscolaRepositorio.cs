using Model;
using System;
using System.Collections.Generic;
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
    }
}
