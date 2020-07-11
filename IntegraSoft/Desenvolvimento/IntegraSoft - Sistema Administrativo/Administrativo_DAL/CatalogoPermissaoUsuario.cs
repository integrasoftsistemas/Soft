using SmartSolutions.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Administrativo_DAL
{
    public class CatalogoPermissaoUsuario
    {
        public int Delete_CheckedFalso(Administrativo_Entities.CatalogoPermissaoUsuario catalogopermissaousuario)
        {
            StringBuilder sb = new StringBuilder();            
            sb.Append("DELETE FROM CatalogoPermissaoUsuario ") 
              .Append("FROM CatalogoPermissaoUsuario INNER JOIN ")
              .Append("CatalogoComponente ON CatalogoPermissaoUsuario.capeusIDComponente = CatalogoComponente.cacoID ")
              .Append("WHERE (CatalogoComponente.cacoChecked = 0)");
            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    //cmd.Parameters.AddWithValue("@capeusChecked", catalogopermissaousuario.capeusChecked);
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

        public List<Administrativo_Entities.CatalogoPermissaoUsuario> PreencheAcessoPermissaoUsuario(int idUsuario)
        {
            List<Administrativo_Entities.CatalogoPermissaoUsuario> listaCPU = null;
            Administrativo_Entities.CatalogoPermissaoUsuario cpu = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT CatalogoPermissaoUsuario.capeusID, CatalogoPermissaoUsuario.capeusIDComponente, CatalogoPermissaoUsuario.capeusIDPWUsuario, CatalogoPermissaoUsuario.capeusPermissao, ")
              .AppendLine("CatalogoComponente.cacoIDForm ")
              .AppendLine("FROM CatalogoPermissaoUsuario INNER JOIN ")
              .AppendLine("CatalogoComponente ON CatalogoPermissaoUsuario.capeusIDComponente = CatalogoComponente.cacoID ")
              .AppendLine("WHERE CatalogoPermissaoUsuario.capeusIDPWUsuario = @idUsuario");

            try
            {
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cpu = new Administrativo_Entities.CatalogoPermissaoUsuario();
                        cpu.capeusID = Convert.ToInt32(dr["capeusID"]);
                        cpu.capeusIDComponente = Convert.ToInt32(dr["capeusIDComponente"]);
                        cpu.capeusIDPWUsuario = Convert.ToInt32(dr["capeusIDPWUsuario"]);
                        cpu.capeusPermissao = Convert.ToBoolean(dr["capeusPermissao"]);
                        cpu.cacoIDForm = Convert.ToInt32(dr["cacoIDForm"]);

                        if (listaCPU == null)
                            listaCPU = new List<Administrativo_Entities.CatalogoPermissaoUsuario>();

                        listaCPU.Add(cpu);
                    }
                    dr.Close();
                }
                return listaCPU;
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

        //public bool AtualizaAcessoPermissaoUsuario(int idUsuario, List<Administrativo_Entities.CatalogoPermissaoUsuario> listaCPU)
        public bool AtualizaAcessoPermissaoUsuario(int idUsuario, TriStateTreeView trvPermissoes)
        {
            // Apago todos os registro do usuário para criar um novo
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM CatalogoPermissaoUsuario where (capeusIDPWUsuario = @idUsuario)");

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                    {
                        SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        conn.Open();

                        int qtdRegDeletados = Convert.ToInt32(cmd.ExecuteNonQuery());

                        sb.Clear();
                        sb.Append("INSERT INTO CatalogoPermissaoUsuario (capeusIDComponente, capeusIDPWUsuario, capeusPermissao) ")
                          .Append("VALUES (@capeusIDComponente, @capeusIDPWUsuario, @capeusPermissao)");

                        cmd = new SqlCommand(sb.ToString(), conn);

                        // este é o primeiro nó: Formulários/Componentes
                        TriStateTreeNode rootNode = trvPermissoes.Nodes[0] as TriStateTreeNode;
                        string[] nodeName;

                        // estes são os formulários
                        foreach (TriStateTreeNode rtNode in rootNode.Nodes)
                        {
                            // estes são os componentes do formulário
                            foreach (TriStateTreeNode node in rtNode.Nodes)
                            {
                                nodeName = node.Name.Split('-');

                                cmd.Parameters.AddWithValue("@capeusIDComponente", nodeName[1]);
                                cmd.Parameters.AddWithValue("@capeusIDPWUsuario", idUsuario);
                                cmd.Parameters.AddWithValue("@capeusPermissao", node.Checked);                             

                                int qtdRegInseridos = Convert.ToInt32(cmd.ExecuteNonQuery());

                                cmd.Parameters.Clear();
                            }
                        }
                    }

                    ts.Complete();

                    return true;
                }
            }
            catch (TransactionAbortedException)
            {
                throw;
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


