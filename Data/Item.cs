using SQLite;
using System.ComponentModel.DataAnnotations;

namespace DnDStock.Data
{
    public class Item
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }

        [Required, System.ComponentModel.DataAnnotations.MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public bool IsEquipment { get; set; }
    }
}
