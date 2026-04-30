using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp.Core.Interfaces;

internal interface IInsurable
{
    string RegistrationNumber { get; }
    double GetInsuranceRate();
}
