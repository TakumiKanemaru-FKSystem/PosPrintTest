using System;
using System.Collections.Generic;
using System.Printing;
using System.Windows.Controls;

namespace PosPrintTest {
  public partial class BillingPage : Page {
    private Globals _globals;

    public BillingPage(Globals globals) {
      InitializeComponent();
      _globals = globals;

      textBox_transactionNumber.Text = "1";
      textBox_tableName.Text = "Table_A";
      textBox_numberOfPeople.Text = "2";
      textBox_chargeName.Text = "金丸";

      textBox_storeName.Text = "御徒町小町食堂";

      var orders = new List<Order>();
      orders.Add(new Order { ProductName = "あんぱん", Quantity = 2, Amount = 300 });
      orders.Add(new Order { ProductName = "カレーパン", Quantity = 1, Amount = 200 });
      orders.Add(new Order { ProductName = "食パン", Quantity = 2, Amount = 600 });

      dataGrid_orders.ItemsSource = orders;
    }

    private void button_bill_Click(object sender, System.Windows.RoutedEventArgs e) {
      var localPrintServer = new LocalPrintServer();
      var printQueue = localPrintServer.GetPrintQueue(_globals.SettingsPage.comboBox_PrinterNames.Text);
      var xpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);
      var printTicket = printQueue.DefaultPrintTicket;

      var billingTemplate = new BillingTemplate(
        double.Parse(_globals.SettingsPage.textBox_printWidth.Text),
        int.Parse(textBox_transactionNumber.Text),
        DateTime.Now,
        textBox_tableName.Text,
        int.Parse(textBox_numberOfPeople.Text),
        textBox_chargeName.Text,
        (List<Order>)dataGrid_orders.ItemsSource
      );

      xpsDocumentWriter.Write(billingTemplate, printTicket);
    }

    private void button_Originalbill_Click(object sender, System.Windows.RoutedEventArgs e) {
      var localPrintServer = new LocalPrintServer();
      var printQueue = localPrintServer.GetPrintQueue(_globals.SettingsPage.comboBox_PrinterNames.Text);
      var xpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);
      var printTicket = printQueue.DefaultPrintTicket;

      var originalBillingTemplate = new OriginalBillingTemplate(
        double.Parse(_globals.SettingsPage.textBox_printWidth.Text),
        textBox_storeName.Text,
        int.Parse(textBox_transactionNumber.Text),
        DateTime.Now,
        (List<Order>)dataGrid_orders.ItemsSource
      );

      xpsDocumentWriter.Write(originalBillingTemplate, printTicket);
    }
  }
}
