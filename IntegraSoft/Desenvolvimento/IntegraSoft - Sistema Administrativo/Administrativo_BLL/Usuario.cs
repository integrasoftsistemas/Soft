using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrativo_BLL
{
    public class Usuario
    {
        public int Incluir(Administrativo_Entities.Usuario usuario)
        {
            try
            {
                return new Administrativo_DAL.Usuario().Incluir(usuario);
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

        public int Alterar(Administrativo_Entities.Usuario usuario)
        {
            try
            {
                return new Administrativo_DAL.Usuario().Alterar(usuario);
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

        public int Excluir(int PW_ID)
        {
            try
            {
                return new Administrativo_DAL.Usuario().Excluir(PW_ID);
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
        
        public Administrativo_Entities.Usuario AutenticarUsuario(string login, string senha)
        {
            try
            {
                return new Administrativo_DAL.Usuario().AutenticarUsuario(login, senha);
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

        public int Verifica_Qtd_Usuarios()
        {
            try
            {
                return new Administrativo_DAL.Usuario().Verifica_Qtd_Usuarios();
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

        public Administrativo_Entities.Usuario Pesquisar(int PW_ID = 0)
        {
            try
            {
                return new Administrativo_DAL.Usuario().Pesquisar(PW_ID);
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

        public Administrativo_Entities.Usuario PesquisarRegistroAposExclusao(int PW_ID)
        {
            try
            {
                return new Administrativo_DAL.Usuario().PesquisarRegistroAposExclusao(PW_ID);
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

        public List<Administrativo_Entities.Usuario> CarregarGrid(string strWhere)
        {
            try
            {
                return new Administrativo_DAL.Usuario().CarregarGrid(strWhere);
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

        public DataTable CarregarGrid_DT(string strWhere)
        {
            try
            {
                return new Administrativo_DAL.Usuario().CarregarGrid_DT(strWhere);
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
