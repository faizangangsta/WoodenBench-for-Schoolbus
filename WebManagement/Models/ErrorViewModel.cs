using System;

namespace WBServicePlatform.WebManagement.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string Data { get; set; }
    }
}