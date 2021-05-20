using Login.Dominio.nsExtensions;
using Login.Dominio.nsInterfaces;
using Login.IoC;
using System;

namespace Login.Apresentacao
{
    class Program
    {
        private const string _pressioneEnter = "Pressione ENTER para continuar!";
        private const string _passwordAtual = "Informe seu password atual: ";
        private const string _passwordNovo = "Informe seu novo password: ";

        private static readonly IUsuarioServico _usuarioServico
            = Installer.Factory().GetInstance<IUsuarioServico>();

        static void Main(string[] args)
        {
            try
            {
                MenuPrincipal();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Concat(ex.Message, "\n", _pressioneEnter));
                Console.ReadLine();
                MenuPrincipal();
            }
        }

        private static void MenuPrincipal()
        {
            int opcaoEscolhida = 0;

            Console.WriteLine("Bem vindo!");

            do
            {
                Console.Clear();
                Console.WriteLine("Selecione a opção desejada: ");
                Console.WriteLine("1 - Sign in");
                Console.WriteLine("2 - Alterar password");
                Console.WriteLine("3 - Sign up");
                Console.WriteLine("4 - Sair");

                opcaoEscolhida = Console.ReadLine().ToInt();

                switch (opcaoEscolhida)
                {
                    case 1:
                        EfetuarLogin();
                        break;
                    case 2:
                        AlterarSenha();
                        break;
                    case 3:
                        CadastrarUsuario();
                        break;
                }
            } while (opcaoEscolhida != 4);
        }

        private static void AlterarSenha()
        {
            Console.WriteLine(_usuarioServico
                .AlterarSenha(GetLogin(), GetPassword(_passwordAtual), GetPassword(_passwordNovo)));
            Console.WriteLine(_pressioneEnter);
            Console.ReadLine();
        }

        private static void EfetuarLogin()
        {
            Console.WriteLine(_usuarioServico
                .EfetuarLogin(GetLogin(), GetPassword()));
            Console.WriteLine(_pressioneEnter);
            Console.ReadLine();
        }

        private static void CadastrarUsuario()
        {
            _usuarioServico.Cadastrar(GetLogin(), GetPassword());

            Console.WriteLine("Usuário cadastrado com sucesso!");
            Console.WriteLine(_pressioneEnter);
            Console.ReadLine();
        }

        private static string GetLogin()
        {
            Console.WriteLine("Informe seu login: ");
            return Console.ReadLine();
        }

        private static string GetPassword(string mensagem = "Informe seu password: ")
        {
            Console.WriteLine(mensagem);
            return Console.ReadLine();
        }
    }
}