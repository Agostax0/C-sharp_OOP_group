
using System;

namespace AdvancedCalculator.Pesic
{
    public interface Operation
    {
        Double getNumericResult(Double val);

        Operation getDerivative();

        string ToString();
    }
}
