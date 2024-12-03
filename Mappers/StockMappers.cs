using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                ItemName = stockModel.ItemName,
                ExpiryDate = stockModel.ExpiryDate,
            };
        }
        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                ItemName = stockDto.ItemName,
                ExpiryDate = stockDto.ExpiryDate,
            };
        }
    }
}
