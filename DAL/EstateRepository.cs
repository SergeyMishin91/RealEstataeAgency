using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL.Properties;
using Repository;
using System.Collections.ObjectModel;


namespace DAL
{

    public class EstateRepository : IEstatesRepository
    {
       
        public ObservableCollection<Estate> _estatesObsColl = new ObservableCollection<Estate>();

        public void DeleteEstate(Estate estate)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {

                using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM dbo.Estate " +
                               "WHERE EstateID = @EstateID", connection))
                {
                    deleteCommand.Parameters.Clear();
                    deleteCommand.Parameters.AddWithValue("@EstateID", typeof(string)).Value = estate.EstateID;

                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateEstate(Estate estate)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {

                using (SqlCommand updateCommand = new SqlCommand("UPDATE dbo.Estate " +
                               "SET " +
                               "EstateName = @EstateName, " +
                               "EstateInventoryNumber = @EstateInventoryNumber, " +
                               "EstateSpace = @EstateSpace, " +
                               "EstateAdress = @EstateAdress, " +
                               "EstateFunction = @EstateFunction, " +
                               "EstateYear = @EstateYear, " +
                               "EstateWall = @EstateWall, " +
                               "EstateState = @EstateState, " +
                               "EstateOwner = @EstateOwner, " +
                               "EstateRentPrice = @EstateRentPrice, " +
                               "EstateCostOfSale =  @EstateCostOfSale, " +
                               "EstateDescription = @EstateDescription, " +
                               "EstateDeal = @EstateDeal " +
                               "WHERE EstateID = @EstateID", connection))
                {
                    updateCommand.Parameters.Clear();

                    updateCommand.Parameters.AddWithValue("@EstateName", typeof(string)).Value = estate.EstateName;
                    updateCommand.Parameters.AddWithValue("@EstateInventoryNumber", typeof(string)).Value = estate.EstateInventoryNumber;
                    updateCommand.Parameters.AddWithValue("@EstateSpace", typeof(string)).Value = estate.EstateSpace;
                    updateCommand.Parameters.AddWithValue("@EstateAdress", typeof(string)).Value = estate.EstateAdress;
                    updateCommand.Parameters.AddWithValue("@EstateFunction", typeof(string)).Value = estate.EstateFunction;
                    updateCommand.Parameters.AddWithValue("@EstateYear", typeof(string)).Value = estate.EstateYear;
                    updateCommand.Parameters.AddWithValue("@EstateWall", typeof(string)).Value = estate.EstateWall;
                    updateCommand.Parameters.AddWithValue("@EstateState", typeof(string)).Value = estate.EstateState;
                    updateCommand.Parameters.AddWithValue("@EstateOwner", typeof(string)).Value = estate.EstateOwner;
                    updateCommand.Parameters.AddWithValue("@EstateRentPrice", typeof(string)).Value = estate.EstateRentPrice;
                    updateCommand.Parameters.AddWithValue("@EstateCostOfSale", typeof(string)).Value = estate.EstateCostOfSale;
                    updateCommand.Parameters.AddWithValue("@EstateDescription", typeof(string)).Value = estate.EstateDescription;
                    updateCommand.Parameters.AddWithValue("@EstateDeal", typeof(string)).Value = estate.EstateDeal;
                    updateCommand.Parameters.AddWithValue("@EstateID", typeof(string)).Value = estate.EstateID;

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void AddEstate(Estate estate)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {

                using (SqlCommand insertCommand = new SqlCommand("Insert Into dbo.Estate" +
                               "(EstateID, EstateName, EstateInventoryNumber, EstateSpace, EstateAdress, EstateFunction, EstateYear, EstateWall," +
                               "EstateState, EstateOwner, EstateRentPrice, EstateCostOfSale, EstateDescription, EstateDeal) " +
                               "Values(@EstateID, @EstateName, @EstateInventoryNumber, @EstateSpace, @EstateAdress,@EstateFunction , @EstateYear, @EstateWall," +
                               "@EstateState, @EstateOwner, @EstateRentPrice, @EstateCostOfSale, @EstateDescription, @EstateDeal)", connection))
                { 
                  
                    foreach (Estate estates in _estatesObsColl)
                    {
                        insertCommand.Parameters.Clear();

                        insertCommand.Parameters.AddWithValue("@EstateID", typeof(string)).Value = estate.EstateID;
                        insertCommand.Parameters.AddWithValue("@EstateName", typeof(string)).Value = estate.EstateName;
                        insertCommand.Parameters.AddWithValue("@EstateInventoryNumber", typeof(string)).Value = estate.EstateInventoryNumber;
                        insertCommand.Parameters.AddWithValue("@EstateSpace", typeof(string)).Value = estate.EstateSpace;
                        insertCommand.Parameters.AddWithValue("@EstateAdress", typeof(string)).Value = estate.EstateAdress;
                        insertCommand.Parameters.AddWithValue("@EstateFunction", typeof(string)).Value = estate.EstateFunction;
                        insertCommand.Parameters.AddWithValue("@EstateYear", typeof(string)).Value = estate.EstateYear;
                        insertCommand.Parameters.AddWithValue("@EstateWall", typeof(string)).Value = estate.EstateWall;
                        insertCommand.Parameters.AddWithValue("@EstateState", typeof(string)).Value = estate.EstateState;
                        insertCommand.Parameters.AddWithValue("@EstateOwner", typeof(string)).Value = estate.EstateOwner;
                        insertCommand.Parameters.AddWithValue("@EstateRentPrice", typeof(string)).Value = estate.EstateRentPrice;
                        insertCommand.Parameters.AddWithValue("@EstateCostOfSale", typeof(string)).Value = estate.EstateCostOfSale;
                        insertCommand.Parameters.AddWithValue("@EstateDescription", typeof(string)).Value = estate.EstateDescription;
                        insertCommand.Parameters.AddWithValue("@EstateDeal", typeof(string)).Value = estate.EstateDeal;

                    }
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        public IEnumerable<Estate> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {
                connection.Open();

                string sql = "SELECT * FROM Estate";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Estate new_estate = new Estate();

                        new_estate.EstateID = (Int32)reader.GetValue(0);
                        //new_estate.EstatePhoto = (byte[])reader.GetValue(1);
                        new_estate.EstateFunction = (string)reader.GetValue(2);
                        new_estate.EstateName = (string)reader.GetValue(3);
                        new_estate.EstateInventoryNumber = (string)reader.GetValue(4);
                        new_estate.EstateSpace = (double)reader.GetValue(5);
                        new_estate.EstateAdress = (string)reader.GetValue(6);
                        new_estate.EstateYear = (Int32)reader.GetValue(7);
                        new_estate.EstateWall = (string)reader.GetValue(8);
                        new_estate.EstateState = (string)reader.GetValue(9);
                        new_estate.EstateOwner = (string)reader.GetValue(10);
                        new_estate.EstateRentPrice = (double)reader.GetValue(11);
                        new_estate.EstateCostOfSale = (double)reader.GetValue(12);
                        new_estate.EstateDescription = (string)reader.GetValue(13);
                        new_estate.EstateDeal = (string)reader.GetValue(14);

                        _estatesObsColl.Add(new_estate);
                    }
                    connection.Close();
                }
                return _estatesObsColl;
                
            }
        }
    }
}
