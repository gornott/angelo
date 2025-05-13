
using SQLite;

namespace FiveCast.Model
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int DestinationId { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
    }
}
