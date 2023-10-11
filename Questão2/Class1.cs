namespace Questão2;

/*
 * 2 - Escreva um programa que calcule e escreva a multiplicação e a divisão inteira de dois números inteiros,
 * N1 por N2, que devem ser lidos do teclado. É importante observar que a máquina que irá executar
 * este programa é capaz de efetuar apenas duas operações matemáticas: adição e subtração. Ou seja, você não poderá usar os operadores de multiplicação, divisão, módulo etc. bem como truncamentos.
*/

public class Class1
{
    public static void Main()
    {
      
        do{    
                Console.Clear();
                Console.WriteLine("--- ESSE PROGRAMA RECEBE DOIS NÚMEROS E REALIZA A DIVISÃO E MULTIPLICAÇÃO MANUAL DOS MESMOS ---\n");
                int numero1 = LerNumero("Digite o primeiro número");
                int numero2 = LerNumero("Digite o segundo número");

                int multiplicacao = multiplicaManualmente(numero1, numero2);
                int divisaoInteira = divideManualmente(numero1, numero2);
                
                Console.WriteLine($"\nMULTIPLICAÇÃO DE {numero1} E {numero2} = {multiplicacao}" );
                Console.WriteLine($"DIVISÃO DE {numero1} E {numero2} = {divisaoInteira}" );
                
                
                Console.WriteLine("\nDeseja realizar outra operação? (Digite 's' para sim ou qualquer outra tecla para sair)");
                        
        } while (Console.ReadLine().ToLower() == "s");
        

    }

    static int divideManualmente(int numero1, int numero2)
    {
        if (numero2 == 0)
        {
            throw new DivideByZeroException("Divisor não pode ser zero.");
        }

        if (numero1 < numero2)
        {
            return 0;
        }

        return 1 + divideManualmente(numero1 - numero2, numero2);
    }
    static int multiplicaManualmente(int n1, int n2)
    {
        if (n2 == 0) // Caso base: quando n2 é igual a zero, o resultado é zero.
        {
            return 0;
        }
        else if (n2 > 0)
        {
            return n1 + multiplicaManualmente(n1, n2 - 1); // Adiciona n1 repetidamente n2 vezes.
        }
        else
        {
            return -multiplicaManualmente(n1, -n2); // Lidando com números negativos.
        }
    }
    
    public static int LerNumero(string prompt)
    {
        int numero;
        bool numValido = false;

        do
        {
            Console.Write($"{prompt}: ");
            numValido = int.TryParse(Console.ReadLine(), out numero);

            if (!numValido)
            {
                Console.WriteLine("Você não digitou um número válido. Tente novamente.");
            }
        } while (!numValido);

        return numero;
    }


}