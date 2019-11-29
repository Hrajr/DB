using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.SQLcontext
{
    public class ItemContext : IItemContext
    {
        private readonly DB data = new DB();

        public bool AddItem(ItemDTO item)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("AddReference", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Description", item.Description));
                    command.Parameters.Add(new SqlParameter("@VAT", item.VAT));
                    command.Parameters.Add(new SqlParameter("@Price", item.Price));
                    command.Parameters.Add(new SqlParameter("@Amount", item.Amount));
                    command.Parameters.Add(new SqlParameter("@InStock", item.InStock));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Success = true;
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    Success = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return Success;
        }

        public bool RemoveItem(string id)
        {
            bool Success = false;
            using (SqlConnection conn = new SqlConnection(data.con.ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("RemoveItem", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", id));
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    { Success = true; }
                    reader.Close();
                }
                catch (Exception)
                { Success = false; }
                finally
                { conn.Close(); }
            }
            return Success;
        }

        //public bool EditItem(Reference reference)
        //{
        //    bool Success = false;
        //    using (SqlConnection conn = new SqlConnection(data.con.ConnectionString))
        //    {
        //        try
        //        {
        //            conn.Open();

        //            SqlCommand command = new SqlCommand("EditReference", conn);
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.Add(new SqlParameter("@CompanyName", reference.ID));
        //            command.Parameters.Add(new SqlParameter("@CompanyName", reference.CompanyName));
        //            command.Parameters.Add(new SqlParameter("@ContactName", reference.ContactName));
        //            command.Parameters.Add(new SqlParameter("@Address", reference.Address));
        //            command.Parameters.Add(new SqlParameter("@Zipcode", reference.Zipcode));
        //            command.Parameters.Add(new SqlParameter("@Place", reference.Place));
        //            command.Parameters.Add(new SqlParameter("@Country", reference.Country));
        //            command.Parameters.Add(new SqlParameter("@PhoneNumber", reference.PhoneNumber));
        //            command.Parameters.Add(new SqlParameter("@Email", reference.Email));
        //            command.Parameters.Add(new SqlParameter("@Bank", reference.Bank));
        //            command.Parameters.Add(new SqlParameter("@BIC", reference.BIC));
        //            command.Parameters.Add(new SqlParameter("@IBAN", reference.IBAN));
        //            command.Parameters.Add(new SqlParameter("@KvK", reference.KvK));
        //            command.Parameters.Add(new SqlParameter("@VAT", reference.VAT));
        //            command.Parameters.Add(new SqlParameter("@Doubtfull", reference.Doubtfull));
        //            command.Parameters.Add(new SqlParameter("@Date", reference.Date));
        //            command.Parameters.Add(new SqlParameter("@Note", reference.Note));

        //            var reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                Success = true;
        //            }
        //            reader.Close();
        //        }
        //        catch (Exception)
        //        {
        //            Success = false;
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //    return Success;
        //}

        public List<ItemDTO> GetItem()
        {
            List<ItemDTO> CollectedItems = new List<ItemDTO>();
            using (SqlConnection conn = new SqlConnection(data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetAllItem", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new ItemDTO
                        {
                            ItemID = reader["ID"].ToString(),
                            Description = reader["Description"].ToString(),
                            VAT = (int)reader["VAT"],
                            Price = Convert.ToDouble(reader["Price"]),
                            Amount = (int)reader["Amount"],
                            InStock = (bool)reader["InStock"]
                        };
                        CollectedItems.Add(item);
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return CollectedItems;
        }

        public ItemDTO GetItemByID(string id)
        {
            var item = new ItemDTO()
            {
                ItemID = id
            };
            using (SqlConnection conn = new SqlConnection(data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetItemByID", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", item.ItemID));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        item.Description = reader["Description"].ToString();
                        item.VAT = (int)reader["VAT"];
                        item.Price = (double)reader["Price"];
                        item.Amount = (int)reader["Amount"];
                        item.InStock = (bool)reader["InStock"];
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return item;
        }
    }
}
