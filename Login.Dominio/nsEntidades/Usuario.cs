using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Dominio.nsEntidades
{
    public class Usuario
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public Usuario(string login, string password)
        {
            SetLogin(login);
            SetPassword(password);
        }

        private void SetLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentOutOfRangeException(nameof(Login));

            Login = login;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentOutOfRangeException(nameof(Password));

            Password = password;
        }
    }
}