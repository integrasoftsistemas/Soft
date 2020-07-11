using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Funcoes;

namespace Administrativo_DAL
{
    public class EstadoCivil
    {
        public List<Administrativo_Entities.EstadoCivil> CarregaComboBox() // vamos carregar tudo não precisamos passar parametros dentro ()
        {
            // vamos criar a lista da classe do Estado Civil e atribuindo valor null
            List<Administrativo_Entities.EstadoCivil> lstEstadoCivil = null;
                         //  nome da classe Objeto
            Administrativo_Entities.EstadoCivil objEstadoCivil = null;

            // vamos montrar o Select do BD
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM EstadoCivil ")
              //.Append(!string.IsNullOrWhiteSpace(strWhere) ? "WHERE " + strWhere + " " : "")
              .Append("ORDER BY escDescricao");

            try
            {
                // SqlConnection fica dentro da classe System.Data.SqlClient
                using (SqlConnection conn = new SqlConnection(IS_Funcoes.ConexaoBD.RetornaConexaoBD()))
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

                    // abre conexão BD
                    conn.Open();

                    // dr = data reader
                    // vai no BD e executa o commando Select ...
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (lstEstadoCivil == null)
                        {
                            lstEstadoCivil = new List<Administrativo_Entities.EstadoCivil>();
                        }

                        // para cada item que vem do banco tem que ter um new para criar o objeto
                        objEstadoCivil = new Administrativo_Entities.EstadoCivil();

                        if (dr["escID"] != DBNull.Value)
                            // .escID da classe entities  o que esta dentro do dr é do BD
                            objEstadoCivil.escID = Convert.ToInt32(dr["escID"]);

                        // .escID da classe entities  o que esta dentro do dr é do BD
                        if (dr["escDescricao"] != DBNull.Value)
                            objEstadoCivil.escDescricao = dr["escDescricao"].ToString();

                        // adicionar o objeto objEstadoCivil na lista
                        lstEstadoCivil.Add(objEstadoCivil);
                    }
                }

                if (lstEstadoCivil  != null)
                { 
                    lstEstadoCivil.Insert(0, new Administrativo_Entities.EstadoCivil { escID = -1, escDescricao = "Selecione" });
                }

                return lstEstadoCivil;
            }
            
            catch (SqlException) // Somente se for erro no BD
            {
                // Dispara o erro para ser tratado na BLL
                throw;
            }
            
            catch (Exception) // Demais erros
            {
                // Dispara o erro para ser tratado na BLL
                throw;
            }
        }
    }
}
