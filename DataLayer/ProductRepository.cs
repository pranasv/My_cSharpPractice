
using System;
using System.Collections.Generic;
namespace DataLayer
{

    public class ProductRepository : IRepository<Product>
    {
        private List<Product> Items = new List<Product>();
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BomManager";
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            var result = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Products", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(new Product
                            {
                                Id = reader.GetInt32(0),
                                LastName = reader.GetString(1),
                                FirtName = reader.GetString(2),
                                Age = reader.GetInt32(3)
                            });
                        }

                    }
                    return result;
                }
            }
        }


        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
