using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ComputerShop.API.Models
{
    public class GetProductsRequest
    {
        [JsonProperty("view_parameters")]
        public ProductViewParameters ProductViewParameters { get; set; }
        [JsonProperty("product_filters")]
        public ProductFilters ProductFilters { get; set; }
    }
}
