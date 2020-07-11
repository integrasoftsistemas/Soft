using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IS_Funcoes
{
    public static class ConexaoBD
    {
        public static string RetornaConexaoBD()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(@".\Config.xml");

                StringBuilder sb = new StringBuilder();
                sb.Append("Data Source=").Append(SegurancaCripto.Descriptografar(xmlDoc.SelectSingleNode("/Configuracoes/ConexaoBD/ServidorInstancia").InnerText)).Append(";");
                sb.Append("Initial Catalog=").Append(SegurancaCripto.Descriptografar(xmlDoc.SelectSingleNode("/Configuracoes/ConexaoBD/BancoDados").InnerText)).Append(";");
                sb.Append("User ID=").Append(SegurancaCripto.Descriptografar(xmlDoc.SelectSingleNode("/Configuracoes/ConexaoBD/Login").InnerText)).Append(";");
                sb.Append("Password=").Append(SegurancaCripto.Descriptografar(xmlDoc.SelectSingleNode("/Configuracoes/ConexaoBD/Senha").InnerText)).Append(";");
                sb.Append("Connection Timeout=").Append(SegurancaCripto.Descriptografar(xmlDoc.SelectSingleNode("/Configuracoes/ConexaoBD/TimeOut").InnerText));
                return sb.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
