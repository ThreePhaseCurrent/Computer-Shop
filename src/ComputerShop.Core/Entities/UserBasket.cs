
namespace ComputerShop.Core.Entities
{
    public class UserBasket
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}