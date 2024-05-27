using Microsoft.AspNetCore.Mvc;

namespace st10299399POE.Models
{
    public class transactionTable
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } 
    }


}
