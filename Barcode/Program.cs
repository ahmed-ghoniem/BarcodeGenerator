//using IronBarCode;

using System;
using System.IO;

namespace Barcode
{
	internal class Program
	{
		private static void Main(string[] args)
		{

			//get Current Domain Path
			//change in case of web and use Server.MapPath
			string directoryBase = AppDomain.CurrentDomain.BaseDirectory;

			//barcode text data 
			string barcodeData = $"BarCode-{Guid.NewGuid()}";

			string outputPath = Path.Combine(directoryBase, barcodeData);
			PreparePath(outputPath);
			//generate barcode with FreeSpire
			IBarCodeMaker barCodeMaker = new FreeSpire();
			string freeSpirePath = Path.Combine(outputPath, $"FreeSpire.Png");
			barCodeMaker.GenerateImage(barcodeData, freeSpirePath);

			//generate barcode with IronBar
			IBarCodeMaker ironBarCodeMaker = new IronBarCodeMaker();
			string ironPath = Path.Combine(outputPath, $"Iron.Png");
			ironBarCodeMaker.GenerateImage(barcodeData, ironPath);
		}

		private static void PreparePath(string path)
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}

	}
}
