using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.IO.Files
{
    public class ImageHelper
    {
        #region Variable

        public static List<string> AllowedExtensions = new List<string>() { ".jpeg", ".jpg", ".gif", ".png", ".bmp", ".ico" };

        #endregion

        #region Compress

        public static void Compress(string path, string savePath, long value)
        {
            if (!File.Exists(path))
            {
                return;
            }

            string extension = Path.GetExtension(path).ToString().ToLower();

            if (!AllowedExtensions.Contains(extension))
            {
                return;
            }

            using (Bitmap bitmap = new Bitmap(path))
            {
                ImageFormat imageFormat = GetImageFormat(extension);
                ImageCodecInfo imageCodecInfo = GetImageCodecInfo(imageFormat);
                System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters encoderParameters = new EncoderParameters(1);

                EncoderParameter encoderParameter = new EncoderParameter(encoder, value);
                encoderParameters.Param[0] = encoderParameter;

                FileHelper.DeleteForCreate(savePath);
                bitmap.Save(savePath, imageCodecInfo, encoderParameters);
            }
        }

        #endregion

        #region Get ImageCodecInfo

        public static ImageCodecInfo GetImageCodecInfo(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }

        #endregion

        #region Get image format

        public static ImageFormat GetImageFormat(string extension)
        {
            switch(extension)
            {
                case ".jpeg":
                case ".jpg":
                    return ImageFormat.Jpeg;

                case ".gif":
                    return ImageFormat.Gif;

                case ".png":
                    return ImageFormat.Png;

                case ".bmp":
                    return ImageFormat.Bmp;

                case ".ico":
                    return ImageFormat.Icon;

                default:
                    return ImageFormat.Jpeg;
            }
        }

        #endregion
    }
}