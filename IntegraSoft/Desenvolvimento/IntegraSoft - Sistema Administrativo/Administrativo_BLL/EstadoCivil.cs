using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo_BLL
{
    public class EstadoCivil
    {
        public List<Administrativo_Entities.EstadoCivil> CarregaComboBox()
        {
            try
            {
                return new Administrativo_DAL.EstadoCivil().CarregaComboBox();
            }
            catch (SqlException sqlEx)
            {
                //string msg = Util.RetornaMsgSQLException(sqlEx);
                //throw new Exception(msg);
                throw sqlEx;
            }
            catch (Exception ex)
            {
                //string msg = Util.RetornaMsgException(ex);
                //throw new Exception(msg);
                throw ex;
            }
        }
    }
}
