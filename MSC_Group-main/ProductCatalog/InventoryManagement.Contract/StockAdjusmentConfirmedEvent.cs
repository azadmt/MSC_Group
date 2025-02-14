using System.Text.Json.Serialization;

namespace InventoryManagement.Contract
{
    public class StockAdjusmentConfirmedEvent
    {
        [JsonInclude]
        public Guid OrderId { get; set; }
    }
}