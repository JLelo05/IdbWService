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
            string sql = "select id, NameData, ValueData from datatable";
            return  db.LoadedData<VisiwinDataModel, dynamic>(sql, new { }, _connectionString);
        }

        private void DeleteData(List<VisiwinDataModel> dataToDelete)
        {
            string sql = $"delete from datatable where id=@id";
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
                        visiwinDataModel.NameData = $"Value{i}";
                        visiwinDataModel.ValueData = (i + 1) *rnd.Next() ;
                        dataToSend.Add(visiwinDataModel);
                    }

                    string sql = $"insert into datatable(NameData, ValueData) value (@NameData, @ValueData)";
                    db.SaveData(sql,dataToSend,_connectionString);
                }
                return output;
            }

           
        }
    }
}
