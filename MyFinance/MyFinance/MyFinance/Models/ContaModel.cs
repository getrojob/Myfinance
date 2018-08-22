using Microsoft.AspNetCore.Http;
using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MyFinance.Util;

namespace MyFinance.Models
{
    public class ContaModel
    {
        private object saldo;

        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da Conta")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o saldo da Conta")]
        [DataType(DataType.Currency)]
        public decimal Saldo { get; set; }

        public int Usuario_Id { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }



        public ContaModel()
        {

        }

        //Recebe o contexto de acesso a variaveis de sessão
        public ContaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }

        public List<ContaModel> ListaConta()
        {
            List<ContaModel> Lista = new List<ContaModel>();
            ContaModel item;

            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"SELECT ID, NOME, SALDO, USUARIO_ID FROM CONTA WHERE USUARIO_ID = {id_usuario_logado}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ContaModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Nome = dt.Rows[i]["NOME"].ToString();
                item.Saldo = decimal.Parse(dt.Rows[i]["SALDO"].ToString());
                item.Usuario_Id = int.Parse(dt.Rows[i]["USUARIO_ID"].ToString());
                Lista.Add(item);
            }

            return Lista;

        }
        

        public void Insert()
        {


            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"INSERT INTO CONTA(NOME, SALDO, USUARIO_ID) VALUES ('{Nome}','{Saldo}','{id_usuario_logado}')";
            DAL objDAL = new DAL();

            objDAL.ExecutarComandoSQL(sql);

        }

        public void Excluir(int id_conta)
        {
            String sql = "DELETE FROM CONTA WHERE ID = "+ id_conta;
            DAL objDAL = new DAL();

            objDAL.ExecutarComandoSQL(sql);

            //new DAL().ExecutarComandoSQL("DELETE CONTA WHERE ID = "+ id_conta);


        }

    }
}
