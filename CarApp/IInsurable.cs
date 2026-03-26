using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    internal interface IInsurable
    {
        string RegistrationNumber { get; }
        double GetInsuranceRate();
    }
}
