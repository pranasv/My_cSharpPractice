
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{

    public class ProductRepository : IRepository<Product>
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BomManager";
        public void Add(Product item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Products (Name) VALUES(@Name)", connection))
                {
                    item.Name = "New Item";
                    command.Parameters.Add(new SqlParameter("Name", item.Name));
                    command.ExecuteNonQuery();
                }                
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Products WHERE ID = @Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", id));
                    command.ExecuteNonQuery();
                }               
            }
        }

        public List<Product> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Product> Items = new List<Product>();
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Products", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Items.Add(new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                    return Items;
                }
            }
        }

        public Product Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM Products WHERE ID = @ID", connection))
                {
                    command.Parameters.Add(new SqlParameter("ID", id));
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                            };
                        }
                    }
                    return null;
                }
            }
        }

        public void Update(Product item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "UPDATE Products SET " +
                    "Name = @Name WHERE ID=@Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", item.Id));
                    command.Parameters.Add(new SqlParameter("Name", item.Name));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
