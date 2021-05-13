using Login.Dominio.nsEntidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Dominio.Teste.nsEntidades
{
    [TestClass]
    public class UsuarioTestes
    {
        private const string _owner = "Juliano";
        private const string _category = "Entidade Usuário";

        #region Propriedade Login

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void Usuario_Construtor_ExpectedLoginNullOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Usuario(null, "123"),
                "Não foi gerada exception para propriedade Login recebendo valor null");
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void Usuario_Construtor_ExpectedLoginStringEmptyOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Usuario(string.Empty, "123"),
                "Não foi gerada exception para propriedade Login recebendo valor null");
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void Usuario_Construtor_ExpectedLoginWhiteSpacesOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Usuario("", "123"),
                "Não foi gerada exception para propriedade Login recebendo valor null");
        }

        #endregion Propriedade Login

        #region Propriedade Password

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void Usuario_Construtor_ExpectedPasswordNullOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Usuario("Juliano", null),
                "Não foi gerada exception para propriedade Login recebendo valor null");
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void Usuario_Construtor_ExpectedPasswordStringEmptyOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Usuario("Juliano", string.Empty),
                "Não foi gerada exception para propriedade Login recebendo valor null");
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void Usuario_Construtor_ExpectedPasswordWhiteSpacesOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Usuario("Juliano", " "),
                "Não foi gerada exception para propriedade Login recebendo valor null");
        }

        #endregion Propriedade Password

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_category)]
        public void Usuario_Construtor_ExpectedSucesso()
        {
            var usuario = new Usuario("Juliano", "123");

            Assert.AreEqual("Juliano", usuario.Login);
            Assert.AreEqual("123", usuario.Password);
        }
    }
}