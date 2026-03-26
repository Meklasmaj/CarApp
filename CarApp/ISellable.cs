using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    public interface ISellable
    {
        double Price { get; }
       string GetInformation();
    }
}
