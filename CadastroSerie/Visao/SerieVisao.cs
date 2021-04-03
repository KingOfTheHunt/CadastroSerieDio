using System;
using System.Globalization;
using CadastroSerie.Entidades;
using CadastroSerie.Enums;
using CadastroSerie.Repositorios;

namespace CadastroSerie.Visao
{
    public class SerieVisao
    {
        private static SerieRepositorio _series = new SerieRepositorio();

        public static void Menu()
        {
            char op;

            Console.WriteLine("Bem vindo a sua lista de séries.");

            try
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("\t\tMenu");
                    Console.WriteLine("1 - Listar séries.");
                    Console.WriteLine("2 - Inserir série.");
                    Console.WriteLine("3 - Atualizar série.");
                    Console.WriteLine("4 - Excluir série.");
                    Console.WriteLine("5 - Visualizar série.");
                    Console.WriteLine("X - Sair.");
                    Console.Write("Opção: ");
                    op = Console.ReadLine().ToUpper()[0];

                    switch (op)
                    {
                        case '1':
                            ListarSeries();
                            break;
                        case '2':
                            InserirSerie();
                            break;
                        case '3':
                            AtualizarSerie();
                            break;
                        case '4':
                            ExcluirSerie();
                            break;
                        case '5':
                            VisualizarSerie();
                            break;
                        case 'X':
                            Console.WriteLine("Fim da execução do programa...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                } while (op != 'X');
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private static void ListarSeries()
        {
            try
            {
                Console.WriteLine();

                Console.WriteLine("Lista de séries");
                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                foreach (var serie in _series.Lista())
                {
                    Console.WriteLine(serie);
                }

                Console.WriteLine("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void InserirSerie()
        {
            try
            {
                Console.WriteLine();

                Console.WriteLine("Inserir nova série");

                Console.WriteLine();

                Console.WriteLine("Gêneros: ");
                // Pegando o nome e o valor do enum Genero.
                foreach (int g in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine($"{g} - {Enum.GetName(typeof(Genero), g)}");
                }
                
                Console.Write("Digite um genêro entre as opções acima: ");
                int genero = int.Parse(Console.ReadLine());
                Console.Write("Digite o título da série: ");
                string titulo = Console.ReadLine();
                Console.Write("Digite o ano de início da série (dd/mm/aaaa): ");
                DateTime ano = DateTime.Parse(Console.ReadLine());
                Console.Write("Digite a descrição da série: ");
                string descricao = Console.ReadLine();
                Console.Write("Digite a nota que você dá para série: ");
                float nota = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                _series.Insere(new Serie(
                    _series.ProximoId(),
                    (Genero)genero,
                    titulo,
                    descricao,
                    ano,
                    nota));

                Console.WriteLine("Cadastrado com sucesso!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AtualizarSerie()
        {
            try
            {
                Console.WriteLine();

                Console.WriteLine("Atualizar série");

                ListarSeries();

                Console.Write("Digite o id da série que  deseja atualizar: ");
                int id = int.Parse(Console.ReadLine());

                if (_series.Existe(id) == false)
                {
                    Console.WriteLine("Não existe uma série com este id.");
                    return;
                }

                Console.WriteLine();

                Console.WriteLine("Gêneros: ");
                // Pegando o nome e o valor do enum Genero.
                foreach (int g in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine($"{g} - {Enum.GetName(typeof(Genero), g)}");
                }

                Console.Write("Digite um genêro entre as opções acima: ");
                int genero = int.Parse(Console.ReadLine());
                Console.Write("Digite o título da série: ");
                string titulo = Console.ReadLine();
                Console.Write("Digite o ano de início da série (dd/mm/aaaa): ");
                DateTime ano = DateTime.Parse(Console.ReadLine());
                Console.Write("Digite a descrição da série: ");
                string descricao = Console.ReadLine();
                Console.Write("Digite a nota que você dá para série: ");
                float nota = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Serie serie = new Serie(
                    id,
                    (Genero)genero,
                    titulo,
                    descricao,
                    ano,
                    nota);

                _series.Atualiza(id - 1, serie);

                Console.WriteLine("Atualizado com sucesso!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ExcluirSerie()
        {
            char op;

            try
            {
                Console.WriteLine();
                Console.WriteLine("Excluir série");

                Console.WriteLine();

                foreach (Serie serie in _series.Lista())
                {
                    Console.WriteLine(serie);
                }

                Console.Write("Digite o id da série que deseja excluir: ");
                int id = int.Parse(Console.ReadLine());

                do
                {
                    Console.Write("Deseja realmente excluir (s/n)? ");
                    op = Console.ReadLine().ToLower()[0];
                } while (op != 's' && op != 'n');

                if (op == 's')
                {
                    _series.Exclui(id); 
                    Console.WriteLine("Excluído com sucesso!!");
                }
                else
                {
                    Console.WriteLine("Operação cancelada!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void VisualizarSerie()
        {
            try
            {
                Console.WriteLine();

                Console.WriteLine("Visualizar série");

                Console.Write("Digite o id da série que você deseja visualizar: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine(_series.RetornaPorId(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
