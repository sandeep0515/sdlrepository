using ChangeCalculatorService.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ChangeCalculatorService
{
    // Interface works when we need dependency injection
    public class CalculatorService : ICalculatorService
    {
        public List<string> CalculateChange(string amount)
        {
            try
            {
                decimal formatAmount = Convert.ToDecimal(amount);
                List<string> change = new List<string>();
                List<decimal> denominations = GetDenominations();
                foreach (var note in denominations)
                {
                    int counter = 0;
                    while (note <= formatAmount)
                    {
                        counter++;
                        formatAmount = formatAmount - note;
                    }
                    if (counter > 0)
                    {
                        if (note >= 1.00m)
                        {
                            var culture = new CultureInfo("fr-FR");
                            culture.NumberFormat.CurrencyPositivePattern = 0;
                            culture.NumberFormat.CurrencyNegativePattern = 2;
                            culture.NumberFormat.CurrencyDecimalSeparator = CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator;
                            change.Add($"{counter} X {note.ToString("C", culture)}");
                        }
                        else
                        {
                            change.Add($"{counter} X {FormatPence(note)}P");
                        }
                    }
                }
                return change;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Sorry, Amount should be only in numbers");
                throw ex;
            }
        }

        public List<decimal> GetDenominations()
        {
            // ToDo: Get denominations through DB
            return new List<decimal> { 50.00m, 20.00m, 10.00m, 5.00m, 2.00m, 1.00m, 0.50m, 0.20m, 0.10m, 0.05m, 0.02m, 0.01m };
        }

        private int FormatPence(decimal amount)
        {
            return Convert.ToInt32(amount.ToString("0.00").Split(".")[1]);            
        }
    }
}
