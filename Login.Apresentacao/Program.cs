using Login.Dominio.nsExtensions;
using Login.Repositorio.nsRepositorios;
using Login.Servico.nsServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Apresentacao
{
    class Program
    {
        private static readonly UsuarioRepositorio _usuarioRepositorio =
            new UsuarioRepositorio();

        private static readonly UsuarioService _usuarioService =
            new UsuarioService(_usuarioRepositorio);

        static void Main(string[] args)
        {
            try
            {
                MenuPrincipal();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Concat(ex.Message, "\n",
                    "Pressione ENTER para continuar"));
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
                Console.WriteLine("2 - Esqueceu sua senha");
                Console.WriteLine("3 - Sign up");
                Console.WriteLine("4 - Sair");

                opcaoEscolhida = Console.ReadLine().ToInt();

                switch (opcaoEscolhida)
                {
                    case 1:
                        EfetuarLogin();
                        break;
                    case 2:
                        //chamar rotina de esqueceu senha
                        break;
                    case 3:
                        CadastrarUsuario();
                        break;
                }
            } while (opcaoEscolhida != 4);
        }

        private static void EfetuarLogin()
        {
            Console.WriteLine(_usuarioService
                .EfetuarLogin(GetLogin(), GetPassword()));

            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }

        private static void CadastrarUsuario()
        {
            _usuarioService.Cadastrar(GetLogin(), GetPassword());

            Console.WriteLine("Usuário cadastrado com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }

        private static string GetLogin()
        {
            Console.WriteLine("Informe seu login: ");
            return Console.ReadLine();
        }

        private static string GetPassword()
        {
            Console.WriteLine("Informe seu password: ");
            return Console.ReadLine();
        }
    }
}