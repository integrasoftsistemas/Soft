using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Funcoes
{
    public static class NavegacaoBD
    {
        public static string PrimeiroRegistro(string nomeColuna, string nomeTabela)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT MIN(").Append(nomeColuna).Append(") AS Primeiro ")
              .Append("FROM ").Append(nomeTabela).Append(" ")
              .Append("ORDER BY Primeiro DESC");

            string retorno = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr["Primeiro"] != DBNull.Value)
                            retorno = Convert.ToString(dr["Primeiro"]);
                    }
                }

                return retorno;
            }
            catch (SqlException sqlEx)
            {
                string msg = Mensagens.RetornaMsgSQLException(sqlEx);
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = Mensagens.RetornaMsgException(ex);
                throw new Exception(msg);
            }
        }

        public static string RegistroAnterior(string nomeColuna, string nomeTabela, int codigoAtual)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT MAX(").Append(nomeColuna).Append(") AS Anterior ")
              .Append("FROM ").Append(nomeTabela).Append(" ");

            if  (nomeTabela != "[PW~Usuarios]") 
            {
                sb.Append("WHERE ").Append(nomeColuna).Append(" < @").Append(nomeColuna).Append(" ");
            }
            else
            {                
                sb.Append("WHERE ").Append(nomeColuna).Append(" < ").Append(codigoAtual).Append(" ");
            }
            sb.Append("ORDER BY Anterior DESC");

            string retorno = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

                    if (nomeTabela != "[PW~Usuarios]")
                    {
                        cmd.Parameters.AddWithValue("@" + nomeColuna, codigoAtual);
                    }                        

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr["Anterior"] != DBNull.Value)
                            retorno = Convert.ToString(dr["Anterior"]);
                        else
                            retorno = codigoAtual.ToString();
                    }
                }
                return retorno;
            }
            catch (SqlException sqlEx)
            {
                string msg = Mensagens.RetornaMsgSQLException(sqlEx);
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = Mensagens.RetornaMsgException(ex);
                throw new Exception(msg);
            }
        }

        public static string ProximoRegistro(string nomeColuna, string nomeTabela, int codigoAtual)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT MIN(").Append(nomeColuna).Append(") AS Proximo ")
              .Append("FROM ").Append(nomeTabela).Append(" ");

            if (nomeTabela != "[PW~Usuarios]")
            {
                sb.Append("WHERE ").Append(nomeColuna).Append(" > @").Append(nomeColuna).Append(" ");
            }
            else
            {
                sb.Append("WHERE ").Append(nomeColuna).Append(" > ").Append(codigoAtual).Append(" ");
            }
            sb.Append("ORDER BY Proximo DESC");

            string retorno = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

                    if (nomeTabela != "[PW~Usuarios]")
                    {
                        cmd.Parameters.AddWithValue("@" + nomeColuna, codigoAtual);
                    }

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr["Proximo"] != DBNull.Value)
                            retorno = Convert.ToString(dr["Proximo"]);
                        else
                            retorno = codigoAtual.ToString();
                    }
                }
                return retorno;
            }
            catch (SqlException sqlEx)
            {
                string msg = Mensagens.RetornaMsgSQLException(sqlEx);
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = Mensagens.RetornaMsgException(ex);
                throw new Exception(msg);
            }
        }

        public static string UltimoRegistro(string nomeColuna, string nomeTabela)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT MAX(").Append(nomeColuna).Append(") AS Ultimo ")
              .Append("FROM ").Append(nomeTabela).Append(" ")
              .Append("ORDER BY Ultimo DESC");

            string retorno = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr["Ultimo"] != DBNull.Value)
                            retorno = Convert.ToString(dr["Ultimo"]);
                    }
                }
                return retorno;
            }
            catch (SqlException sqlEx)
            {
                string msg = Mensagens.RetornaMsgSQLException(sqlEx);
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = Mensagens.RetornaMsgException(ex);
                throw new Exception(msg);
            }
        }
    }
}
