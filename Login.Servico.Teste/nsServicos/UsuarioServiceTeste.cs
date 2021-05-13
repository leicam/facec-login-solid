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
    }
}