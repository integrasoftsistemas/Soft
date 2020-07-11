using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo_DAL
{
    public class Usuario
    {
        public int Incluir(Administrativo_Entities.Usuario usuario)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO Login (logNome, logSenha, logLogin, logEmail, logDataCadastro, logAtivo) ")
              .Append("VALUES (@PW_Nome, @PW_Senha, @PW_Login, @PW_Email, @PW_DataCadastro, @PW_Ativo) ")
              .Append("SELECT @@IDENTITY");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@PW_Nome", usuario.PW_Nome);
                    cmd.Parameters.AddWithValue("@PW_Senha", usuario.PW_Senha);
                    cmd.Parameters.AddWithValue("@PW_Login", usuario.PW_Login);
                    cmd.Parameters.AddWithValue("@PW_Email", usuario.PW_Email);
                    cmd.Parameters.AddWithValue("@PW_DataCadastro", usuario.PW_DataCadastro);
                    cmd.Parameters.AddWithValue("@PW_Ativo", usuario.PW_Ativo);

                    conn.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Alterar(Administrativo_Entities.Usuario usuario)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Login SET ")
              .Append("logNome = @PW_Nome, ")
              .Append("logSenha = @PW_Senha, ")
              .Append("logLogin = @PW_Login, ")
              .Append("logEmail = @PW_Email, ")
              .Append("logDataCadastro = @PW_DataCadastro, ")
              .Append("logAtivo = @PW_Ativo ")
              .Append("WHERE [logID] = @PW_ID");
            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@PW_ID", usuario.PW_ID);
                    cmd.Parameters.AddWithValue("@PW_Nome", usuario.PW_Nome);
                    cmd.Parameters.AddWithValue("@PW_Senha", usuario.PW_Senha);
                    cmd.Parameters.AddWithValue("@PW_Login", usuario.PW_Login);
                    cmd.Parameters.AddWithValue("@PW_Email", usuario.PW_Email);
                    cmd.Parameters.AddWithValue("@PW_DataCadastro", usuario.PW_DataCadastro);
                    cmd.Parameters.AddWithValue("@PW_Ativo", usuario.PW_Ativo);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteNonQuery());
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Excluir(int PW_ID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM Login ")
              .Append("WHERE [logID] = @PW_ID");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@PW_ID", PW_ID);

                    conn.Open();

                    return Convert.ToInt32(cmd.ExecuteNonQuery());
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Administrativo_Entities.Usuario AutenticarUsuario(string login, string senha)
        {
            Administrativo_Entities.Usuario usuario = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ")
              .Append("FROM Login ")
              .Append("WHERE logLogin = @login AND logSenha = @senha");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        usuario = new Administrativo_Entities.Usuario();
                        usuario.PW_ID = Convert.ToInt32(dr["logID"]);
                        usuario.PW_Login = dr["logLogin"].ToString();
                        usuario.PW_Ativo = Convert.ToBoolean(dr["logAtivo"]);
                        usuario.PW_Nome = dr["logNome"].ToString();
                        usuario.PW_Email = dr["logEmail"].ToString();
                        usuario.PW_Senha = dr["logSenha"].ToString();
                        usuario.PW_DataCadastro = Convert.ToDateTime(dr["logDataCadastro"]);
                    }
                }
                return usuario;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Verifica_Qtd_Usuarios()
        {
            int Qtde = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT count(*) as Qtde_na_Tabela ")
              .Append("FROM Login ");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

                    conn.Open();

                    Qtde = cmd.ExecuteNonQuery();                  
                }   
                return Qtde;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Administrativo_Entities.Usuario Pesquisar(int PW_ID = 0)
        {
            Administrativo_Entities.Usuario usuario = null;

            StringBuilder sb = new StringBuilder();

            if (PW_ID == 0)                
                sb.Append("SELECT TOP 1 [logID] As Ultimo, [logID], logNome, logSenha, logLogin, logEmail, logDataCadastro, logAtivo ")
                  .Append("FROM Login ")
                  .Append("ORDER BY Ultimo DESC");
            else
                sb.Append("SELECT [logID], logNome, logSenha, logLogin, logEmail, logDataCadastro, logAtivo ")
                  .Append("FROM Login ")
                  .Append("WHERE [logID] = @PW_ID");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@PW_ID", PW_ID);

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        usuario = new Administrativo_Entities.Usuario();

                        if (dr["logID"] != DBNull.Value)
                            usuario.PW_ID = Convert.ToInt32(dr["logID"]);

                        if (dr["logNome"] != DBNull.Value)
                            usuario.PW_Nome = dr["logNome"].ToString();

                        if (dr["logSenha"] != DBNull.Value)
                            usuario.PW_Senha = dr["logSenha"].ToString();

                        if (dr["logLogin"] != DBNull.Value)
                            usuario.PW_Login = dr["logLogin"].ToString();

                        if (dr["logEmail"] != DBNull.Value)
                            usuario.PW_Email = dr["logEmail"].ToString();

                        if (dr["logDataCadastro"] != DBNull.Value)
                            usuario.PW_DataCadastro = Convert.ToDateTime(dr["logDataCadastro"]);

                        if (dr["logAtivo"] != DBNull.Value)
                            usuario.PW_Ativo = Convert.ToBoolean(dr["logAtivo"]);
                    }
                }
                return usuario;
            }

            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Administrativo_Entities.Usuario PesquisarRegistroAposExclusao(int PW_ID)
        {
            bool bolEncontrou = false;
            Administrativo_Entities.Usuario usuario = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT TOP 1 ([logID]) AS Ultimo, * ")
              .Append("FROM Login ")
              .Append("WHERE [logID] < @PW_ID ")
              .Append("ORDER BY Ultimo DESC");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@PW_ID", PW_ID);

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        usuario = new Administrativo_Entities.Usuario();

                        if (dr["logID"] != DBNull.Value)
                            usuario.PW_ID = Convert.ToInt32(dr["logID"]);

                        bolEncontrou = true;
                    }

                    if (bolEncontrou)
                        return usuario;

                    dr.Close();

                    sb.Clear();
                    sb.Append("SELECT TOP 1 ([logID]) AS Ultimo, * ")
                      .Append("FROM Login ")
                      .Append("WHERE [logID] < @PW_ID ")
                      .Append("ORDER BY Ultimo ASC");

                    cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@PW_ID", PW_ID);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        usuario = new Administrativo_Entities.Usuario();

                        if (dr["logID"] != DBNull.Value)
                            usuario.PW_ID = Convert.ToInt32(dr["logID"]);
                    }
                }
                return usuario;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Administrativo_Entities.Usuario> CarregarGrid(string strWhere)
        {
            List<Administrativo_Entities.Usuario> listausuario = new List<Administrativo_Entities.Usuario>();
            Administrativo_Entities.Usuario usuario = null;

            if (!string.IsNullOrWhiteSpace(strWhere))
                strWhere = " WHERE " + strWhere;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT [logID], logNome, logLogin FROM Login ")
              .Append("" + strWhere + " ")
              .Append("ORDER BY logNome");

            using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
            {
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        usuario = new Administrativo_Entities.Usuario();

                        if (dr["logID"] != DBNull.Value)
                            usuario.PW_ID = Convert.ToInt32(dr["logID"]);

                        if (dr["logNome"] != DBNull.Value)
                            usuario.PW_Nome = IS_Funcoes.SegurancaCripto.Descriptografar(dr["logNome"].ToString());

                        if (dr["logLogin"] != DBNull.Value)
                            usuario.PW_Login = IS_Funcoes.SegurancaCripto.Descriptografar(dr["logLogin"].ToString());

                        if (listausuario == null)
                            listausuario = new List<Administrativo_Entities.Usuario>();

                        listausuario.Add(usuario);
                    }

                    return listausuario;
                }
                catch (SqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DataTable CarregarGrid_DT(string strWhere)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PW_ID", typeof(int));
            dt.Columns.Add("PW_Nome", typeof(string));
            dt.Columns.Add("PW_Login", typeof(string));

            if (!string.IsNullOrWhiteSpace(strWhere))
                strWhere = " WHERE " + strWhere;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT [logID], logNome, logLogin FROM Login ")
              .Append("" + strWhere + " ")
              .Append("ORDER BY logNome");

            using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
            {
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

                try
                {
                    conn.Open();
                    SqlDataReader sql_DR = cmd.ExecuteReader();

                    while (sql_DR.Read())
                    {
                        DataRow dr = dt.NewRow();

                        if (sql_DR["logID"] != DBNull.Value)
                            dr["PW_ID"] = Convert.ToInt32(sql_DR["logID"]);

                        if (sql_DR["logNome"] != DBNull.Value)
                            dr["PW_Nome"] = IS_Funcoes.SegurancaCripto.Descriptografar(sql_DR["logNome"].ToString());

                        if (sql_DR["logLogin"] != DBNull.Value)
                            dr["PW_Login"] = IS_Funcoes.SegurancaCripto.Descriptografar(sql_DR["logLogin"].ToString());

                        dt.Rows.Add(dr);
                    }

                    return dt;
                }
                catch (SqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


    }
}
