using PosPrintTest.Utils;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Controls;

namespace PosPrintTest {
  public partial class SettingsPage : Page {
    private Globals _globals;

    public SettingsPage(Globals globals) {
      InitializeComponent();
      _globals = globals;

      comboBox_PrinterNames.ItemsSource = PrinterSettings.InstalledPrinters.Cast<string>().ToList();
      comboBox_PrinterNames.Text = UtilFunc.GetDefaultPrinterName();

      textBox_printWidth.Text= UtilConst.DefaultPrintWidth.ToString();
      textBox_paperWidth.Text = UtilConst.DefaultPaperWidth.ToString();
    }
  }
}
