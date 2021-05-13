using Login.Dominio.nsEntidades;
using Login.Dominio.nsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Repositorio.nsRepositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly List<Usuario> _lista = new List<Usuario>();

        public void Add(Usuario usuario)
        {
            _lista.Add(usuario);
        }

        public Usuario GetUsuario(string login)
        {
            foreach (var usuario in _lista)
            {
                if (usuario.Login.Equals(login))
                    return usuario;
            }

            throw new ArgumentNullException(nameof(Usuario));
        }
    }
}