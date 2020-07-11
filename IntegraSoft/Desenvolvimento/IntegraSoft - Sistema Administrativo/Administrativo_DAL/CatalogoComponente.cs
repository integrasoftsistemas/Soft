using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo_DAL
{
    public class CatalogoComponente
    {
        public int Update_CheckedFalso(Administrativo_Entities.CatalogoComponente catalogocomponente)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE CatalogoComponente SET cacoChecked = 0");
            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    //cmd.Parameters.AddWithValue("@cacoChecked", catalogocomponente.cacoChecked);
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

        public int Delete_CheckedFalso(Administrativo_Entities.CatalogoComponente catalogocomponente)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM CatalogoComponente WHERE cacoChecked = 0");
            //sb.Append("DELETE FROM CatalogoComponente ")
            //  .Append("FROM CatalogoComponente INNER JOIN ")
            //  .Append("CatalogoFormulario ON CatalogoComponente.cacoIDForm = CatalogoFormulario.cafoID ")
            //  .Append("WHERE (CatalogoComponente.cacoChecked = 0) OR (CatalogoFormulario.cafoNomeMenuAcesso IS NULL)");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    //cmd.Parameters.AddWithValue("", catalogocomponente.cacoChecked);
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

        public int InsertUpdate(Administrativo_Entities.CatalogoComponente catalogocomponente)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("DECLARE @ID INT = NULL; ")
              .Append("\r\n ")
              .Append("\r\nSELECT @ID = cacoID FROM CatalogoComponente WHERE cacoIDForm = @cacoIDForm AND cacoNomeComponente = @cacoNomeComponente ")
              .Append("\r\n ")
              .Append("\r\n  IF @ID IS NULL ")
              .Append("\r\n     BEGIN ")
              .Append("\r\n     --  COLOCAR COMANDO INSERT ")
              .Append("\r\n         INSERT INTO CatalogoComponente ")
              .Append("\r\n         (cacoIDForm, cacoNomeComponente, cacoNomeAmigavel, cacoChecked) ")
              .Append("\r\n         VALUES(@cacoIDForm, @cacoNomeComponente, @cacoNomeAmigavel, @cacoChecked) ")
              .Append("\r\n         SELECT @@IDENTITY")
              .Append("\r\n     END ")
              .Append("\r\n  ELSE ")
              .Append("\r\n     BEGIN ")
              .Append("\r\n     --  COLOCAR COMANDO UPDATE ")
              .Append("\r\n         UPDATE CatalogoComponente SET cacoNomeAmigavel = @cacoNomeAmigavel, cacoChecked = 1 WHERE cacoID = @ID ")
              .Append("\r\n         SELECT @ID")
              .Append("\r\n     END ");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@cacoIDForm", catalogocomponente.cacoIDForm);
                    cmd.Parameters.AddWithValue("@cacoNomeComponente", catalogocomponente.cacoNomeComponente);
                    cmd.Parameters.AddWithValue("@cacoNomeAmigavel", catalogocomponente.cacoNomeAmigavel);
                    cmd.Parameters.AddWithValue("@cacoChecked", catalogocomponente.cacoChecked);

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

        public List<Administrativo_Entities.CatalogoComponente> LerConteudo()
        {
            List<Administrativo_Entities.CatalogoComponente> listaCF = null;
            Administrativo_Entities.CatalogoComponente cf = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM CatalogoComponente ORDER BY cacoIDForm, cacoNomeAmigavel");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cf = new Administrativo_Entities.CatalogoComponente();
                        cf.cacoID = Convert.ToInt32(dr["cacoID"]);
                        cf.cacoIDForm = Convert.ToInt32(dr["cacoIDForm"]);
                        cf.cacoNomeComponente = dr["cacoNomeComponente"].ToString();
                        cf.cacoNomeAmigavel = dr["cacoNomeAmigavel"].ToString();

                        if (listaCF == null)
                            listaCF = new List<Administrativo_Entities.CatalogoComponente>();

                        listaCF.Add(cf);
                    }

                    return listaCF;
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

        public List<Administrativo_Entities.CatalogoFormulario> RetornarTodosFormulariosComponentes()
        {
            List<Administrativo_Entities.CatalogoFormulario> listaCF = null;
            Administrativo_Entities.CatalogoFormulario cf = null;

            List<Administrativo_Entities.CatalogoComponente> listaCC = null;
            Administrativo_Entities.CatalogoComponente cc = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM CatalogoFormulario; ")
              .Append("SELECT * FROM CatalogoComponente;");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cf = new Administrativo_Entities.CatalogoFormulario();
                        cf.cafoID = Convert.ToInt32(dr["cafoID"]);
                        cf.cafoNomeFormulario = dr["cafoNomeFormulario"].ToString();
                        cf.cafoNomeAmigavel = dr["cafoNomeAmigavel"].ToString();
                        cf.cafoNomeFullFormulario = dr["cafoNomeFullFormulario"].ToString();
                        cf.cafoChecked = Convert.ToBoolean(dr["cafoChecked"]);

                        if (listaCF == null)
                            listaCF = new List<Administrativo_Entities.CatalogoFormulario>();

                        listaCF.Add(cf);
                    }

                    dr.NextResult();

                    while (dr.Read())
                    {
                        cc = new Administrativo_Entities.CatalogoComponente();
                        cc.cacoID = Convert.ToInt32(dr["cacoID"]);
                        cc.cacoIDForm = Convert.ToInt32(dr["cacoIDForm"]);
                        cc.cacoNomeComponente = dr["cacoNomeComponente"].ToString();
                        cc.cacoNomeAmigavel = dr["cacoNomeAmigavel"].ToString();

                        if (listaCC == null)
                            listaCC = new List<Administrativo_Entities.CatalogoComponente>();

                        listaCC.Add(cc);
                    }

                    dr.Close();
                }

                foreach (var form in listaCF)
                {
                    var filtro = listaCC.Where(comp => comp.cacoIDForm == form.cafoID);
                    foreach (var componente in filtro)
                    {
                        form.CatalogoComponente.Add(componente);
                    }
                }

                return listaCF;
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

        public List<Administrativo_Entities.CatalogoComponente> RetornaListaAcessoNegadoPermissaoComponente(int IDUsuario, string NomeFormulario)
        {
            List<Administrativo_Entities.CatalogoComponente> listaCC = null; // listaCC onde adiciona os itens
            Administrativo_Entities.CatalogoComponente cc = null; // cc é objeto é o item

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT CatalogoComponente.cacoNomeComponente ")
               .Append("FROM CatalogoPermissaoUsuario INNER JOIN ")
               .Append("CatalogoComponente ON CatalogoPermissaoUsuario.capeusIDComponente = CatalogoComponente.cacoID INNER JOIN ")
               .Append("CatalogoFormulario ON CatalogoComponente.cacoIDForm = CatalogoFormulario.cafoID ")
               .Append("WHERE (CatalogoPermissaoUsuario.capeusIDPWUsuario = @capeusIDPWUsuario) AND (CatalogoFormulario.cafoNomeFormulario = @cafoNomeFormulario) AND (CatalogoPermissaoUsuario.capeusPermissao = 0)");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@capeusIDPWUsuario", IDUsuario);
                    cmd.Parameters.AddWithValue("@cafoNomeFormulario", NomeFormulario);

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        // instâncio aqui
                        cc = new Administrativo_Entities.CatalogoComponente();

                        if (dr["cacoNomeComponente"] != DBNull.Value)
                            cc.cacoNomeComponente = dr["cacoNomeComponente"].ToString();

                        if (listaCC == null)
                            // instâncio
                            listaCC = new List<Administrativo_Entities.CatalogoComponente>();

                        // adiciono
                        listaCC.Add(cc);
                    }

                    return listaCC;
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


    }
}
