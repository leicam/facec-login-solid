using Login.Dominio.nsEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Dominio.nsInterfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario GetUsuario(string login);
        void Add(Usuario usuario);
    }
}
