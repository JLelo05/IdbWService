using LibDataHandler.Enums;
using LibDataHandler.Interfaces;

namespace LibDataHandler.Models
{
    public class IntDataModel : IDataModel
    {
        public int Value { get ; set ; }
        public string? Name { get ; set; }
        public bool IsChanged { get; set; }
        public string? Address { get ; set ; }
        public MeasureType TypeMeasure { get ; set; }
    }
}
