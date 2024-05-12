using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosFuncionario.View
{
    public static class Menu
    {
        public static void Use()
        {
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║      Sistema de Funcionários       ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            Console.WriteLine("║                                    ║");
            Console.WriteLine("║  1. Cadastrar Novo Funcionário     ║");
            Console.WriteLine("║  2. Listar funcionários            ║");
            Console.WriteLine("║  3. Adicionar Contrato             ║");
            Console.WriteLine("║  4. Ver Contratos                  ║");
            Console.WriteLine("║  5. Remover Contrato               ║");
            Console.WriteLine("║  6. Holerite Do Funcionário        ║");
            Console.WriteLine("║  7. Sair                           ║");
            Console.WriteLine("║                                    ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.Write("Realizar:  ");
        }
    }
}
