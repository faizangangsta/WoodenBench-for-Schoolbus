﻿using Microsoft.AspNetCore.Mvc;

using QRCoder;

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using WBPlatform.WebManagement.Properties;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("image/Jpeg")]
    [Route("api/QRCode")]
    public class QRCodeController : APIController
    {
        public void Get(string Data)
        {
            if (ValidateSession())
            {
                if (CurrentUser.UserGroup.IsBusManager && CurrentUser.ObjectId == Data.Split(";")[1])//user.UserGroup.BusID == Data.Split(";")[0] &&
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