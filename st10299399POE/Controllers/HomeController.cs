using Microsoft.AspNetCore.Mvc;
using st10299399POE.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;

namespace st10299399POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            int? userID = HttpContext.Session.GetInt32("UserID");
            return View(userID);
        }

        public IActionResult MyWork()
        {
            List<productTable> products = productTable.GetAllProducts();
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            
            ViewData["Products"] = products;
            ViewData["UserID"] = userID;
            return View();
        }

        public IActionResult AboutUS()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowLoginForm()
        {
            return View("LoginForm");
        }

        public IActionResult ShowSignupForm()
        {
            return View("SignupForm");
        }

        public IActionResult ViewOrders(int userID)
        {
            List<transactionTable> orders = GetOrdersForUser(userID);
            return View(orders);
        }

        private List<transactionTable> GetOrdersForUser(int userID)
        {
            List<transactionTable> orders = new List<transactionTable>();
            string connectionString = "Server=tcp:ethan1-sql-server.database.windows.net,1433;Initial Catalog=ethan1-sql-database;Persist Security Info=False;User ID=EthanP1;Password=Landfour66;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM transactionTable WHERE userID = @UserID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transactionTable order = new transactionTable();
                            order.OrderID = reader.GetInt32(0);
                            order.UserID = reader.GetInt32(1);
                            order.ProductID = reader.GetInt32(2);
                            order.ProductName = reader.GetString(3);
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
