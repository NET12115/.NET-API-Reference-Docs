 // Snippet for: F:System.Drawing.Imaging.Encoder.ColorDepth
        // Snippet for: F:System.Drawing.Imaging.Encoder.Compression
        // Snippet for: F:System.Drawing.Imaging.Encoder.Quality
        // <snippet1>
using System;
using System.Drawing;
using System.Drawing.Imaging;
class Example_SetColorDepth
{
    public static void Main()
    {
        Bitmap myBitmap;
        ImageCodecInfo myImageCodecInfo;
        Encoder myEncoder;
        EncoderParameter myEncoderParameter;
        EncoderParameters myEncoderParameters;
                     
        // Create a Bitmap object based on a BMP file.
        myBitmap = new Bitmap(@"C:\Documents and Settings\All Users\Documents\My Music\music.bmp");
                     
        // Get an ImageCodecInfo object that represents the TIFF codec.
        myImageCodecInfo = GetEncoderInfo("image/tiff");
                     
        // Create an Encoder object based on the GUID
        // for the ColorDepth parameter category.
        myEncoder = Encoder.ColorDepth;
                     
        // Create an EncoderParameters object.
        // An EncoderParameters object has an array of EncoderParameter
        // objects. In this case, there is only one
        // EncoderParameter object in the array.
        myEncoderParameters = new EncoderParameters(1);
                     
        // Save the image with a color depth of 24 bits per pixel.
        myEncoderParameter =
            new EncoderParameter(myEncoder, 24L);
        myEncoderParameters.Param[0] = myEncoderParameter;
        myBitmap.Save("Shapes24bpp.tiff", myImageCodecInfo, myEncoderParameters);
    }

    private static ImageCodecInfo GetEncoderInfo(String mimeType)
    {
        int j;
        ImageCodecInfo[] encoders;
        encoders = ImageCodecInfo.GetImageEncoders();
        for(j = 0; j < encoders.Length; ++j)
        {
            if(encoders[j].MimeType == mimeType)
                return encoders[j];
        }
        return null;
    }
}
        // </snippet1>
