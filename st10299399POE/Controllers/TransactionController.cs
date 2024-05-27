using Microsoft.AspNetCore.Mvc;
using st10299399POE.Models;
using System.Data.SqlClient;

namespace st10299399POE.Controllers
{
    public class TransactionController : Controller
    {
        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(productTable.con_string))
                {
                    string sql = "INSERT INTO transactionTable (userID, productID) VALUES (@UserID, @ProductID)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        con.Close();

                        if (rowsAffected > 0)
                        {
                            return View("OrderSuccessfull");
                        }
                        else
                        {
                            return View("OrderFailed");
                        }
                    }
                }
            }
            catch (Exception)
            {
                return View("OrderFailed");
            }
        }
    }
}
