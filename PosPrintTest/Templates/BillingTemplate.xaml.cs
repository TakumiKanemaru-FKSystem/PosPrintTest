using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.Common;

namespace PosPrintTest {
  public partial class BillingTemplate : Page {
    public BillingTemplate(
      double pageWidth,
      int transactionNomber, 
      DateTime transactionDateTime, 
      string TableName, 
      int numberOfPeople,
      string chargeName,
      List<Order> orders
    ) {
      InitializeComponent();
      this.Width = pageWidth;

      textBlock_transactionDate.Text = transactionDateTime.ToString("M月d日");
      textBlock_trasactionNumber.Text = transactionNomber.ToString();
      textBlock_tableName.Text = TableName;
      textBlock_numberOfPeple.Text = numberOfPeople.ToString();
      textBlock_chargeName.Text = chargeName.ToString();

      dataGrid_orders.ItemsSource = orders;

      decimal totalAmount = 0;
      foreach (var order in orders) {
        totalAmount += order.Amount;
      }
      textBlock_totalAmount.Text = totalAmount.ToString("C");

      // QRコードを生成してページに表示する
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
    }
  }
}
