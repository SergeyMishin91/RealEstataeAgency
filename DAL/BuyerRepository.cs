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
                using (SqlCommand insertCommand = new SqlCommand("Insert Into dbo.Buyer" +
                               "(BuyerID, BuyerName, BuyerAdress, BuyerUNP, " +
                               "BuyerPhone, BuyerRequest) " +
                               "Values(@BuyerID, @BuyerName, @BuyerAdress, @BuyerUNP, @BuyerPhone," +
                               "@BuyerRequest)", connection))
                {

                    foreach (Buyer _buyer in _buyersCollection)
                    {
                        insertCommand.Parameters.Clear();

                        insertCommand.Parameters.AddWithValue("@BuyerID", typeof(string)).Value = buyer.BuyerID;
                        insertCommand.Parameters.AddWithValue("@BuyerName", typeof(string)).Value = buyer.BuyerName;
                        insertCommand.Parameters.AddWithValue("@BuyerAdress", typeof(string)).Value = buyer.BuyerAdress;
                        insertCommand.Parameters.AddWithValue("@BuyerUNP", typeof(string)).Value = buyer.BuyerUNP;
                        insertCommand.Parameters.AddWithValue("@BuyerPhone", typeof(string)).Value = buyer.BuyerPhone;
                        insertCommand.Parameters.AddWithValue("@BuyerRequest", typeof(string)).Value = buyer.BuyerRequest;
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
                               "WHERE BuyerID = @BuyerID", connection))
                {
                    deleteCommand.Parameters.Clear();
                    deleteCommand.Parameters.AddWithValue("@BuyerID", typeof(string)).Value = buyer.BuyerID;

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

                using (SqlCommand updateCommand = new SqlCommand("UPDATE dbo.Buyer " +
                               "SET " +
                               "BuyerName = @BuyerName, " +
                               "BuyerAdress = @BuyerAdress, " +
                               "BuyerUNP = @BuyerUNP, " +
                               "BuyerPhone = @BuyerPhone, " +
                               "BuyerRequest = @BuyerRequest, " +

                               "WHERE BuyerID = @BuyerID", connection))
                {
                    updateCommand.Parameters.Clear();

                    updateCommand.Parameters.AddWithValue("@BuyerName", typeof(string)).Value = buyer.BuyerName;
                    updateCommand.Parameters.AddWithValue("@BuyerAdress", typeof(string)).Value = buyer.BuyerAdress;
                    updateCommand.Parameters.AddWithValue("@BuyerUNP", typeof(string)).Value = buyer.BuyerUNP;
                    updateCommand.Parameters.AddWithValue("@BuyerPhone", typeof(string)).Value = buyer.BuyerPhone;
                    updateCommand.Parameters.AddWithValue("@BuyerRequest", typeof(string)).Value = buyer.BuyerRequest;

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

                        new_buyer.BuyerID = (Int32)reader.GetValue(0);
                        new_buyer.BuyerName = (string)reader.GetValue(1);
                        new_buyer.BuyerAdress = (string)reader.GetValue(2);
                        new_buyer.BuyerUNP = (Int32)reader.GetValue(3);
                        new_buyer.BuyerPhone = (string)reader.GetValue(4);
                        new_buyer.BuyerRequest = (string)reader.GetValue(5);
                        
                        _buyersCollection.Add(new_buyer);
                    }
                    connection.Close();
                }
                return _buyersCollection;

            }
        }
    }
}
