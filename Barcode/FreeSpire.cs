using Spire.Barcode;
using System.Drawing;

namespace Barcode
{
	public class FreeSpire : IBarCodeMaker
	{
		public void GenerateImage(string textData, string path)
		{
			//prepare  generator settings
			BarcodeSettings barcodeSettings = GetBarcodeSettings(textData);
			BarCodeGenerator barCodeGenerator = new BarCodeGenerator(barcodeSettings);
			Image image = barCodeGenerator.GenerateImage();
			//remove water mark 
			image = RemoveWaterMark(image);
			//save image
			image.Save(path);
			//dispose new image
			image.Dispose();
		}

		private BarcodeSettings GetBarcodeSettings(string textData)
		{
			BarcodeSettings barcodeSettings = new BarcodeSettings
			{
				ShowTextOnBottom = true,
				Data = textData,
				Type = BarCodeType.Code128,
				ShowTopText = false,
				TopMargin = 5,
				BarHeight = 30
			};
			return barcodeSettings;
		}


		/// <summary>
		/// Remove Water Mark
		/// </summary>
		/// <param name="img">img</param>
		/// <returns>cropped Image</returns>
		private Image RemoveWaterMark(Image img)
		{
			Image croppedImage = null;
			Rectangle cropArea = new Rectangle(1, 12, img.Width - 1, img.Height - 12);
			using (Bitmap bmpImage = new Bitmap(img))
			{
				croppedImage = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
				//dispose old image
				img.Dispose();
			}
			return croppedImage;
		}

	}
}
