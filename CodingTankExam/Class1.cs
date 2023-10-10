namespace CodingTankExam;

public class Class1
{
    public static void Main()
    {
        do
        {
            Console.WriteLine("\nDeseja calcular novamente? (Digite 's' para sim ou qualquer outra tecla para sair)");
                    
        } while (Console.ReadLine().ToLower() == "s");
        
        
    }
    
    public static double LerNumeroDouble(string prompt, int i)
    {
        double numero;
        bool numValido = false;

        do
        {
            Console.Write($"{prompt} {i}: ");
            numValido = double.TryParse(Console.ReadLine(), out numero);

            if (!numValido)
            {
                Console.WriteLine("Você não digitou um número válido. Tente novamente.\n");
            }
        } while (!numValido);

        return numero;
    }
    
    public static int LerNumeroInt(string prompt)
    {
        int numero;
        bool numValido = false;

        do
        {
            Console.Write($"{prompt}: ");
            numValido = int.TryParse(Console.ReadLine(), out numero);

            if (!numValido)
            {
                Console.WriteLine("Você não digitou um número válido. Tente novamente\n.");
            }
        } while (!numValido);

        return numero;
    }
}