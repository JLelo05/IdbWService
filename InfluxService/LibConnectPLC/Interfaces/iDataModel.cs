using LibDataHandler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDataHandler.Interfaces
{
    public  interface IDataModel
    { 
        public string? Name { get; set; }
        public bool IsChanged { get; set; }
        public string? Address { get; set; }
        public MeasureType TypeMeasure { get; set; }
    }
}
