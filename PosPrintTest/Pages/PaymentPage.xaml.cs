using System.Windows.Controls;

namespace PosPrintTest {
  public partial class PaymentPage : Page {
    private Globals _globals;

    public PaymentPage(Globals globals) {
      InitializeComponent();
      _globals = globals;
    }
  }
}
