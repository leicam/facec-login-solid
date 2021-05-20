using Login.Dominio.nsInterfaces;
using Login.Servico.nsServicos;
using SimpleInjector;

namespace Login.IoC
{
    public static class ServicoInstaller
    {
        internal static Container Factory(Container container)
        {
            container.Register<IUsuarioServico, UsuarioServico>(Lifestyle.Singleton);

            return container;
        }
    }
}