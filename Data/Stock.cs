using SQLite;
using System.ComponentModel.DataAnnotations;

namespace DnDStock.Data
{
    public class Stock
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required] 
        public int CharacterId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required , Range(0, 9999)]
        public int Amount { get; set; }
    }
}
