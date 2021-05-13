using Login.Dominio.nsExceptions;
using Login.Repositorio.nsRepositorios;
using Login.Servico.nsServicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Servico.Teste.nsServicos
{
    [TestClass]
    public class UsuarioServiceTeste
    {
        private const string _owner = "Juliano";
        private const string _category = "Serviço Usuário";

        #region Cadastrar

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void UsuarioService_Cadastrar_ExpectedSucesso()
        {
            //Arrange
            var repositorio = new UsuarioRepositorio();
            var servico = new UsuarioService(repositorio);

            //Act
            servico.Cadastrar("Juliano", "123");

            //Assert
            Assert.IsNotNull(repositorio.GetUsuario("Juliano"),
                "Usuário não foi cadastrado! Verifique.");
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void UsuarioService_Cadastrar_ExpectedBusinessRuleException()
        {
            //Arrange
            var repositorio = new UsuarioRepositorio();
            var servico = new UsuarioService(repositorio);

            //Act
            servico.Cadastrar("Juliano", "123");

            //Assert
            Assert.ThrowsException<BusinessRuleException>(
                () => servico.Cadastrar("Juliano", "1234"),
                "Não foi gerada excessão para usuário já cadastrado!");
        }

        #endregion Cadastrar

        #region Efetuar Login

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void UsuarioService_EfetuarLogin_ExpectedSucesso()
        {
            //Arrange
            var repositorio = new UsuarioRepositorio();
            var servico = new UsuarioService(repositorio);

            //Act
            servico.Cadastrar("Juliano", "123");

            //Assert
            Assert.AreEqual("Bem vindo(a) Juliano",
                servico.EfetuarLogin("Juliano", "123"),
                "Não foi efetuado o login corretamente! Verifique.");
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void UsuarioService_EfetuarLogin_ExpectedBusinessRuleException()
        {
            //Arrange
            var repositorio = new UsuarioRepositorio();
            var servico = new UsuarioService(repositorio);

            //Act
            servico.Cadastrar("Juliano", "123");

            //Assert
            Assert.ThrowsException<BusinessRuleException>(
                () => servico.Cadastrar("Juliano", "1234"),
                "Não foi gerada excessão para usuário já cadastrado!");
        }

        #endregion Efetuar Login
    }
}