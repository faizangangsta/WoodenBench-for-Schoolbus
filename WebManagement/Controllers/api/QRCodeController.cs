﻿using System;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;

using Microsoft.AspNetCore.Mvc;

using QRCoder;

using WBPlatform.TableObject;
using WBPlatform.WebManagement.Properties;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("image/Jpeg")]
    [Route("api/QRCode")]
    public class QRCodeController : Controller
    {
        public void Get(string Data)
        {
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (user.UserGroup.IsBusManager && user.UserGroup.BusID == Data.Split(";")[0] && user.objectId == Data.Split(";")[1])
                {
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    Data = Request.Scheme + "://" + Request.Host + "/MyChild/ParentCheck?ID=" + Data;
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(Data, QRCodeGenerator.ECCLevel.H);
                    QRCode qrcode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrcode.GetGraphic(5, Color.Black, Color.White, (Bitmap)Image.FromStream(new MemoryStream(Resources.MainICON)), 15, 4, true);
                    MemoryStream ms = new MemoryStream();
                    qrCodeImage.Save(ms, ImageFormat.Jpeg);
                    Response.ContentType = "image/Jpeg";
                    Response.Body.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    GC.Collect();
                }
                else return;
            }
            else return;
        }
    }
}