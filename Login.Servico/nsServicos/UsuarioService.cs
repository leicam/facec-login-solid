using Login.Dominio.nsEntidades;
using Login.Dominio.nsExceptions;
using Login.Dominio.nsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Servico.nsServicos
{
    public class UsuarioService : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void Cadastrar(string login, string password)
        {
            try
            {
                if (_usuarioRepositorio.GetUsuario(login) != null)
                    throw new BusinessRuleException("Login informado já cadastrado na base de dados! Verifique.");
            }
            catch (ArgumentNullException)
            {
                _usuarioRepositorio.Add(new Usuario(login, password));
            }
        }
    }
}