using LibDataHandler.Enums;
using LibDataHandler.Interfaces;
using LibDataHandler.Models;
using LibMySqlConnection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LibDataHandler.Services
{
    public class ServiceDataHandeler
    {

        public List<VisiwinDataModel> BufferDataCollection { get; set; }
        public ServiceDataHandeler()
        {
          

        }

        //old plc stuff read data from plc and conver them into variable neccesy to plc LIB
        //public DataBatchModel GetInputValues(Plc plc)
        //{
        //    BufferDataCollection = new DataBatchModel(DataCollection);
        //    try
        //    {
        //        foreach (var item in DataCollection.realData)
        //        {
        //            item.Value = ((uint)plc.Read(item.Address)).ConvertToFloat();
        //        }
        //        foreach (var item in DataCollection.boolData)
        //        {
        //            item.Value = (bool)plc.Read(item.Address);
        //        }
        //        DataCollection.DataRecieved = true;
        //        if (!_startSequence)
        //        {
        //            CompareData(DataCollection, BufferDataCollection);
        //        }
        //        _startSequence = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        DataCollection.DataRecieved = false;
        //    }
        //    return DataCollection;
        //}

        //private void CompareData(DataBatchModel newData, DataBatchModel oldData)
        //{
        //    if (newData.realData != null && !newData.realData.SequenceEqual(oldData.realData))
        //    {
        //        int i = 0;
        //        foreach (var newItem in newData.realData)
        //        {
        //            if (newItem.Value.Equals(oldData.realData[i].Value))
        //            {
        //                newItem.IsChanged = false;
        //            }
        //            else newItem.IsChanged = true;
        //            i++;
        //        }
        //    }
        //    if (newData.boolData != null)
        //    {
        //        int i = 0;
        //        foreach (var newItem in newData.boolData)
        //        {
        //            if (newItem.Value.Equals(oldData.boolData[i].Value))
        //            {
        //                newItem.IsChanged = false;
        //            }
        //            else newItem.IsChanged = true;
        //            i++;
        //        }
        //    }

        //}
        public List<VisiwinDataModel> CompareData(List<VisiwinDataModel> realTimeData)
        {
            List<VisiwinDataModel> output=null;



            return output;

        }
    }
}
