namespace Barcode
{
	public interface IBarCodeMaker
	{
		/// <summary>
		/// Generate BarCode Image and save in provided path
		/// </summary>
		/// <param name="textData">BarCode text</param>
		/// <param name="path">Save path</param>
		void GenerateImage(string textData, string path);
	}
}