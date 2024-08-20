using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColumnAttribute = SQLite.ColumnAttribute;
using TableAttribute = System.ComponentModel.DataAnnotations.Schema.TableAttribute;

namespace Gasolinera5834163
{
    [Table("totalgas")]
    public class TotalGas
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("tipo")]
        public string? Galones { get; set; }
        [Column("litros")]
        public string? Litros { get; set; }
        [Column("total")]
        public string? Total { get; set; }

    }
}
