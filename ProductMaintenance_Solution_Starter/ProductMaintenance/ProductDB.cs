using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProductMaintenance
{
    public static class ProductDB
    {
        public static Product GetProduct(string code)
        {
            SqlConnection connection = MMABooksDB.GetConnection();
            using (connection)
            {
                var queryString = "SELECT * FROM Products WHERE ProductCode = '@code'";

                var command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@code", code);

                // execute query
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        throw new InvalidOperationException();
                      
                    }

                    var returnProduct = new Product()
                    {
                        Code = $"{ reader["ProductCode"] }",
                        Description = $"{ reader["Description"]}",
                        Price = decimal.Parse($"{reader["Price"]}")

                    };

                    return returnProduct;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                    Console.ReadKey();
                }

                return null;
            }

        }

        public static bool AddProduct(Product product)
        {
            SqlConnection connection = MMABooksDB.GetConnection();

            using (connection)
            {
               
                var insertString = "INSERT INTO Products (ProductCode, Description, UnitPrice) " +
                    "VALUES ('@code', '@description', @unitPrice)";

                var command = new SqlCommand(insertString, connection);

                command.Parameters.AddWithValue("@code", product.Code);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@unitPrice", product.Price);
                

                // execute query
                try
                {
                    connection.Open();
                    var rows = command.ExecuteNonQuery();

                    if (rows < 1)
                    {
                        return false;
                    }
                    else
                        return true;

                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                    Console.ReadKey();
                }

                return false;
            }
        }

        public static bool UpdateProduct(Product oldProduct, 
            Product newProduct)
        {
            SqlConnection connection = MMABooksDB.GetConnection();

            using (connection)
            {

                var updateString = "UPDATE Products" +
               " SET ProductCode = '@newCode'" +
               " SET Description = '@description'" +
               " SET UnitPrice = @unitPrice" +
               " WHERE ProductCode = '@oldCode'";

                var command = new SqlCommand(updateString, connection);

                command.Parameters.AddWithValue("@oldCode", oldProduct.Code);

                command.Parameters.AddWithValue("@newCode", newProduct.Code);
                command.Parameters.AddWithValue("@description", newProduct.Description);
                command.Parameters.AddWithValue("@unitPrice", newProduct.Price);




                // execute query
                try
                {
                    connection.Open();
                    var rows = command.ExecuteNonQuery();

                    if (rows < 1)
                    {
                        return false;
                    }
                    else
                        return true;

                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                    Console.ReadKey();
                }

                return false;
            }
        }

        public static bool DeleteProduct(Product product)
        {
            SqlConnection connection = MMABooksDB.GetConnection();

            using (connection)
            {

                var deleteString = "DELETE FROM Products WHERE ProductCode = '@productCode'";

                var command = new SqlCommand(deleteString, connection);

                command.Parameters.AddWithValue("@code", product.Code);
                


                // execute query
                try
                {
                    connection.Open();
                    var rows = command.ExecuteNonQuery();

                    if (rows < 1)
                    {
                        return false;
                    }
                    else
                        return true;

                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error" + e.ToString());
                    Console.ReadKey();
                }

                return false;
            }
        }
    }
}
