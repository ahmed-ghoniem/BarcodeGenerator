using IronBarCode;

namespace Barcode
{
	public class IronBarCodeMaker : IBarCodeMaker
	{
		public void GenerateImage(string textData, string path)
		{
			GeneratedBarcode barCode = IronBarCode.BarcodeWriter
			.CreateBarcode(textData, BarcodeWriterEncoding.Code128)
			.ResizeTo(500, 200)
			.AddAnnotationTextBelowBarcode(textData)
			.SetMargins(10);
			barCode.SaveAsPng(path);
		}
	}
}