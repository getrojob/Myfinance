using System;
using Xunit;
using MyFinance.Models;

namespace ProjetoTeste
{
    public class UnitTestModels
    {
        [Fact]
        public void TestLoginUsuario()
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.Email = "getulio.silva@gmail.com";
            usuarioModel.Senha = "123456";
            bool result = usuarioModel.ValidarLogin();
            Assert.True(result);
        }

        [Fact]
        public void TestRegistrarUsuario()
        {
            UsuarioModel usuarioModel = new UsuarioModel();

            usuarioModel.Nome = "Gustavo";
            usuarioModel.Data_Nascimento = "2012/12/30";
            usuarioModel.Email = "gustavo@gmail.com";
            usuarioModel.Senha = "123456";
            usuarioModel.RegistrarUsuario();
            bool result = usuarioModel.ValidarLogin();
            Assert.True(result);
        }
    }
}

