using System.Printing;

namespace PosPrintTest.Utils {
  internal static class UtilFunc {
    public static string GetDefaultPrinterName() {
      string defaultPrinterName = string.Empty;
      LocalPrintServer printServer = new LocalPrintServer();

      // Get the default print queue
      PrintQueue defaultPrintQueue = printServer.DefaultPrintQueue;

      if (defaultPrintQueue != null) {
        // Get the name of the default print queue
        defaultPrinterName = defaultPrintQueue.Name;
      }

      return defaultPrinterName;
    }
  }
}
