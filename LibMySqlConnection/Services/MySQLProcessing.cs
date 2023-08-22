using LibDataHandler.Services;
using LibMySqlConnection.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMySqlConnection.Services
{
    public class MySqlProcessing
    {
        private readonly string _connectionString;
        private MySqlDataAccess db = new MySqlDataAccess();
        public ServiceDataHandeler sdh = new ServiceDataHandeler();

        public MySqlProcessing( string connectionString)
        {
            _connectionString = connectionString;
            sdh.BufferDataCollection = new List<VisiwinDataModel>(GetAllData());
           
        }
        private List<VisiwinDataModel> GetAllData()
        {
            List<VisiwinDataModel> output = new List<VisiwinDataModel>();
            string sql = "select id, CarrierNumber, PositionId from insightpositions.positions";

            try
            {
                output = db.LoadedData<VisiwinDataModel, dynamic>(sql, new { }, _connectionString);
            }
            catch (Exception ex)
            {

                throw;
            }

            return output;
        }

        private void DeleteData(List<VisiwinDataModel> dataToDelete)
        {
            string sql = $"delete from positions where id=@id";
            db.DeleteData<VisiwinDataModel, List<VisiwinDataModel>>(sql , dataToDelete, _connectionString);
        }


        public List<VisiwinDataModel> GetInfluxData()
        {
            List<VisiwinDataModel> output = new List<VisiwinDataModel>();
            List<VisiwinDataModel> _mysql = GetAllData();
            if (_mysql.Count != 0)
            {
                output = _mysql;
                DeleteData(_mysql);
                return output;
            }
            else
            {
                if (_connectionString.Contains("localhost"))
                {
                    List<VisiwinDataModel> dataToSend= new List<VisiwinDataModel>();
                    Random rnd= new Random();
                    for (int i = 0; i < 10; i++)
                    {
                        VisiwinDataModel visiwinDataModel = new VisiwinDataModel();
                        visiwinDataModel.id = i;
                        visiwinDataModel.CarrierNumber =  100+i;
                        visiwinDataModel.PositionId = (i + 1) *rnd.Next() ;
                        dataToSend.Add(visiwinDataModel);
                    }
                    string sql = $"insert into positions(CarrierNumber, PositionId) value (@NameData, @ValueData)";
                    db.SaveData(sql,dataToSend,_connectionString);
                }
                return output;
            }

           
        }
    }
}
