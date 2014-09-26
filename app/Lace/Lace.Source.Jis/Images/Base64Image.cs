namespace Lace.Source.Jis.Images
{
    public class Base64Image : ImageBuilder
    {
        public Base64Image(string image)
        {
            SetBinaryImage(image).SetOrignalImage().ScaleNewImage(100, 75).ConvertToJpg();
        }
    }
}
