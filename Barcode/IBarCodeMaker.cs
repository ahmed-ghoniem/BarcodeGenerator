namespace Barcode
{
	public interface IBarCodeMaker
	{
		void GenerateImage(string textData, string path);
	}
}