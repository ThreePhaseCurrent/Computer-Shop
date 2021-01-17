using System;
using Newtonsoft.Json;

namespace ComputerShop.API.Models
{
    /// <summary>
    /// Parameters for pagination product
    /// </summary>
    public class ProductViewParameters
    {
        [JsonProperty("page_number")]
        public int PageNumber { get; set; } = 1;

        private int maxPageSize = 50;
        private int _pageSize = 10;

        [JsonProperty("page_size")]
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}