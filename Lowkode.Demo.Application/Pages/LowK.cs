using Microsoft.AspNetCore.Components;
using System;

namespace Lowkode.Demo.Application.Data
{
    public interface LowK :  IComponent
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
