
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{

    public class ChildProductInfoRepository
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BomManager";
        public void Add(int parentId, int childId, int qty = 1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO ChildProductInfo (ParentId, ChildId, QtyInParent) VALUES(@ParentId, @ChildId, @QtyInParent)", connection))
                {
                    command.Parameters.Add(new SqlParameter("ParentId", parentId));
                    command.Parameters.Add(new SqlParameter("ChildId", childId));
                    command.Parameters.Add(new SqlParameter("QtyInParent", qty));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int parentId, int childId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM ChildProductInfo WHERE ParentId = @ParentId and ChildId = @ChildId", connection))
                {
                    command.Parameters.Add(new SqlParameter("ParentId", parentId));
                    command.Parameters.Add(new SqlParameter("ChildId", childId));
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ChildProductInfo> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<ChildProductInfo> Items = new List<ChildProductInfo>();
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM ChildProductInfo", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Items.Add(new ChildProductInfo
                            {
                                ParentId = reader.GetInt32(0),
                                ChildId = reader.GetInt32(1),
                                QtyInParent = reader.GetInt32(2)
                            });
                        }
                    }
                    return Items;
                }
            }
        }

        public ChildProductInfo Get(int parentId, int childId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM ChildProductInfo WHERE ParentId = @ParentId and ChildId = @ChildId", connection))
                {
                    command.Parameters.Add(new SqlParameter("ParentId", parentId));
                    command.Parameters.Add(new SqlParameter("ChildId", childId));
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return new ChildProductInfo
                            {
                                ParentId = reader.GetInt32(0),
                                ChildId = reader.GetInt32(1),
                            };
                        }
                    }
                    return null;
                }
            }
        }

        public void Update(ChildProductInfo item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "UPDATE ChildProductInfo SET " +
                    "QtyInParent = @QtyInParent WHERE WHERE ParentId = @ParentId and ChildId = @ChildId", connection))
                {
                    command.Parameters.Add(new SqlParameter("ParentId", item.ParentId));
                    command.Parameters.Add(new SqlParameter("ChildId", item.ChildId));
                    command.Parameters.Add(new SqlParameter("QtyInParent", item.QtyInParent));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
