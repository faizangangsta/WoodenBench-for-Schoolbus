using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;
using WBServicePlatform.WebManagement.Properties;

namespace WebManagement.Controllers
{
    [Produces("image/Jpeg")]
    [Route("api/QRCode")]
    public class QRCodeController : Controller
    {
        public void Get(string Data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            Data = Request.Scheme + "://" + Request.Host + "/Main/ParentCheck?ID=" + Data; 
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(Data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrcode.GetGraphic(5, Color.Black, Color.White, (Bitmap)Image.FromStream( new MemoryStream(Resources.MainICON)), 15, 4, true);
            MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, ImageFormat.Jpeg);
            Response.ContentType = "image/Jpeg";
            Response.Body.Write(ms.ToArray(), 0, ms.ToArray().Length);
        }
    }
}