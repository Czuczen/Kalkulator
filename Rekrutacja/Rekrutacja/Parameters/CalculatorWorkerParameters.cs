using Rekrutacja.Enums;
using Soneta.Business;
using Soneta.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja.Parameters
{
    public class CalculatorWorkerParameters : ContextBase
    {
        [Caption("Figura")]
        public Figure Figure { get; set; }

        [Caption("Zmienna A")]
        public string VariableA { get; set; }

        [Caption("Zmienna B")]
        public string VariableB { get; set; }


        public CalculatorWorkerParameters(Context context) : base(context)
        {
        }


        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(VariableA))
                throw new ArgumentException("Zmienna A jest wymagana.");

            if (Figure != Figure.Kolo && Figure != Figure.Kwadrat && string.IsNullOrWhiteSpace(VariableB))
                throw new ArgumentException("Zmienna B jest wymagana w przypadku figur innych niż okrąg i kwadrat.");

            if (!IsNumeric(VariableA))
                throw new ArgumentException("Zmienna A musi być wartością liczbową.");

            if (!string.IsNullOrWhiteSpace(VariableB) && !IsNumeric(VariableB))
                throw new ArgumentException("Zmienna B musi być wartością liczbową.");
        }

        private bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c) && c != '-')
                    return false;
            }

            return true;
        }
    }
}
