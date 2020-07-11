using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace IS_Funcoes
{
    public static class Mensagens
    {
        public static string RetornaMsgSQLException(SqlException sqlEx)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Erro ao Acessar ao Banco de Dados.\r\n\r\n" + "Entre em contato com o Administrador do Sistema.\r\n");

            foreach (SqlError sqlError in sqlEx.Errors)
            {
                sb.Append("Source: ").Append(sqlError.Source);
                sb.Append("\r\nNumber: ").Append(sqlError.Number.ToString());
                sb.Append("\r\nState: ").Append(sqlError.State.ToString());
                sb.Append("\r\nClass: ").Append(sqlError.Class.ToString());
                sb.Append("\r\nServer: ").Append(sqlError.Server);
                sb.Append("\r\nMessage: ").Append(sqlError.Message);
                sb.Append("\r\nProcedure: ").Append(sqlError.Procedure);
                sb.Append("\r\nLineNumber: ").Append(sqlError.LineNumber.ToString()).Append("\n\n");
            }
            return sb.ToString();
        }

        public static string RetornaMsgXMLException(XmlException xmlEx)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Ocorreu um Erro ao Acessar o Arquivo xml.\r\n\r\n" + "Entre em contato com o Administrador do Sistema.\r\n");

            sb.Append("Message: ").Append(xmlEx.Message);
            sb.Append("\r\n").Append("Source: ").Append(xmlEx.Source);
            sb.Append("\r\n").Append("Line Number: ").Append(xmlEx.LineNumber);
            sb.Append("\r\n").Append("StackTrace: ").Append(xmlEx.StackTrace);
            sb.Append("\r\n").Append("TargetSite: ").Append(xmlEx.TargetSite);
            sb.Append("\r\n").Append("InnerException: ").Append(xmlEx.InnerException);
            sb.Append("\r\n").Append("HelpLink: ").Append(xmlEx.HelpLink);
            sb.Append("\r\n").Append("Data: ").Append(xmlEx.Data);

            return sb.ToString();
        }

        public static string RetornaMsgException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Ocorreu um erro.\r\n\r\n" + "Entre em contato com o Administrador do Sistema.\r\n");

            sb.Append("Message: ").Append(ex.Message);
            sb.Append("\r\n").Append("Source: ").Append(ex.Source);
            sb.Append("\r\n").Append("StackTrace: ").Append(ex.StackTrace);
            sb.Append("\r\n").Append("TargetSite: ").Append(ex.TargetSite);
            sb.Append("\r\n").Append("InnerException: ").Append(ex.InnerException);
            sb.Append("\r\n").Append("HelpLink: ").Append(ex.HelpLink);
            sb.Append("\r\n").Append("Data: ").Append(ex.Data);

            return sb.ToString();
        }

        public static string RetornaMsgTransException(TransactionAbortedException tae)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Ocorreu um erro de transação.\r\n\r\n" + "Entre em contato com o Administrador do Sistema.\r\n");

            sb.Append("Message: ").Append(tae.Message);
            sb.Append("\r\n").Append("Source: ").Append(tae.Source);
            sb.Append("\r\n").Append("StackTrace: ").Append(tae.StackTrace);
            sb.Append("\r\n").Append("TargetSite: ").Append(tae.TargetSite);
            sb.Append("\r\n").Append("InnerException: ").Append(tae.InnerException);
            sb.Append("\r\n").Append("HelpLink: ").Append(tae.HelpLink);
            sb.Append("\r\n").Append("Data: ").Append(tae.Data);

            return sb.ToString();
        }
    }
}
