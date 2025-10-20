using una_psc_alg_revisao_a1_ex03.Models;

// Vetor de 15 notas (0-100) - preenchimento manual de exemplo
int[] notasRisco = new int[15]
{
	85, 72, 60, 95, 40, // índices 0-4 (sêniores)
	10, 18, 55, 33, 47, // índices 5-9 (juniores)
	90, 12, 77, 64, 28  // índices 10-14 (juniores)
};

var processador = new ProcessadorRisco(notasRisco);

Console.WriteLine("Processamento da Análise de Risco:");
Console.WriteLine("------------------------------------------");

double media = processador.CalcularMediaPonderada();
var (otimistas, alarmantes) = processador.ContarCategorias();

Console.WriteLine($"Média Ponderada do Risco: {media:F2}");
Console.WriteLine($"Analistas Otimistas (Nota <= 20): {otimistas}");
Console.WriteLine($"Analistas Alarmantes (Nota >= 90): {alarmantes}");
Console.WriteLine("------------------------------------------");
Console.WriteLine($"Parecer Final: {processador.GerarParecer(media)}");
