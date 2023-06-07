using LibDataHandler.Interfaces;
using LibDataHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDataHandler.Models
{
    public  class DataBatchModel
    {
        public DataBatchModel()
        {
            boolData = new List<BoolDataModel>();
            boolData = new List<BoolDataModel>();
            intData = new List<IntDataModel>();
        }

        public DataBatchModel(DataBatchModel data)
        {
            DataRecieved = data.DataRecieved;
            realData = data.realData.ConvertAll(x => new RealDataModel (x));
            boolData = new List<BoolDataModel>(data.boolData);
            intData = new List<IntDataModel>(data.intData);
        }

        public bool DataRecieved { get; set; }
        public List<RealDataModel> realData { get; set; } 
        public List<BoolDataModel> boolData { get; set; }
        public List<IntDataModel> intData { get; set; }

    }
}
