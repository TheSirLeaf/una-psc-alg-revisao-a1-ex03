using System;

namespace una_psc_alg_revisao_a1_ex03.Models;

public class ProcessadorRisco
{
    private readonly Analista[] Analistas;
    public ProcessadorRisco(int[] notas)
    {
        ArgumentNullException.ThrowIfNull(notas);
        Analistas = new Analista[notas.Length];
        for (int i = 0; i < notas.Length; i++)
            Analistas[i] = new Analista(notas[i]);
    }
    public double CalcularMediaPonderada()
    {
        int somaPesos = 0;
        int somaPonderada = 0;
        for (int i = 0; i < Analistas.Length; i++)
        {
            int peso = (i >= 0 && i <= 4) ? 3 : 1;
            somaPesos += peso;
            somaPonderada += Analistas[i].Nota * peso;
        }

        if (somaPesos == 0) return 0.0;
        return (double)somaPonderada / somaPesos;
    }
    public (int otimistas, int alarmantes) ContarCategorias()
    {
        int otimistas = 0;
        int alarmantes = 0;
        foreach (var a in Analistas)
        {
            if (a.Nota <= 20) otimistas++;
            if (a.Nota >= 90) alarmantes++;
        }
        return (otimistas, alarmantes);
    }
    public string GerarParecer(double media)
    {
        if (media > 70)
            return "Alto Risco: Venda ou reajuste de portfólio recomendado.";
        else if (media >= 40 && media <= 70)
            return "Risco Moderado: Acompanhar de perto, mas manter os ativos.";
        else
            return "Baixo Risco: Excelente momento para capitalização.";
    }
}
