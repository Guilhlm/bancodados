using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancodados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conexao = "server=localhost;user=root;passaword=;database=comida";
       
            while (true)
            {
                Console.WriteLine("escolha uma das opçoes");
                Console.WriteLine("consultar = 1");
                Console.WriteLine("criar = 2");
                Console.WriteLine("sair = 3");

                string escolha = Console.ReadLine();

                if(escolha == "1")
                {
                    funcao_banco(conexao);
                }
                if (escolha == "2")
                {
                    consultarfuncao_bancos(conexao);
                }
                if (escolha == "3")
                {
                    break;        
                }
                else
                {
                    Console.Write("error");
                }
            }
        }

        private static void consultarfuncao_bancos(string conexao)
        {
            using (MySqlConnection cadastrar = new MySqlConnection(conexao))
            {
                try
                {
                    string query = "INSERT INTO comidas (nome, tipo, temperatura) VALUE (@nome, @tipo, @temperatura);";

                    using (MySqlCommand comando = new MySqlCommand(query, cadastrar))
                    {
                        cadastrar.Open();

                        Console.WriteLine("digite o nome");

                        string nome = Console.ReadLine();

                        Console.WriteLine("digite o tipo");

                        string tipo = Console.ReadLine();

                        Console.WriteLine("digite a temperatura");

                        string temperatura = Console.ReadLine();

                       

                        comando.Parameters.AddWithValue("@nome", nome);
                        comando.Parameters.AddWithValue("@tipo", tipo);
                        comando.Parameters.AddWithValue("@temperatura", temperatura);

                        comando.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } 
        }

        private static void funcao_banco(string conexao )
        {
            using (MySqlConnection banco = new MySqlConnection(conexao))
            {
                banco.Open();

                string query = "Select * From comidas";

                using (MySqlCommand comando = new MySqlCommand(query, banco))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["nome"]);
                            Console.WriteLine(reader["tipo"]);
                            Console.WriteLine(reader["temperatura"]);
                            Console.WriteLine(reader["ID_comida"]);
                        }      
                    }
                }

                Console.ReadKey();
            }
        }
    }
}
