using DadosFuncionario.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DadosFuncionario.Controllers
{
    public class ControlWorker
    {
        List<Workers> Worker = new List<Workers>();

        public int IdFunc()
        {
            int i;
            while (true)
            {
                Console.WriteLine("-   Qual o Indice do funcionário?   -");
                Count();

                if (int.TryParse(Console.ReadLine(), out i) && i <= Worker.Count)
                {
                    Console.WriteLine($"Funcionário selecionado: {Worker[i - 1].Name}\n");
                    break;
                }
                Console.WriteLine("Funcionário Inexistente.\n");
            }
            return i;
        }
        public void Add()
        {
            /*Recebe Nome*/
            Console.WriteLine("-     Qual o nome do funcionário?     -\n");
            var name = Console.ReadLine();

            /*Recebe Nivel*/
            Console.WriteLine("\n-     Qual o level do funcionário?    -");
            Console.WriteLine(" -         Niveis existentes         -");

            foreach (WorkerLevel nivel in Enum.GetValues(typeof(WorkerLevel)))
            {
            Console.WriteLine($"                {nivel.ToString()}            ");
            }

            WorkerLevel level;
            while (true)
            {
                if (Enum.TryParse(Console.ReadLine(), out level))
                {
                    if (Enum.IsDefined(typeof(WorkerLevel), level))
                    {
                        break;
                    }
                }
                Console.WriteLine("Valor inválido. Por favor, digite um nível válido.\n");
            }

            /*Recebe Salário Base*/
            double baseSalary;
            while (true)
            {
                Console.WriteLine("-         Qual o salário base?        -\n");

                if (double.TryParse(Console.ReadLine(), out baseSalary))
                {
                    Console.WriteLine($"Salário base: {baseSalary}");
                    break;
                }
                Console.WriteLine("Digite um valor válido para o salário base.\n");       
            }

            /*Recebe Departamento*/
            Console.WriteLine("- Qual o Departamento do funcionário? -\n");
            var departament = Console.ReadLine();

            WorkerDepartament depart = new WorkerDepartament(departament);

            /*Adiciona  Funcionário na lista de Workers*/
            Worker.Add(new Workers(name, level, baseSalary, depart));

            Console.WriteLine($"- Novo funcionário {name} Adicionado -");
        }
        public void Count()
        {
            for (int i = 0; i < Worker.Count; i++)
            {
                Console.WriteLine($"Indice: {i + 1}\n Nome: {Worker[i].Name}");
                Console.WriteLine("--------------------------------------\n");
            }
        }
        public void AddContract()
        {
            /*Identificar o Funcionário*/
            int i = IdFunc();

            /*Adicionar a data do Contrato*/
            DateTime data; string input;
            while (true)
            {
                Console.WriteLine("-     Qual o Mês e ano? MM/yyyy     -");
                input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
                {
                    if (data <= DateTime.Now)
                    {
                        Console.WriteLine($"Data: {data.ToString("MM/yyyy")}");
                        break;
                    }
                }
                Console.WriteLine("Data inválida\n");
            }

            /*Adicionar o valor por hora*/
            double vph;
            while (true)
            {
                Console.WriteLine("- Qual o valor por hora do contrato -");

                if (double.TryParse(Console.ReadLine(), out vph))
                {
                    Console.WriteLine($"\nValor Por Hora: {vph}");
                    break;
                }
                Console.WriteLine("Digite um valor válido para o Valor Hora\n");
            }

            /*Adicionar as horas trabalhadas*/
            double hour;
            while (true)
            {
                Console.WriteLine("-         Horas Trabalhadas         -");

                if (double.TryParse(Console.ReadLine(), out hour))
                {
                    Console.WriteLine($"\nHoras trabalhadas: {hour}");
                    break;
                }
                Console.WriteLine("Digite um valor válido para o Horas Trabalhadas\n");
            }

            Worker[i - 1].AddContract(new Contracts(data, vph, hour));

            Console.WriteLine($"-     Novo Contrato Adicionado     -");
        }
        public int ViewContract()
        {
            int ind = IdFunc();

            Console.WriteLine($"-   Contratos do {Worker[ind].Name} -");

            for (int i = 0; i < Worker[ind].Contracts.Count; i++)
            {
                Console.WriteLine(
                    $"Contrato: #{i + 1} \n" +
                    $"Valores: ---------  \n" +
                    $"Data: {Worker[ind].Contracts[i].Date} \n" +
                    $"Valor p/ Hora: {Worker[ind].Contracts[i].ValuePerHour} \n" +
                    $"Horas Trabalhadas: {Worker[ind].Contracts[i].Hours} "
                );

                Console.WriteLine("\n-------------------------------------------------");
            }
            return ind;
        }
        public void RemoveContract()
        {
            int ind = ViewContract();

            Console.WriteLine("Qual Contrato deseja remover? inserir o numero do contrato\n");
            var x = int.Parse(Console.ReadLine()) - 1;

            Worker[ind].RemoveContract(x);

            Console.WriteLine("Contrato removido com sucesso!");
        }
        public void TotalSalary()
        {
            int i = IdFunc();

            int year;
            while (true)
            {
                Console.WriteLine("-        Salário de Qual ano?       -");

                if (int.TryParse(Console.ReadLine(), out year) && year <= DateTime.Now.Year && year >= 2010)
                {
                    break;
                }
                Console.WriteLine("Digite um valor válido para Ano.\n");
            }

            int month;
            while (true)
            {
                Console.WriteLine("-            De qual mês            -");

                if (int.TryParse(Console.ReadLine(), out month) && month <= DateTime.Now.Month && month >= 1 && month <= 12)
                {
                    break;
                }
                Console.WriteLine("Digite um valor válido para o Mês.\n");
            }

            double sum = Worker[i].Income(month, year);
            Console.WriteLine($"O salário de {Worker[i].Name} no mês {month} foi de {sum}");
        }
    }
}
