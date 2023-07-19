using System;
using System.Collections.Generic;

public class Aeronave
{
    public int NumeroIdentificacao { get; set; }
    public string Modelo { get; set; }
    public int QuantidadeAssentos { get; set; }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Aeronave {NumeroIdentificacao} - {Modelo}");
        Console.WriteLine($"Assentos Disponíveis: {QuantidadeAssentos}");
        Console.WriteLine();
    }
}
public class Aeroporto
{
    public string Nome { get; set; }
    public List<Voo> VoosDisponiveis { get; set; }

    public Aeroporto(string nome)
    {
        Nome = nome;
        VoosDisponiveis = new List<Voo>();
    }

    public void AdicionarVoo(Voo voo)
    {
        VoosDisponiveis.Add(voo);
    }
}
public class Voo
{
    public Aeronave Aeronave { get; set; }
    public Aeroporto Partida { get; set; }
    public Aeroporto Destino { get; set; }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Voo de {Partida.Nome} para {Destino.Nome}");
        Console.WriteLine($"Aeronave: {Aeronave.NumeroIdentificacao} - {Aeronave.Modelo}");
        Console.WriteLine();
    }
}
public class SimuladorVoo
{
    public List<Aeronave> Aeronaves { get; set; }
    public List<Aeroporto> Aeroportos { get; set; }

    public SimuladorVoo()
    {
        Aeronaves = new List<Aeronave>();
        Aeroportos = new List<Aeroporto>();
    }

    public void AdicionarAeronave(Aeronave aeronave)
    {
        Aeronaves.Add(aeronave);
    }

    public void AdicionarAeroporto(Aeroporto aeroporto)
    {
        Aeroportos.Add(aeroporto);
    }

    public void PlanejarVoo(Aeronave aeronave, Aeroporto partida, Aeroporto destino)
    {
        if (Aeronaves.Contains(aeronave) && Aeroportos.Contains(partida) && Aeroportos.Contains(destino))
        {
            Voo voo = new Voo { Aeronave = aeronave, Partida = partida, Destino = destino };
            partida.AdicionarVoo(voo);
            Console.WriteLine("Voo planejado com sucesso!");
        }
        else
        {
            Console.WriteLine("Não foi possível planejar o voo. Verifique as informações.");
        }
    }

    public void ExibirVoosDisponiveis(Aeroporto aeroporto)
    {
        Console.WriteLine($"Voos disponíveis no aeroporto {aeroporto.Nome}:");
        foreach (var voo in aeroporto.VoosDisponiveis)
        {
            voo.ExibirInformacoes();
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        SimuladorVoo simulador = new SimuladorVoo();

        Aeronave aviao1 = new Aeronave { NumeroIdentificacao = 101, Modelo = "Boeing 737", QuantidadeAssentos = 150 };
        Aeronave aviao2 = new Aeronave { NumeroIdentificacao = 202, Modelo = "Airbus A320", QuantidadeAssentos = 180 };

        simulador.AdicionarAeronave(aviao1);
        simulador.AdicionarAeronave(aviao2);

        Aeroporto aeroporto1 = new Aeroporto("Aeroporto Internacional A");
        Aeroporto aeroporto2 = new Aeroporto("Aeroporto Internacional B");

        simulador.AdicionarAeroporto(aeroporto1);
        simulador.AdicionarAeroporto(aeroporto2);

        simulador.PlanejarVoo(aviao1, aeroporto1, aeroporto2);
        simulador.PlanejarVoo(aviao2, aeroporto2, aeroporto1);

        simulador.ExibirVoosDisponiveis(aeroporto1);
        simulador.ExibirVoosDisponiveis(aeroporto2);
    }
}
