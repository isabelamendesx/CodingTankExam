namespace Questão3;

/*
 * 3 - Escreva um programa que recebe como entrada uma frase do usuário. Como saída o programa deve exibir no
 * console as seguintes informações: quantas palavras são maiúsculas, quantas palavras são minúsculas, quantas
 * palavras iniciam com letra maiúscula, quantas palavras iniciam com letra minúscula e a quantidade de palavras.
 */

public class Class1
{
       public static void Main()
    {
        do
        {
            string entrada;

            while (true)
            {
                entrada = ObterFrase();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("A frase não pode estar vazia. Por favor, tente novamente.");
                }
                else if (entrada.All(char.IsDigit))
                {
                    Console.WriteLine("A frase não pode ser apenas números. Por favor, tente novamente.");
                }
                else
                {
                    break;
                }
            }

            AnalisarFrase(entrada);

            Console.Write("Deseja iniciar novamente? (Digite 'sim' para continuar): ");
        } while (Console.ReadLine().ToLower() == "sim");
    }

    static string ObterFrase()
    {
        Console.WriteLine("Digite uma frase:");
        return Console.ReadLine();
    }

    static void AnalisarFrase(string frase)
    {
        string[] palavras = SepararPalavras(frase);

        string[] palavrasMaiusculas, palavrasMinusculas, palavrasInicioMaiuscula, palavrasInicioMinuscula;
        int contagemMaiusculas, contagemMinusculas, contagemMaiusculaInicio, contagemMinusculaInicio;

        SepararPalavrasPorCaracteristicas(palavras, out palavrasMaiusculas, out palavrasMinusculas, out palavrasInicioMaiuscula, out palavrasInicioMinuscula,
                                          out contagemMaiusculas, out contagemMinusculas, out contagemMaiusculaInicio, out contagemMinusculaInicio);

        Console.WriteLine($"Palavras inteiramente maiúsculas ({contagemMaiusculas}): {string.Join(", ", palavrasMaiusculas.Take(contagemMaiusculas))}");
        Console.WriteLine($"Palavras inteiramente minúsculas ({contagemMinusculas}): {string.Join(", ", palavrasMinusculas.Take(contagemMinusculas))}");
        Console.WriteLine($"Palavras que começam com letra maiúscula ({contagemMaiusculaInicio}): {string.Join(", ", palavrasInicioMaiuscula.Take(contagemMaiusculaInicio))}");
        Console.WriteLine($"Palavras que começam com letra minúscula ({contagemMinusculaInicio}): {string.Join(", ", palavrasInicioMinuscula.Take(contagemMinusculaInicio))}");
        Console.WriteLine($"Quantidade de palavras: {palavras.Length}");
    }

    static string[] SepararPalavras(string entrada)
    {
        return entrada.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
    }

    static void SepararPalavrasPorCaracteristicas(string[] palavras, out string[] palavrasMaiusculas, out string[] palavrasMinusculas,
                                                  out string[] palavrasInicioMaiuscula, out string[] palavrasInicioMinuscula,
                                                  out int contagemMaiusculas, out int contagemMinusculas, out int contagemMaiusculaInicio, out int contagemMinusculaInicio)
    {
        contagemMaiusculas = contagemMinusculas = contagemMaiusculaInicio = contagemMinusculaInicio = 0;
        palavrasMaiusculas = new string[palavras.Length];
        palavrasMinusculas = new string[palavras.Length];
        palavrasInicioMaiuscula = new string[palavras.Length];
        palavrasInicioMinuscula = new string[palavras.Length];

        foreach (string palavra in palavras)
        {
            if (string.IsNullOrEmpty(palavra))
                continue;

            if (palavra == palavra.ToUpper())
            {
                palavrasMaiusculas[contagemMaiusculas] = palavra;
                contagemMaiusculas++;
            }
            else if (palavra == palavra.ToLower())
            {
                palavrasMinusculas[contagemMinusculas] = palavra;
                palavrasInicioMinuscula[contagemMinusculaInicio] = palavra;
                contagemMinusculas++;
                contagemMinusculaInicio++;
            }
            else if (char.IsUpper(palavra[0]))
            {
                palavrasInicioMaiuscula[contagemMaiusculaInicio] = palavra;
                contagemMaiusculaInicio++;
            }
            else
            {
                palavrasInicioMinuscula[contagemMinusculaInicio] = palavra;
                contagemMinusculaInicio++;
            }
        }
    }
}