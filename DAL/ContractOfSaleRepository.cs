using DAL.Properties;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace DAL
{
    public class ContractOfSaleRepository : IContractOfSaleRepository
    {
        public ObservableCollection<ContractOfSale> _cosCollection = new ObservableCollection<ContractOfSale>();

        public void AddContractOfSale(ContractOfSale cos)
        {        

            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {
                using (SqlCommand insertCommand = new SqlCommand("INSERT INTO ContractOfSale" +
                               "(ContractOfSaleID, ContractOfSaleBuyerID, ContractOfSaleOwnerID, ContractOfSaleNumber, ContractOfSaleDate, ContractOfSaleOwner, " +
                               "ContractOfSaleBuyer, ContractOfSaleCost) " +
                               "Values(@ContractOfSaleID, @ContractOfSaleBuyerID, @ContractOfSaleOwnerID, @ContractOfSaleNumber, @ContractOfSaleDate, " +
                               "@ContractOfSaleOwner, @ContractOfSaleBuyer, @ContractOfSaleCost)", connection))
                {

                    //foreach (ContractOfSale _cos in _cosCollection)
                    //{
                        insertCommand.Parameters.Clear();

                        insertCommand.Parameters.AddWithValue("@ContractOfSaleID", typeof(string)).Value = cos.ContractOfSaleID;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleBuyerID", typeof(string)).Value = cos.ContractOfSaleBuyerID;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleOwnerID", typeof(string)).Value = cos.ContractOfSaleOwnerID;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleNumber", typeof(string)).Value = cos.ContractOfSaleNumber;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleDate", typeof(string)).Value = cos.ContractOfSaleDate;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleOwner", typeof(string)).Value = cos.ContractOfSaleOwner;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleBuyer", typeof(string)).Value = cos.ContractOfSaleBuyer;
                        insertCommand.Parameters.AddWithValue("@ContractOfSaleCost", typeof(string)).Value = cos.ContractOfSaleCost;
                    //insertCommand.Parameters.AddWithValue("@OwnerContractOfSaleID", typeof(string)).Value = owner.OwnerContractOfSaleID;
                    //foreach (Owner owner in new OwnerRepository().GetAll())
                    //    if (owner.OwnerName == cos.ContractOfSaleOwner)
                    //        insertCommand.Parameters.AddWithValue("@ContractOfSaleOwnerID", typeof(string)).Value = owner.OwnerID;

                    //}
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        public void DeleteContractOfSale(ContractOfSale cos)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {

                using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM ContractOfSale " +
                               "WHERE ContractOfSaleID = @ContractOfSaleID", connection))
                {
                    deleteCommand.Parameters.Clear();
                    deleteCommand.Parameters.AddWithValue("@ContractOfSaleID", typeof(string)).Value = cos.ContractOfSaleID;

                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateContractOfSale(ContractOfSale cos)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {

                using (SqlCommand updateCommand = new SqlCommand("UPDATE ContractOfSale " +
                               "SET " +
                               //"ContractOfSaleID = @ContractOfSaleID, " +
                               "ContractOfSaleNumber = @ContractOfSaleNumber, " +
                               "ContractOfSaleDate = @ContractOfSaleDate, " +
                               "ContractOfSaleOwner = @ContractOfSaleOwner, " +
                               "ContractOfSaleBuyer = @ContractOfSaleBuyer, " +
                               "ContractOfSaleCost = @ContractOfSaleCost, " +

                               "WHERE ContractOfSaleID = @ContractOfSaleID", connection))
                {
                    updateCommand.Parameters.Clear();

                    updateCommand.Parameters.AddWithValue("@ContractOfSaleNumber", typeof(string)).Value = cos.ContractOfSaleNumber;
                    updateCommand.Parameters.AddWithValue("@ContractOfSaleDate", typeof(string)).Value = cos.ContractOfSaleDate;
                    updateCommand.Parameters.AddWithValue("@ContractOfSaleOwner", typeof(string)).Value = cos.ContractOfSaleOwner;
                    updateCommand.Parameters.AddWithValue("@ContractOfSaleBuyer", typeof(string)).Value = cos.ContractOfSaleBuyer;
                    updateCommand.Parameters.AddWithValue("@ContractOfSaleCost", typeof(string)).Value = cos.ContractOfSaleCost;
                    // updateCommand.Parameters.AddWithValue("@OwnerContractOfSaleID", typeof(string)).Value = owner.OwnerContractOfSaleID;

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
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
                        new_cos.ContractOfSaleBuyerID = (Int32)reader.GetValue(1);
                        new_cos.ContractOfSaleOwnerID = (Int32)reader.GetValue(2);
                        new_cos.ContractOfSaleNumber = (string)reader.GetValue(3);
                        new_cos.ContractOfSaleDate = (DateTime)reader.GetValue(4);
                        new_cos.ContractOfSaleOwner = (string)reader.GetValue(5);
                        new_cos.ContractOfSaleBuyer = (string)reader.GetValue(6);
                        new_cos.ContractOfSaleCost = (double)reader.GetValue(7);


                        _cosCollection.Add(new_cos);
                    }
                    connection.Close();
                }
                return _cosCollection;

            }
        }

    }
}
