using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace st10299399POE.Models
{
    public class productTable
    {

        public static string con_string = "Server=tcp:ethan1-sql-server.database.windows.net,1433;Initial Catalog=ethan1-sql-database;Persist Security Info=False;User ID=EthanP1;Password=Landfour66;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);    

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Availability { get; set; }


        public int insert_Product(productTable p)
        {
            string sql = "INSERT INTO productTable (productName, productCategory, productPrice, productAvailability) VALUES (@Name, @Category, @Price, @Availability)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Price", p.Price);
            cmd.Parameters.AddWithValue("@Category", p.Category);
            cmd.Parameters.AddWithValue("@Availability", p.Availability);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }

        public static List<productTable> GetAllProducts()
        {
            List<productTable> products = new List<productTable>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    productTable product = new productTable();
                    product.ProductID = Convert.ToInt32(rdr["productID"]);
                    product.Name = rdr["productName"].ToString();
                    product.Price = rdr["productPrice"].ToString();
                    product.Category = rdr["productCategory"].ToString();
                    product.Availability = rdr["productAvailability"].ToString();

                    products.Add(product);
                }
            }

            return products;
        }
    }
}
