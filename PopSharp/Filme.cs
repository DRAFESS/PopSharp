namespace PopSharp.Filmes;

class Filme
{
    public string Titulo { get; set; }
    public int Duracao { get; set; }
    public string Elenco { get; set; }
    public string Descricao { get; set; }
    public double Restricao { get; set; }
    public List<Artista> Atores { get; set; }

    public Filme(double restricao)
    {
        Restricao = restricao;
        Atores = new List<Artista>();
    }

    public void AdicionarAtor(Artista artista)
    {
        Atores.Add(artista);
        artista.AdicionarFilme(this);
    }

    public override string ToString()
    {
        string restricaoMensagem = Restricao == 0 ? "É livre para todas as idades" : $"Possui restrição de idade para maiores de {Restricao}";
        return $"Segue as descrições do filme {Titulo}\nO filme possui {Duracao}min de exibição\nApresentando o elenco com {Elenco}\nSinopse: {Descricao}\n{restricaoMensagem}";
    }
}