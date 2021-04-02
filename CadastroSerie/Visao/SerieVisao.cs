using System;
using CadastroSerie.Repositorios;

namespace CadastroSerie.Visao
{
    public class SerieVisao
    {
        private SerieRepositorio _series = new SerieRepositorio();

        public static void Menu()
        {
            char op;

            Console.Clear();

            Console.WriteLine("Bem vindo a sua lista de séries.");

            do
            {
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1 - Listar séries.");
                Console.WriteLine("2 - Inserir série.");
                Console.WriteLine("3 - Atualizar série.");
                Console.WriteLine("4 - Excluir série");
                Console.WriteLine("5 - Visualizar série.");
                Console.WriteLine("X - Sair.");
                op = Console.ReadLine().ToUpper()[0];
            } while (op != 'X');

            switch (op)
            {
                case '1':
                    // ListaSeries();
                    break;
                case '2':
                    // InsereSerie();
                    break;
                case '3':
                    // AtualizaSerie();
                    break;
                case '4':
                    // ExcluiSerie();
                    break;
                case '5':
                    // VisualizaSerie();
                    break;
                case 'X':
                    Console.WriteLine("Fim da execução do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
