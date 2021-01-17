using Newtonsoft.Json;

namespace ComputerShop.API.Models
{
    public class ProductFilters
    {
        [JsonProperty("category_id")]
        public int ProductCategoryId { get; set; }
        [JsonProperty("filter")]
        public ISpecificCategoryProductFilter SpecificCategoryProductFilter { get; set; }
    }
}