using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosFuncionario.Entities
{
    public class Workers
    {
        /*Attributes*/
        public string Name { get; set; }
        private WorkerLevel Level { get; set; }
        private double BaseSalary {  get; set; }
        public WorkerDepartament Departament {  get; set; }
        public List<Contracts> Contracts { get; private set; } = new List<Contracts>();

        /*Methods*/
        public Workers(string name, WorkerLevel level, double baseSalary, WorkerDepartament departament)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddContract(Contracts contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(int contract)
        {
            Contracts.RemoveAt(contract);
        }

        public double Income(int month, int year)
        {
            double sum = BaseSalary;

            foreach (Contracts contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}
