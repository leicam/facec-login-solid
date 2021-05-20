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
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public string AlterarSenha(string login, string oldPassword, string newPassword)
        {
            var usuario = _usuarioRepositorio.GetUsuario(login, oldPassword)
                ?? throw new BusinessRuleException("Usuário não cadastrado! Verifique.");

            usuario.SetPassword(newPassword);

            return $"Olá {usuario.Login}, seu PASSWORD foi alterado com sucesso!";
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

        public string EfetuarLogin(string login, string password)
        {
            return $"Bem vindo(a) { _usuarioRepositorio.GetUsuario(login, password).Login }";
        }
    }
}