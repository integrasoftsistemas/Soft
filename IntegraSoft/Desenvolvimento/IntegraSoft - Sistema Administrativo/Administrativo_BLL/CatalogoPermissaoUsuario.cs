using SmartSolutions.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Administrativo_BLL
{
    public class CatalogoPermissaoUsuario
    {
        //public int Update_CheckedFalso(Administrativo_Entities.CatalogoPermissaoUsuario catalogopermissaousuario)
        //{
        //    try
        //    {
        //        return new Administrativo_DAL.CatalogoPermissaoUsuario().Update_CheckedFalso(catalogopermissaousuario);
        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        string msg = IS_Funcoes.Mensagens.RetornaMsgSQLException(sqlEx);
        //        throw new Exception(msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = IS_Funcoes.Mensagens.RetornaMsgException(ex);
        //        throw new Exception(msg);
        //    }
        //}

        public int Delete_CheckedFalso(Administrativo_Entities.CatalogoPermissaoUsuario catalogopermissaousuario)
        {
            try
            {
                return new Administrativo_DAL.CatalogoPermissaoUsuario().Delete_CheckedFalso(catalogopermissaousuario);
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

        public List<Administrativo_Entities.CatalogoPermissaoUsuario> PreencheAcessoPermissaoUsuario(int idUsuario)
        {
            try
            {
                //List<Administrativo_Entities.CatalogoPermissaoUsuario> listaCPU = new Administrativo_DAL.CatalogoPermissaoUsuario().RetornarAcessoUsuario(idUsuario);
                //return listaCPU;

                return new Administrativo_DAL.CatalogoPermissaoUsuario().PreencheAcessoPermissaoUsuario(idUsuario);
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

        //public bool AtualizaAcessoPermissaoUsuario(int idUsuario, List<Administrativo_Entities.CatalogoPermissaoUsuario> listaCPU)
        public bool AtualizaAcessoPermissaoUsuario(int idUsuario, TriStateTreeView trvPermissoes)
        {
            try
            {
                //List<Administrativo_Entities.CatalogoPermissaoUsuario> listaCPU = new Administrativo_DAL.CatalogoPermissaoUsuario().RetornarAcessoUsuario(idUsuario);
                //return listaCPU;

                //return new Administrativo_DAL.CatalogoPermissaoUsuario().AtualizaAcessoPermissaoUsuario(idUsuario, listaCPU);
                return new Administrativo_DAL.CatalogoPermissaoUsuario().AtualizaAcessoPermissaoUsuario(idUsuario, trvPermissoes);
            }
            catch (TransactionAbortedException transEx)
            {
                string msg = IS_Funcoes.Mensagens.RetornaMsgTransException(transEx);
                throw new Exception(msg);
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
