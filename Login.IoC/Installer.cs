using SimpleInjector;

namespace Login.IoC
{
    public static class Installer
    {
        public static Container Factory()
        {
            var container = new Container();

            container = RepositorioInstaller.Factory(container);
            container = ServicoInstaller.Factory(container);

            container.Verify();

            return container;
        }
    }
}