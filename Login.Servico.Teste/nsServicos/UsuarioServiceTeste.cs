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

        #region Alterar Senha

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void UsuarioService_AlterarSenha_ExpectedSucesso()
        {
            //Arrange
            var usuarioService = new UsuarioServico(new UsuarioRepositorio());

            //Act
            usuarioService.Cadastrar("Juliano", "123");
            var resultado = usuarioService.AlterarSenha("Juliano", "123", "abc");

            //Assert
            Assert.AreEqual("Olá Juliano, seu PASSWORD foi alterado com sucesso!", resultado,
                "Não foi gerado resultado esperado para a alteração de senha do usuário! Verifique.");
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void UsuarioService_AlterarSenha_ExpectedStringEmptyBusinessRuleException()
        {
            //Arrange
            var usuarioService = new UsuarioServico(new UsuarioRepositorio());

            //Act
            usuarioService.Cadastrar("Juliano", "123");

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => usuarioService.AlterarSenha("Juliano", "123", string.Empty),
                "Não foi gerada exceção para novo password quando vazio! Verifique.");
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void UsuarioService_AlterarSenha_ExpectedWhiteSpacesBusinessRuleException()
        {
            //Arrange
            var usuarioService = new UsuarioServico(new UsuarioRepositorio());

            //Act
            usuarioService.Cadastrar("Juliano", "123");

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => usuarioService.AlterarSenha("Juliano", "123", "        "),
                "Não foi gerada exceção para novo password quando com espaços em branco! Verifique.");
        }

        #endregion Alterar Senha

        #region Cadastrar

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void UsuarioService_Cadastrar_ExpectedSucesso()
        {
            //Arrange
            var repositorio = new UsuarioRepositorio();
            var servico = new UsuarioServico(repositorio);

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
            var servico = new UsuarioServico(repositorio);

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
            var servico = new UsuarioServico(repositorio);

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
            var servico = new UsuarioServico(repositorio);

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