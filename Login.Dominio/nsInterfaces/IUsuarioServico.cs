namespace Login.Dominio.nsInterfaces
{
    public interface IUsuarioServico
    {
        void Cadastrar(string login, string password);
        string EfetuarLogin(string login, string password);
    }
}