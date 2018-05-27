using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Security;
using System.Data;
using System.Web.Script.Services;
using CareDeliveryWeb.Models;

namespace CareDeliveryWeb
{
    /// <summary>
    /// Summary description for api
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class api : System.Web.Services.WebService
    {

        


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public dynamic autenticarUsuario(string usuario, string senha)
        {
            Autenticar a = new Autenticar();
            BancoDados b = new BancoDados();
            b.Query(@"SELECT USU_CODIGO_ID, USU_CATEGORIA FROM usuarios
                        where USU_USUARIO = ?USU_USUARIO
                        and USU_SENHA = ?USU_SENHA");
            b.SetParametro("?USU_USUARIO",usuario);
            b.SetParametro("?USU_SENHA", FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "md5"));
            DataTable dt = b.ExecutarDataTable();
            if (dt.Rows.Count > 0)
            {
                a.Autenticado = true;
                a.CodUsuario = int.Parse(dt.Rows[0]["USU_CODIGO_ID"].ToString());
                a.Categoria = int.Parse(dt.Rows[0]["USU_CATEGORIA"].ToString());
            }
            else
            {
                a.Autenticado = false;
                a.CodUsuario = 0;
                a.Categoria = 0;
            }
            return JsonConvert.SerializeObject(a);
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public dynamic carregaUsuario(string codUsuario)
        {
            Usuarios u = new Usuarios();
            BancoDados b = new BancoDados();
            b.Query(@"SELECT USU_CODIGO_ID, 
                                USU_NOME, 
                                USU_CATEGORIA, 
                                cat_descricao, 
                                USU_USUARIO, 
                                USU_CPF, 
                                USU_EMAIL, 
                                USU_SENHA 
                                FROM usuarios
                            inner join categoria_usuario on (usu_categoria = cat_codigo_id)
                            where usu_codigo_id = ?usu_codigo_id");
            b.SetParametro("?usu_codigo_id", codUsuario);
            DataTable dt = b.ExecutarDataTable();
            if (dt.Rows.Count > 0)
            {
                u.Codigo = int.Parse(dt.Rows[0]["USU_CODIGO_ID"].ToString());
                u.Categoria = int.Parse(dt.Rows[0]["USU_CATEGORIA"].ToString());
                u.Cpf = dt.Rows[0]["USU_CPF"].ToString();
                u.Email = dt.Rows[0]["USU_EMAIL"].ToString();
                u.Nome = dt.Rows[0]["USU_NOME"].ToString();
                u.NomeCategoria = dt.Rows[0]["cat_descricao"].ToString();
                u.Senha = dt.Rows[0]["USU_SENHA"].ToString();
                u.Usuario = dt.Rows[0]["USU_USUARIO"].ToString();
            }
            
            return JsonConvert.SerializeObject(u);
        }
    }
}
