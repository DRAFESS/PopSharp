using System;
using System.Collections.Generic;
using PopSharp.Filmes;

class Program
{
    static List<Filme> filmes = new List<Filme>();
    static List<Artista> artistas = new List<Artista>();

    static void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    static void AdicionarFilme()
    {
        Console.Write("Digite o título do filme: ");
        string titulo = Console.ReadLine();
        Console.Write("Digite a duração do filme em minutos: ");
        int duracao = int.Parse(Console.ReadLine());
        Console.Write("Digite o elenco do filme: ");
        string elenco = Console.ReadLine();
        Console.Write("Digite a descrição do filme: ");
        string descricao = Console.ReadLine();
        Console.Write("Digite a restrição de idade (0 para livre): ");
        double restricao = double.Parse(Console.ReadLine());

        Filme filme = new Filme(restricao)
        {
            Titulo = titulo,
            Duracao = duracao,
            Elenco = elenco,
            Descricao = descricao
        };

        filmes.Add(filme);
        Console.WriteLine("Filme adicionado com sucesso!");
    }

    static void AdicionarArtista()
    {
        Console.Write("Digite o nome do artista: ");
        string nome = Console.ReadLine();
        Console.Write("Digite a idade do artista: ");
        int idade = int.Parse(Console.ReadLine());
        Console.Write("Digite as atuações do artista: ");
        string atuacoes = Console.ReadLine();

        Artista artista = new Artista(nome, idade, atuacoes);
        artistas.Add(artista);

        Console.WriteLine("Artista adicionado com sucesso!");

        // Adiciona filmes ao artista
        AdicionarFilmeParaArtista(artista);
    }

    static void AdicionarFilmeParaArtista(Artista artista)
    {
        Console.WriteLine("Selecione o filme para adicionar ao artista:");
        for (int i = 0; i < filmes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {filmes[i].Titulo}");
        }

        int escolha = int.Parse(Console.ReadLine()) - 1;

        if (escolha >= 0 && escolha < filmes.Count)
        {
            Filme filme = filmes[escolha];
            filme.AdicionarAtor(artista);
            Console.WriteLine("Filme adicionado ao artista com sucesso!");
        }
        else
        {
            Console.WriteLine("Escolha inválida!");
        }
    }

    static void ExibirFilmes()
    {
        Console.WriteLine("Lista de Filmes:");
        foreach (var filme in filmes)
        {
            Console.WriteLine(filme.ToString());
        }
    }

    static void ExibirArtistas()
    {
        Console.WriteLine("Lista de Artistas:");
        foreach (var artista in artistas)
        {
            Console.WriteLine($"Nome: {artista.Nome}, Idade: {artista.Idade}, Atuacoes: {artista.Atuacoes}");
            artista.ExibirAtuacoes();
        }
    }

    static void Main()
    {
        bool sair = false;
        while (!sair)
        {
            ExibirTituloDaOpcao("Menu Principal do PopSharp");
            Console.WriteLine("1. Adicionar Filme");
            Console.WriteLine("2. Adicionar Artista");
            Console.WriteLine("3. Exibir Filmes");
            Console.WriteLine("4. Exibir Artistas");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AdicionarFilme();
                    break;
                case "2":
                    AdicionarArtista();
                    break;
                case "3":
                    ExibirFilmes();
                    break;
                case "4":
                    ExibirArtistas();
                    break;
                case "5":
                    sair = true;
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}