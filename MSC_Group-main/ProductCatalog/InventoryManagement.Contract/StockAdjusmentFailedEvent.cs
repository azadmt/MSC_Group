using System.Text.Json.Serialization;

namespace InventoryManagement.Contract
{
    public class StockAdjusmentRejectedEvent
    {

        [JsonInclude]
        public Guid OrderId { get; set; }
    }
}