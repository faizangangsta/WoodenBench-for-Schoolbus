using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Android.OS;
using cn.bmob.api;
using cn.bmob.tools;
using Newtonsoft.Json.Linq;
using cn.bmob.json;

namespace WoodenBench_Android
{
    [Activity(Label = "WoodenBench_Android", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            bmob = new BmobWindows();
            Bmob.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
            BmobDebug.Register(msg => { });
            base.OnCreate(bundle);
            var Resulta = Bmob.GetTaskAsync<Model.GeneralDataTable>("GeneralData", "oRr7000l");
            JObject JsonNowUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(Resulta.Result));
            string varContent = JsonNowUsrResult["DataContent"].ToString();
            

            SetContentView(Resource.Layout.Main);

            String appCachePath = ApplicationContext.CacheDir.AbsolutePath;
            var webView = FindViewById<WebView>(Resource.Id.webView);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.DomStorageEnabled = true;
            webView.Settings.SetAppCacheMaxSize(1024 * 1024 * 8);
            webView.Settings.SetAppCachePath(appCachePath);
            webView.Settings.AllowFileAccess = true;
            webView.Settings.SetAppCacheEnabled(true);
            webView.BuildDrawingCache(true);

            webView.SetWebViewClient(new HybridWVC());

            webView.LoadUrl("https://lhy0403.github.io/SchoolBusMgr/index.html");
        }
        private BmobWindows bmob;
        public BmobWindows Bmob { get { return bmob; } }

        private class HybridWVC : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView webView, string url)
            {
                // If the URL is not our own custom scheme, just let the webView load the URL as usual
                var scheme = "hybrid:";
                if (!url.StartsWith(scheme))
                {
                    return false;
                }
                webView.LoadUrl(url);
                return true;
            }
        }
    }
}