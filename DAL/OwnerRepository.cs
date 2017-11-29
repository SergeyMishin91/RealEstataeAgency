using System;
using System.Collections.Generic;
using Repository;
using Model;
using System.Data.SqlClient;
using DAL.Properties;
using System.Collections.ObjectModel;

namespace DAL
{
    public class OwnerRepository : IOwnerRepository
    {
        public ObservableCollection<Owner> _ownersCollection = new ObservableCollection<Owner>();

        public void AddOwner(Owner owner)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {

                using (SqlCommand insertCommand = new SqlCommand("Insert Into dbo.Owner" +
                               "(OwnerID, OwnerName, OwnerUNP, OwnerAdress, OwnerPhone)" +
                               "Values(@OwnerID, @OwnerName, @OwnerUNP, @OwnerAdress, @OwnerPhone)", connection))
                {

                    foreach (Owner _owner in _ownersCollection)
                    {
                        insertCommand.Parameters.Clear();

                        insertCommand.Parameters.AddWithValue("@OwnerID", typeof(string)).Value = owner.OwnerID;
                        insertCommand.Parameters.AddWithValue("@OwnerName", typeof(string)).Value = owner.OwnerName;
                        insertCommand.Parameters.AddWithValue("@OwnerUNP", typeof(string)).Value = owner.OwnerUNP;
                        insertCommand.Parameters.AddWithValue("@OwnerAdress", typeof(string)).Value = owner.OwnerAdress;
                        insertCommand.Parameters.AddWithValue("@OwnerPhone", typeof(string)).Value = owner.OwnerPhone;
                    }
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        public void DeleteOwner(Owner owner)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {

                using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM dbo.Owner " +
                               "WHERE OwnerID = @OwnerID", connection))
                {
                    deleteCommand.Parameters.Clear();
                    deleteCommand.Parameters.AddWithValue("@OwnerID", typeof(string)).Value = owner.OwnerID;

                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateOwner(Owner owner)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {

                using (SqlCommand updateCommand = new SqlCommand("UPDATE dbo.Owner " +
                               "SET " +

                               "OwnerID = @OwnerID, " +
                               "OwnerName = @OwnerName, " +
                               "OwnerUNP = @OwnerUNP, " +
                               "OwnerAdress = @OwnerAdress, " +
                               "OwnerPhone = @OwnerPhone " +
                               
                               "WHERE OwnerID = @OwnerID", connection))
                {
                    updateCommand.Parameters.Clear();

                    updateCommand.Parameters.AddWithValue("@OwnerID", typeof(string)).Value = owner.OwnerID;
                    updateCommand.Parameters.AddWithValue("@OwnerName", typeof(string)).Value = owner.OwnerName;
                    updateCommand.Parameters.AddWithValue("@OwnerUNP", typeof(string)).Value = owner.OwnerUNP;
                    updateCommand.Parameters.AddWithValue("@OwnerAdress", typeof(string)).Value = owner.OwnerAdress;
                    updateCommand.Parameters.AddWithValue("@OwnerPhone", typeof(string)).Value = owner.OwnerPhone;
                    
                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<Owner> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DBConnect))
            {
                connection.Open();

                string sql = "SELECT * FROM Owner";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Owner new_owner = new Owner();

                        new_owner.OwnerID = (Int32)reader.GetValue(0);
                        new_owner.OwnerName = (string)reader.GetValue(1);
                        new_owner.OwnerAdress = (string)reader.GetValue(2);
                        new_owner.OwnerUNP = (Int32)reader.GetValue(3);
                        new_owner.OwnerPhone = (string)reader.GetValue(4);
                        
                        _ownersCollection.Add(new_owner);
                    }
                    connection.Close();
                }
                return _ownersCollection;

            }
        }
          
    }
}
