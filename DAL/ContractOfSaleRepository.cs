using DAL.Properties;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace DAL
{
    class ContractOfSaleRepository : IContractOfSaleRepository
    {
        public ObservableCollection<ContractOfSale> _cosCollection = new ObservableCollection<ContractOfSale>();

        public void AddContractOfSale(ContractOfSale cos)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {
                using (SqlCommand insertCommand = new SqlCommand("INSERT INTO ContractOfSale" +
                               "(ContractOfSaleID, ContractOfSaleNumber, ContractOfSaleDate, ContractOfSaleOwner, " +
                               "ContractOfSaleBuyer, ContractOfSaleCost) " +
                               "Values(@ContractOfSaleID, @ContractOfSaleNumber, @ContractOfSaleDate, @ContractOfSaleOwner, @ContractOfSaleBuyer," +
                               "@ContractOfSaleCost)", connection))
                {

                    foreach (ContractOfSale _cos in _cosCollection)
                    {
                        insertCommand.Parameters.Clear();

                        insertCommand.Parameters.AddWithValue("@ContractOfSaleID", typeof(string)).Value = cos.ContractOfSaleID;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleNumber", typeof(string)).Value = cos.ContractOfSaleNumber;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleDate", typeof(string)).Value = cos.ContractOfSaleDate;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleOwner", typeof(string)).Value = cos.ContractOfSaleOwner;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleBuyer", typeof(string)).Value = cos.ContractOfSaleBuyer;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleCost", typeof(string)).Value = cos.ContractOfSaleCost;
                        //insertCommand.Parameters.AddWithValue("@OwnerContractOfSaleID", typeof(string)).Value = owner.OwnerContractOfSaleID;

                    }
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        public void DeleteContractOfSale(ContractOfSale cos)
        {
            throw new NotImplementedException();
        }

        public void UpdateContractOfSale(ContractOfSale cos)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContractOfSale> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {
                connection.Open();

                string sql = "SELECT * FROM ContractOfSale";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ContractOfSale new_cos = new ContractOfSale();

                        new_cos.ContractOfSaleID = (Int32)reader.GetValue(0);
                        new_cos.ContractOfSaleNumber = (string)reader.GetValue(4);
                        new_cos.ContractOfSaleDate = (DateTime)reader.GetValue(5);
                        new_cos.ContractOfSaleOwner = (string)reader.GetValue(6);
                        new_cos.ContractOfSaleBuyer = (string)reader.GetValue(7);
                        new_cos.ContractOfSaleCost = (double)reader.GetValue(8);
                        //new_buyer.ContractOfSaleID = (string)reader.GetValue(6).ToString();


                        _cosCollection.Add(new_cos);
                    }
                    connection.Close();
                }
                return _cosCollection;

            }
        }


    }
}
