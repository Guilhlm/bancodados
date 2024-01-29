using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
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
            /* string[,] lista = { { "erick", "gusson" },{ "renon", "gusson" }, { "richard", "aderio" }, { "samuca", "pereira" },
              { "gustavo", "correia" }, { "pedro", "gaspar" }, { "gui", "lima" }, { "monique", "cristina" }, { "edilson", "arrow" } };

              for (int i = 0; i < 9; i++) // for (int i = 0; i < lista.length / 2 i++)
              {
                  Console.WriteLine(i);
                  Console.WriteLine(lista[i,1]);      
              }
              */

            string conexao = "server=localhost;user=root;passaword=;database=comida";

            using (MySqlConnection banco = new MySqlConnection(conexao))
            {
                banco.Open();

                string query = "Select * From comidas";

                using (MySqlCommand comando = new MySqlCommand(query, banco))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        reader.Read();

                        Console.WriteLine(reader["ID_COMIDA"]);
                        Console.WriteLine(reader["nome"]);
                        Console.WriteLine(reader["tipo"]);
                        Console.WriteLine(reader["temperatura"]);

                    }
                }



            }

            Console.ReadKey();
        }
    }
}
