using System.Collections.Generic;

namespace ComputerShop.API.Entities
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            CharacterValue = new HashSet<CharacterValue>();
            Product = new HashSet<Product>();
            UserDevice = new HashSet<UserDevice>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<CharacterValue> CharacterValue { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<UserDevice> UserDevice { get; set; }
    }
}