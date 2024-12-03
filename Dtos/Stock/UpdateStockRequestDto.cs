using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    { 
        public string ItemName { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;
    }
}
