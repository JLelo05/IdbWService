using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using app.Services;
using Coravel.Invocable;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using LibMySqlConnection.Models;
using LibMySqlConnection.Services;

namespace app.Invocables
{
    public class InfluxWriteData : IInvocable
    {
        private readonly InfluxDBService _service;
        private readonly ServiceMySqlConnection _clientMySql;  
        List<PointData> points;
        List<VisiwinDataModel> data = new List<VisiwinDataModel>(); 
        public InfluxWriteData(InfluxDBService service, ServiceMySqlConnection clientMySql)
        {
            _service = service;
            _clientMySql = clientMySql;
        }
        public Task Invoke()
        {
            points = new List<PointData>();
            try
            {
               data = _clientMySql.sql.GetInfluxData();
            }
            catch (Exception e )
            {

                throw e;
            }

            if (data.Count!=0)
            {
                _service.Write(write =>
                {
                    foreach (var item in data)
                    {
                            var point = PointData.Measurement(item.NameData)
                          .Field("value", item.ValueData)
                          .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
                            points.Add(point);
                    }
                    write.WritePoints(points, "i4TestingDB", "i4industry");
                    //write.WritePoints(points, "RehauAurum", "i4industry");
                });
            }
            return Task.CompletedTask;
        }
        
    }
}
