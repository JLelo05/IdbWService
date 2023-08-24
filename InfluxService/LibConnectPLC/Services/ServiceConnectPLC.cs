using LibDataHandler.Interfaces;
using LibDataHandler.Models;
using S7.Net;
using S7.Net.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LibDataHandler.Services
{
    public class ServiceConnectPLC
    {
        public bool conectionPLC;
        ServiceDataHandeler Datahandeler;
        public  DataBatchModel OutputData { get; set; }
        public ServiceConnectPLC(ServiceDataHandeler data)
        {
            Datahandeler = data;
            using (var plc = new Plc(CpuType.S71500, "192.168.8.30", 0, 1)) // eaton connection 1500
            {
                try
                {
                    plc.Open();
                    conectionPLC= true;
                }
                catch (Exception ex)
                 {

                    Console.WriteLine(ex.Message); 
                    conectionPLC = false;
                 }
                OutputData = Datahandeler.GetPLCValues(plc);
            }
            //using (var plc = new Plc(CpuType.S71200, "192.168.0.231", 0, 1)) // local connection 1200
            //{
            //    try
            //    {
            //        plc.Open();
            //    }
            //    catch (Exception ex)
            //    {

            //        Console.WriteLine(ex.Message); ;
            //    }
            //    OutputData = Datahandeler.GetPLCValues(plc);
            //}
        }
    }
}
