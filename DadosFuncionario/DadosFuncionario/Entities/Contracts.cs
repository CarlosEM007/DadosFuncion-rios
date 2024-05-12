using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosFuncionario.Entities
{
    public class Contracts
    {
        /*Attributes*/
        public DateTime Date {  get; set; }
        public double ValuePerHour { get; set; }
        public double Hours {  get; set; }

        public Contracts(DateTime data, double valueHour, double totalHour) 
        {
            Date = data;
            ValuePerHour = valueHour;
            Hours = totalHour;
        }

        public double TotalValue()
        {
            return Hours * ValuePerHour;
        }
    }
}
