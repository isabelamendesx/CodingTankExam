namespace Questão1;

/*
 * 1 - Escreva um programa que faça a leitura de 5 valores Inteiros do usuário. Em seguida, o programa deve exibir no
 * console a informação de quantos dos valores digitados são pares, quantos dos valores digitados são ímpares, quantos
 * deles são positivos e, por fim, quantos são negativos. Cada uma das informações deve ser escrita em uma linha diferente.
 */

public class Class1
{
        public static void Main()
    {
        do
        {
            string entrada = LerEntrada();
            int[] numeros = ObterNumeros(entrada);

            if (numeros.Length == 0)
            {
                Console.WriteLine("Nenhum número válido foi digitado.");
                continue; // Volta ao início do loop
            }

            int posicaoInvalida = -1;

            do
            {
                int[] pares = FiltrarNumeros(numeros, n => n % 2 == 0);
                int[] impares = FiltrarNumeros(numeros, n => n % 2 != 0);
                int[] positivos = FiltrarNumeros(numeros, n => n > 0);
                int[] negativos = FiltrarNumeros(numeros, n => n < 0);

                ExibirResultados("Números pares", pares);
                ExibirResultados("Números ímpares", impares);
                ExibirResultados("Números positivos", positivos);
                ExibirResultados("Números negativos", negativos);

                if (posicaoInvalida >= 0 && posicaoInvalida < numeros.Length)
                {
                    Console.WriteLine($"Valor inválido: {numeros[posicaoInvalida]}. Substitua o valor inválido:");
                    string novoValor = Console.ReadLine();
                    if (int.TryParse(novoValor, out int novoNumero))
                    {
                        numeros[posicaoInvalida] = novoNumero;
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido. Por favor, substitua novamente.");
                    }
                }

                Console.WriteLine("Deseja reiniciar o programa? (digita 'sim' para sim, qualquer tecla para sair)");
            } while (Console.ReadLine().ToLower() == "s");

        } while (true); // Loop externo sem fim
    }

    static string LerEntrada()
    {
        Console.WriteLine("Digite números inteiros:");
        return Console.ReadLine();
    }

    static int[] ObterNumeros(string entrada)
    {
        string[] valores = entrada.Split(new char[] { ',', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numeros = new int[valores.Length];
        int contador = 0;

        for (int i = 0; i < valores.Length; i++)
        {
            if (int.TryParse(valores[i], out int numero))
            {
                numeros[contador++] = numero;
            }
            else
            {
                Console.WriteLine($"Valor inválido: {valores[i]}. Substitua o valor inválido:");
                string novoValor = Console.ReadLine();
                if (int.TryParse(novoValor, out int novoNumero))
                {
                    numeros[contador++] = novoNumero;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Por favor, substitua novamente.");
                    i--;
                }
            }
        }

        // Redimensiona o array para conter apenas os números válidos.
        Array.Resize(ref numeros, contador);

        return numeros;
    }

    static int[] FiltrarNumeros(int[] numeros, Func<int, bool> condicao)
    {
        int contador = 0;
        foreach (int numero in numeros)
        {
            if (condicao(numero))
            {
                contador++;
            }
        }

        int[] result = new int[contador];
        contador = 0;

        foreach (int numero in numeros)
        {
            if (condicao(numero))
            {
                result[contador++] = numero;
            }
        }

        return result;
    }

    static void ExibirResultados(string categoria, int[] numeros)
    {
        Console.Write($"{categoria}: ");
        if (numeros.Length > 0)
        {
            Console.Write(numeros[0]);

            for (int i = 1; i < numeros.Length; i++)
            {
                Console.Write($", {numeros[i]}");
            }
        }

        Console.WriteLine();
    }
}