using Repository;
using System;
using System.Collections.Generic;
using Model;
using System.Data.SqlClient;
using DAL.Properties;
using System.Collections.ObjectModel;

namespace DAL
{
    public class BuyerRepository : IBuyerRepository
    {
        public ObservableCollection<Buyer> _buyersCollection = new ObservableCollection<Buyer>();

        public void AddBuyer(Buyer buyer)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {
                using (SqlCommand insertCommand = new SqlCommand("Insert Into dbo.Owner" +
                               "(EstateBuyerID, EstateBuyerName, EstateBuyerAdress, EstateBuyerUNP, " +
                               "EstateBuyerPhone, EstateBuyerRequest) " +
                               "Values(@EstateBuyerID, @EstateBuyerName, @EstateBuyerAdress, @EstateBuyerUNP, @EstateBuyerPhone," +
                               "@EstateBuyerRequest)", connection))
                {

                    foreach (Buyer _buyer in _buyersCollection)
                    {
                        insertCommand.Parameters.Clear();

                        insertCommand.Parameters.AddWithValue("@EstateBuyerID", typeof(string)).Value = buyer.EstateBuyerID;
                        insertCommand.Parameters.AddWithValue("@EstateBuyerName", typeof(string)).Value = buyer.EstateBuyerName;
                        insertCommand.Parameters.AddWithValue("@EstateBuyerAdress", typeof(string)).Value = buyer.EstateBuyerAdress;
                        insertCommand.Parameters.AddWithValue("@EstateBuyerUNP", typeof(string)).Value = buyer.EstateBuyerUNP;
                        insertCommand.Parameters.AddWithValue("@EstateBuyerPhone", typeof(string)).Value = buyer.EstateBuyerPhone;
                        insertCommand.Parameters.AddWithValue("@EstateBuyerRequest", typeof(string)).Value = buyer.EstateBuyerRequest;
                        //insertCommand.Parameters.AddWithValue("@OwnerContractOfSaleID", typeof(string)).Value = owner.OwnerContractOfSaleID;

                    }
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        public void DeleteBuyer(Buyer buyer)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {

                using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM dbo.Buyer " +
                               "WHERE EstateBuyerID = @EstateBuyerID", connection))
                {
                    deleteCommand.Parameters.Clear();
                    deleteCommand.Parameters.AddWithValue("@EstateBuyerID", typeof(string)).Value = buyer.EstateBuyerID;

                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateBuyer(Buyer buyer)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {

                using (SqlCommand updateCommand = new SqlCommand("UPDATE dbo.Owner " +
                               "SET " +
                               "EstateBuyerName = @EstateBuyerName, " +
                               "EstateBuyerAdress = @EstateBuyerAdress, " +
                               "EstateBuyerUNP = @EstateBuyerUNP, " +
                               "EstateBuyerPhone = @EstateBuyerPhone, " +
                               "EstateBuyerRequest = @EstateBuyerRequest, " +
                               //"OwnerContractOfSaleID = @OwnerContractOfSaleID, " +

                               "WHERE EstateBuyerID = @EstateBuyerID", connection))
                {
                    updateCommand.Parameters.Clear();

                    updateCommand.Parameters.AddWithValue("@EstateBuyerName", typeof(string)).Value = buyer.EstateBuyerName;
                    updateCommand.Parameters.AddWithValue("@EstateBuyerAdress", typeof(string)).Value = buyer.EstateBuyerAdress;
                    updateCommand.Parameters.AddWithValue("@EstateBuyerUNP", typeof(string)).Value = buyer.EstateBuyerUNP;
                    updateCommand.Parameters.AddWithValue("@EstateBuyerPhone", typeof(string)).Value = buyer.EstateBuyerPhone;
                    updateCommand.Parameters.AddWithValue("@EstateBuyerRequest", typeof(string)).Value = buyer.EstateBuyerRequest;
                   // updateCommand.Parameters.AddWithValue("@OwnerContractOfSaleID", typeof(string)).Value = owner.OwnerContractOfSaleID;

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<Buyer> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {
                connection.Open();

                string sql = "SELECT * FROM Buyer";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Buyer new_buyer = new Buyer();

                        new_buyer.EstateBuyerID = (Int32)reader.GetValue(0);
                        new_buyer.EstateBuyerName = (string)reader.GetValue(1);
                        new_buyer.EstateBuyerAdress = (string)reader.GetValue(2);
                        new_buyer.EstateBuyerUNP = (Int32)reader.GetValue(3);
                        new_buyer.EstateBuyerPhone = (string)reader.GetValue(4);
                        new_buyer.EstateBuyerRequest = (string)reader.GetValue(5);
                        //new_buyer.ContractOfSaleID = (string)reader.GetValue(6).ToString();
                        

                        _buyersCollection.Add(new_buyer);
                    }
                    connection.Close();
                }
                return _buyersCollection;

            }
        }
    }
}
