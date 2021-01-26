using System;
using System.Drawing;
using System.IO;
using QRCoder;

namespace Test.Common
{
    public static class QRCodeExtension
    {
        public static byte[] GetQRCode(this string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                qrCode.GetGraphic(20).Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
                
            }
        }
    }
}
