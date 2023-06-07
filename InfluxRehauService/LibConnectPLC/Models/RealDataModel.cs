using LibDataHandler.Enums;
using LibDataHandler.Interfaces;
using System.Diagnostics;

namespace LibDataHandler.Models
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]

    [Serializable]
    public class RealDataModel : IDataModel
    {
       

        public RealDataModel(RealDataModel data)
        {
            Value = data.Value;
            Name = data.Name;
            IsChanged = data.IsChanged;
            Address = data.Address;
            TypeMeasure = data.TypeMeasure;
        }

        public RealDataModel()
        {
            
        }

        public float Value { get ; set ; }
        public string? Name { get ; set; }
        public bool IsChanged { get; set; }
        public string? Address { get; set; }
        public MeasureType TypeMeasure { get; set ; }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
