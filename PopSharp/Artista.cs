using System;
using System.Collections.Generic;

namespace PopSharp.Filmes
{
    class Artista
    {
        public List<Filme> FilmesAtuados { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Atuacoes { get; set; }

        public Artista(string nome, int idade, string atuacoes)
        {
            Nome = nome;
            Idade = idade;
            Atuacoes = atuacoes;
            FilmesAtuados = new List<Filme>();
        }

        public void AdicionarFilme(Filme filme)
        {
            FilmesAtuados.Add(filme);
        }

        public void ExibirAtuacoes()
        {
            Console.WriteLine($"O/A ator/atriz {Nome} atuou nos seguintes filmes:");
            foreach (var filme in FilmesAtuados)
            {
                Console.WriteLine(filme.Titulo);
            }
        }
    }
}