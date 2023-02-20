using System.ComponentModel;

namespace PosPrintTest {
  public class Order {
    [DisplayName("品目")] public string ProductName { get; set; }
    [DisplayName("数量")] public int Quantity { get; set; }
    [DisplayName("金額")] public decimal Amount { get; set; }
  }
}
