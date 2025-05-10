
using System;

namespace FiveCastFinal.Model
{
    public class Expense
    {
        public int Id { get; set; }
        public int DestinationId { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
    }
}
