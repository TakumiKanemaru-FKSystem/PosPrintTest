using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace PosPrintTest {
  public enum Pages {
    BillingPage,
    PaymentPage,
    SettingsPage,
  }
  public partial class MainWindow : Window {
    private Globals globals;

    public MainWindow() {
      InitializeComponent();
      globals = new Globals();

      frame_main.Content = globals.BillingPage;
    }

    private void menuItem_billing_Click(object sender, RoutedEventArgs e) {
      frame_main.Content = globals.BillingPage;
    }

    private void menuItem_payment_Click(object sender, RoutedEventArgs e) {
      frame_main.Content = globals.PaymentPage;
    }

    private void menuItem_settings_Click(object sender, RoutedEventArgs e) {
      frame_main.Content = globals.SettingsPage;
    }
  }
}
