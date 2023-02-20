namespace PosPrintTest {
  public class Globals {
    public BillingPage BillingPage { get; private set; }
    public PaymentPage PaymentPage { get; private set; }
    public SettingsPage SettingsPage { get; private set; }

    public Globals() {
      BillingPage = new BillingPage(this);
      PaymentPage = new PaymentPage(this);
      SettingsPage = new SettingsPage(this);
    }
  }
}
