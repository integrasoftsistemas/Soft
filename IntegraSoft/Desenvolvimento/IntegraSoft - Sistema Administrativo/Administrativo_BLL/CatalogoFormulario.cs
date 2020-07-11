using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo_BLL
{
    public class CatalogoFormulario
    {
        public int Update_CheckedFalso(Administrativo_Entities.CatalogoFormulario catalogoformulario)
        {
            try
            {
                return new Administrativo_DAL.CatalogoFormulario().Update_CheckedFalso(catalogoformulario);
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

        public int Delete_CheckedFalso(Administrativo_Entities.CatalogoFormulario catalogoformulario)
        {
            try
            {
                return new Administrativo_DAL.CatalogoFormulario().Delete_CheckedFalso(catalogoformulario);
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

        public int InsertUpdate(Administrativo_Entities.CatalogoFormulario catalogoformulario)
        {
            try
            {
                return new Administrativo_DAL.CatalogoFormulario().InsertUpdate(catalogoformulario);
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

        public List<Administrativo_Entities.CatalogoFormulario> LerConteudo()
        {
            try
            {
                return new Administrativo_DAL.CatalogoFormulario().LerConteudo();
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

        public List<Administrativo_Entities.CatalogoFormulario> RetornarTodosFormulariosComponentes()
        {
            try
            {
                return new Administrativo_DAL.CatalogoFormulario().RetornarTodosFormulariosComponentes();
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

        public bool RetornaAcessoMenu(string NomeMenuAcesso, int IDUsuario)
        {
            try
            {
                return new Administrativo_DAL.CatalogoFormulario().RetornaAcessoMenu(NomeMenuAcesso, IDUsuario);
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

        public List<Administrativo_Entities.CatalogoFormulario> RetornaListaAcessoMenu(int IDUsuario)
        {
            try
            {
                return new Administrativo_DAL.CatalogoFormulario().RetornaListaAcessoMenu(IDUsuario);
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
