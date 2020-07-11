using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo_BLL
{
    public class CatalogoComponente
    {
        public int Update_CheckedFalso(Administrativo_Entities.CatalogoComponente catalogocomponente)
        {
            try
            {
                return new Administrativo_DAL.CatalogoComponente().Update_CheckedFalso(catalogocomponente);
            }
            catch (SqlException sqlEx)
            {
                string msg = IS_Funcoes.Mensagens.RetornaMsgSQLException(sqlEx);
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = IS_Funcoes.Mensagens.RetornaMsgException(ex);
                throw new Exception(msg);
            }
        }

        public int Delete_CheckedFalso(Administrativo_Entities.CatalogoComponente catalogocomponente)
        {
            try
            {
                return new Administrativo_DAL.CatalogoComponente().Delete_CheckedFalso(catalogocomponente);
            }
            catch (SqlException sqlEx)
            {
                string msg = IS_Funcoes.Mensagens.RetornaMsgSQLException(sqlEx);
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = IS_Funcoes.Mensagens.RetornaMsgException(ex);
                throw new Exception(msg);
            }
        }

        public int InsertUpdate(Administrativo_Entities.CatalogoComponente catalogocomponente)
        {
            try
            {
                return new Administrativo_DAL.CatalogoComponente().InsertUpdate(catalogocomponente);
            }
            catch (SqlException sqlEx)
            {
                string msg = IS_Funcoes.Mensagens.RetornaMsgSQLException(sqlEx);
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = IS_Funcoes.Mensagens.RetornaMsgException(ex);
                throw new Exception(msg);
            }
        }

        public List<Administrativo_Entities.CatalogoComponente> LerConteudo()
        {
            try
            {
                return new Administrativo_DAL.CatalogoComponente().LerConteudo();
            }
            catch (SqlException sqlEx)
            {
                string msg = IS_Funcoes.Mensagens.RetornaMsgSQLException(sqlEx);
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = IS_Funcoes.Mensagens.RetornaMsgException(ex);
                throw new Exception(msg);
            }
        }

        public List<Administrativo_Entities.CatalogoComponente> RetornaListaAcessoNegadoPermissaoComponente(int IDUsuario, string NomeFormulario)
        {
            try
            {
                return new Administrativo_DAL.CatalogoComponente().RetornaListaAcessoNegadoPermissaoComponente(IDUsuario, NomeFormulario);
            }
            catch (SqlException sqlEx)
            {
                string msg = IS_Funcoes.Mensagens.RetornaMsgSQLException(sqlEx);
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = IS_Funcoes.Mensagens.RetornaMsgException(ex);
                throw new Exception(msg);
            }
        }
    }
}
