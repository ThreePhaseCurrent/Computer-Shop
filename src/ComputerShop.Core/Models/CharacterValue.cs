
namespace ComputerShop.API.Entities
{
    public class CharacterValue
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public int IdCharacter { get; set; }
        public string Value { get; set; }

        public virtual ProductCategory IdCategoryNavigation { get; set; }
        public virtual Сharacteristic IdCharacterNavigation { get; set; }
    }
}