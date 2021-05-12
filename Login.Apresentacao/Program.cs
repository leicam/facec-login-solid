using Login.Dominio.nsExtensions;
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
        static void Main(string[] args)
        {
            try
            {
                MenuPrincipal();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void MenuPrincipal()
        {
            do
            {
                Console.WriteLine("Bem vindo!");
                Console.WriteLine("Selecione a opção desejada: ");
                Console.WriteLine("1 - Sign in");
                Console.WriteLine("2 - Esqueceu sua senha");
                Console.WriteLine("3 - Sign up");
                Console.WriteLine("4 - Sair");

                switch (Console.ReadLine().ToInt())
                {
                    case 1:
                        //chamar rotina de login
                        break;
                    case 2:
                        //chamar rotina de esqueceu senha
                        break;
                    case 3:
                        CadastrarUsuario();
                        break;
                }
            } while (Console.ReadLine().ToInt() != 4);
        }

        private static void CadastrarUsuario()
        {
            Console.WriteLine("Informe seu login: ");
            var login = Console.ReadLine();

            Console.WriteLine("Informe seu password: ");
            var password = Console.ReadLine();

            var servico = new UsuarioService(null);

            servico.Cadastrar(login, password);
        }
    }
}