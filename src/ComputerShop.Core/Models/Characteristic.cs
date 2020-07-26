using System.Collections.Generic;

namespace ComputerShop.API.Entities
{
    public class Сharacteristic
    {
        public Сharacteristic()
        {
            CharacterValue = new HashSet<CharacterValue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CharacterValue> CharacterValue { get; set; }
    }
}