using DadosFuncionario.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosFuncionario.Controllers
{
    public static class MenuOptions
    {
        public static ControlWorker work = new ControlWorker();
        public static void Options(int op)
        {
            switch (op)
            {
                case 1:
                    work.Add();  
                    break;

                case 2:
                    work.Count();
                    break;

                case 3:
                    work.AddContract();
                    break;

                case 4:
                    work.ViewContract();
                    break;

                case 5:
                    work.RemoveContract();
                    break;

                case 6:
                    work.TotalSalary();
                    break;

                default:
                    Console.WriteLine("Insira um valor Válido!");
                    break;
            }

        }
    }
}
