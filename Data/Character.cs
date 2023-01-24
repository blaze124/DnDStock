using SQLite;
using System.ComponentModel.DataAnnotations;

namespace DnDStock.Data
{
    public class Character
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required, System.ComponentModel.DataAnnotations.MaxLength(75)]
        public string Name { get; set; }

        [Required, Range(1, 20)]
        public int Level { get; set; }
    }
}
