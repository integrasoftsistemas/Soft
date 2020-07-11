using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo_DAL
{
    public class CatalogoFormulario
    {
        //    // Isso aqui foi colocado dentro do método VerificaNomeFormulario
        //    public int Incluir(Administrativo_Entities.CatalogoFormulario catalogoformulario)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("INSERT INTO CatalogoFormulario ")
        //          .Append("(cafoNomeFormulario, cafoNomeAmigavel, cafoNomeFullFormulario, cafoChecked) ")
        //          .Append("VALUES(@cafoNomeFormulario, @cafoNomeAmigavel, @cafoNomeFullFormulario, @cafoChecked)");

        //        try
        //        {
        //            using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
        //            {
        //                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
        //                cmd.Parameters.AddWithValue("@cafoNomeFormulario", catalogoformulario.cafoNomeFormulario);
        //                cmd.Parameters.AddWithValue("@cafoNomeAmigavel", catalogoformulario.NomeAmigavel);
        //                cmd.Parameters.AddWithValue("@cafoNomeFullFormulario", catalogoformulario.NomeFullFormulario);
        //                cmd.Parameters.AddWithValue("@cafoChecked", catalogoformulario.cafoChecked);

        //                conn.Open();

        //                return Convert.ToInt32(cmd.ExecuteScalar());
        //            }
        //        }
        //        catch (SqlException)
        //        {
        //            throw;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }

        public int Update_CheckedFalso(Administrativo_Entities.CatalogoFormulario catalogoformulario)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE CatalogoFormulario SET cafoChecked = 0");
            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    //cmd.Parameters.AddWithValue("@cafoChecked", catalogoformulario.cafoChecked);
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

        public int Delete_CheckedFalso(Administrativo_Entities.CatalogoFormulario catalogoformulario)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM CatalogoFormulario WHERE cafoChecked = 0");
            //sb.Append("DELETE FROM CatalogoFormulario WHERE (cafoChecked = 0) OR (cafoNomeMenuAcesso IS NULL)");
            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    //cmd.Parameters.AddWithValue("@cafoChecked", catalogoformulario.cafoChecked);
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

        //public Administrativo_Entities.CatalogoFormulario Pesquisar(int ID, string strForm)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("SELECT cafoID ")
        //      .Append("FROM CatalogoFormulario ")
        //      .Append("WHERE cafoNomeFormulario = @strForm ");

        //    return ID;
        //}


        //public int VerificaNomeFormulario(string NomeFormulario)
        public int InsertUpdate(Administrativo_Entities.CatalogoFormulario catalogoformulario)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("IF not EXISTS ")            
            //  .Append("\r\n     (SELECT cafoID FROM CatalogoFormulario WHERE cafoNomeFormulario = @cafoNomeFormulario) ")
            //  .Append("\r\n     BEGIN ")
            //  .Append("\r\n         INSERT INTO CatalogoFormulario ")
            //  .Append("\r\n         (cafoNomeFormulario, cafoNomeAmigavel, cafoNomeFullFormulario, cafoChecked) ")
            //  .Append("\r\n         VALUES(@cafoNomeFormulario, @cafoNomeAmigavel, @cafoNomeFullFormulario, @cafoChecked) ")
            //  .Append("\r\n     END ")
            //  .Append("\r\nELSE ")
            //  .Append("\r\n     BEGIN ")
            //  .Append("\r\n         UPDATE CatalogoFormulario SET cafoChecked = 1 WHERE cafoID = (SELECT cafoID FROM CatalogoFormulario WHERE cafoNomeFormulario = @cafoNomeFormulario) ")
            //  .Append("\r\n     END");

            sb.Append("DECLARE @ID INT = NULL; ")
              .Append("\r\n ")
              .Append("\r\nSELECT @ID = cafoID FROM CatalogoFormulario WHERE cafoNomeFormulario = @cafoNomeFormulario ")
              .Append("\r\n ")
              .Append("\r\n  IF @ID IS NULL ")
              .Append("\r\n     BEGIN ")
              .Append("\r\n     --  COLOCAR COMANDO INSERT ")
              .Append("\r\n         INSERT INTO CatalogoFormulario ")
              .Append("\r\n         (cafoNomeFormulario, cafoNomeAmigavel, cafoNomeFullFormulario, cafoNomeMenuAcesso, cafoChecked) ")
              .Append("\r\n         VALUES(@cafoNomeFormulario, @cafoNomeAmigavel, @cafoNomeFullFormulario, @cafoNomeMenuAcesso, @cafoChecked) ")
              .Append("\r\n         SELECT @@IDENTITY")
              .Append("\r\n     END ")
              .Append("\r\n  ELSE ")
              .Append("\r\n     BEGIN ")
              .Append("\r\n     --  COLOCAR COMANDO UPDATE ")
              .Append("\r\n         UPDATE CatalogoFormulario SET cafoChecked = 1, cafoNomeAmigavel = @cafoNomeAmigavel, cafoNomeMenuAcesso = @cafoNomeMenuAcesso WHERE cafoID = @ID ")
              .Append("\r\n         SELECT @ID")
              .Append("\r\n     END ");
            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@cafoNomeFormulario", catalogoformulario.cafoNomeFormulario);
                    cmd.Parameters.AddWithValue("@cafoNomeAmigavel", catalogoformulario.cafoNomeAmigavel);
                    cmd.Parameters.AddWithValue("@cafoNomeFullFormulario", catalogoformulario.cafoNomeFullFormulario);

                    if (catalogoformulario.cafoNomeMenuAcesso == null)
                        cmd.Parameters.AddWithValue("@cafoNomeMenuAcesso ", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@cafoNomeMenuAcesso ", catalogoformulario.cafoNomeMenuAcesso);

                    cmd.Parameters.AddWithValue("@cafoChecked", catalogoformulario.cafoChecked);

                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    return Convert.ToInt32(cmd.ExecuteScalar());

                    // return Convert.ToInt32(cmd.ExecuteNonQuery());
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

        public List<Administrativo_Entities.CatalogoFormulario> LerConteudo()
        {
            List<Administrativo_Entities.CatalogoFormulario> listaCF = null;
            Administrativo_Entities.CatalogoFormulario cf = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from CatalogoFormulario order by cafoNomeFormulario");

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
                        cf.cafoNomeMenuAcesso = dr["cafoNomeMenuAcesso"].ToString();
                        cf.cafoChecked = Convert.ToBoolean(dr["cafoChecked"]);

                        if (listaCF == null)
                            listaCF = new List<Administrativo_Entities.CatalogoFormulario>();

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
            sb.Append("SELECT * FROM CatalogoFormulario order by cafoNomeAmigavel; ")
              .Append("SELECT * FROM CatalogoComponente order by cacoNomeAmigavel;");

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
                        cf.cafoNomeMenuAcesso = dr["cafoNomeMenuAcesso"].ToString();
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
        
        public bool RetornaAcessoMenu(string NomeMenuAcesso, int IDUsuario)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT CatalogoFormulario.cafoNomeMenuAcesso ")
              .Append("FROM CatalogoFormulario INNER JOIN ")
              .Append("CatalogoComponente ON CatalogoFormulario.cafoID = CatalogoComponente.cacoIDForm INNER JOIN ")
              .Append("CatalogoPermissaoUsuario ON CatalogoComponente.cacoID = CatalogoPermissaoUsuario.capeusIDComponente ")
              .Append("WHERE (CatalogoFormulario.cafoNomeMenuAcesso = @cafoNomeMenuAcesso) AND (CatalogoPermissaoUsuario.capeusIDPWUsuario = @capeusIDPWUsuario) ")
              .Append("AND (CatalogoPermissaoUsuario.capeusPermissao = 1)");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@cafoNomeMenuAcesso", NomeMenuAcesso);
                    cmd.Parameters.AddWithValue("@capeusIDPWUsuario", IDUsuario);
                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public List<Administrativo_Entities.CatalogoFormulario> RetornaListaAcessoMenu(int IDUsuario)
        {
            List<Administrativo_Entities.CatalogoFormulario> listCF = null; // listaCF onde adiciona os itens
            Administrativo_Entities.CatalogoFormulario cf = null; // cf é objeto é o item

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT distinct CatalogoFormulario.cafoNomeMenuAcesso, CatalogoFormulario.cafoNomeFormulario ")
              .Append("FROM CatalogoFormulario INNER JOIN ")
              .Append("CatalogoComponente ON CatalogoFormulario.cafoID = CatalogoComponente.cacoIDForm INNER JOIN ")
              .Append("CatalogoPermissaoUsuario ON CatalogoComponente.cacoID = CatalogoPermissaoUsuario.capeusIDComponente ")
              .Append("WHERE (CatalogoFormulario.cafoNomeMenuAcesso is not null) AND (CatalogoPermissaoUsuario.capeusIDPWUsuario = @capeusIDPWUsuario) ")
              .Append("AND (CatalogoPermissaoUsuario.capeusPermissao = 1)");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@capeusIDPWUsuario", IDUsuario);
                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        // instâncio aqui
                        cf = new Administrativo_Entities.CatalogoFormulario();

                        // aqui vamos achar qual é o formulário clicado
                        if (dr["cafoNomeMenuAcesso"] != DBNull.Value)
                            cf.cafoNomeMenuAcesso = dr["cafoNomeMenuAcesso"].ToString();



                        if (listCF == null)
                            // instâncio
                            listCF = new List<Administrativo_Entities.CatalogoFormulario>();

                        // adiciono
                        listCF.Add(cf);
                    }

                    return listCF;
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

