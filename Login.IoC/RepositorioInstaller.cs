using Login.Dominio.nsInterfaces;
using Login.Repositorio.nsRepositorios;
using SimpleInjector;

namespace Login.IoC
{
    internal static class RepositorioInstaller
    {
        internal static Container Factory(Container container)
        {
            container.Register<IUsuarioRepositorio, UsuarioRepositorio>(Lifestyle.Singleton);

            return container;
        }
    }
}