using LibDataHandler.Enums;
using LibDataHandler.Interfaces;

namespace LibDataHandler.Models
{
    public class BoolDataModel : IDataModel
    {
        public bool Value { get; set; }
        public string? Name { get; set; }
        public bool IsChanged { get; set; }
        public string? Address { get ; set ; }
        public MeasureType TypeMeasure { get ; set ; }
    }
}
