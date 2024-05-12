using DadosFuncionario.Controllers;
using DadosFuncionario.View;
using System.Runtime.InteropServices;
using System;

class Program
{
    static void Main(string[] args)
    {
        int op;
        do
        {
            Menu.Use();
            op = int.Parse(Console.ReadLine());

            MenuOptions.Options(op);

            Console.WriteLine("\nPrecione qualquer tecla para continuar");
            Console.ReadLine();
            Console.Clear();

        } while (op != 7);
        
    }
}