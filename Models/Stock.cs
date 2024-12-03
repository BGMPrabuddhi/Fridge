using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}