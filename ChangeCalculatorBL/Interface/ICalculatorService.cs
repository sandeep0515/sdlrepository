using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeCalculatorService.Interface
{
    public interface ICalculatorService
    {
        List<decimal> GetDenominations();
        List<string> CalculateChange(string amount);
    }
}
