using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.Common;

namespace PosPrintTest {
  public partial class OriginalBillingTemplate : Page {
    public OriginalBillingTemplate(
      double pageWidth,
      string storeName,
      int transactionNomber, 
      DateTime transactionDateTime, 
      List<Order> orders
    ) {
      InitializeComponent();
      this.Width = pageWidth;

      textBlock_storeName.Text = storeName;

      // 注文列挙 ----------------------------------------------------------------------------------
      List<string> quantities = new List<string>();
      List<string> productNames = new List<string>();
      List<string> amounts = new List<string>();
      decimal totalAmount = 0;

      foreach (var order in orders) {
        quantities.Add(order.Quantity.ToString());
        productNames.Add(order.ProductName);
        amounts.Add(order.Amount.ToString("C"));
        totalAmount += order.Amount;
      }

      textBlock_quantities.Text = string.Join("\n", quantities);
      textBlock_productNames.Text = string.Join("\n", productNames);
      textBlock_amounts.Text = string.Join("\n", amounts);
      textBlock_totalAmount.Text = totalAmount.ToString("C");

      // QRコード ---------------------------------------------------------------------------------
      var qrCodeWriter = new BarcodeWriterPixelData {
        Format = BarcodeFormat.QR_CODE,
        Options = new EncodingOptions {
          Width = 200,
          Height = 200,
          Margin = 3
        }
      };
      var pixelData = qrCodeWriter.Write(transactionNomber.ToString());
      var bitmap = pixelData.ToBitmap();

      MemoryStream stream = new MemoryStream();
      bitmap.Save(stream, ImageFormat.Bmp);
      stream.Position = 0;

      BitmapDecoder decoder = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
      ImageSource imageSource = decoder.Frames[0];
      image_qrCord.Source = imageSource;

      // 処理年月日 --------------------------------------------------------------------------------
      textBlock_transactionDate.Text = transactionDateTime.ToString("yyyy年MM月dd日");
      textBlock_transactionTime.Text = transactionDateTime.ToString("hh:mm");
    }
  }
}
