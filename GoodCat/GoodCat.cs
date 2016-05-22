using ElectronicObserver.Utility;
using ElectronicObserver.Utility.Storage;
using ElectronicObserver.Window;
using ElectronicObserver.Window.Plugins;
using Fiddler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GoodCat
{
    public class GoodCat : ServerPlugin
    {
        private readonly static string ConfigFile = Application.StartupPath + @"\Settings\BossKey.xml";
        internal static Config Config { get; private set; } = new Config();

        private bool isStarted = false;

        public override string MenuTitle
        {
            get
            {
                return "防猫插件";
            }
        }

        public override bool RunService(FormMain main)
        {
            Load();
            Start();
            return true;
        }

        public static void Load()
        {
            if (File.Exists(ConfigFile))
            {
                Config load = (Config)Config.Load(ConfigFile);
                if (load != null) Config = load;
                else return;
            }
        }

        public static void Save()
        {
            Config.Save(ConfigFile);
        }

        internal void Start()
        {
            if (!isStarted && Config.EnableGoodCat)
            {
                FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
                isStarted = true;
            }
        }

        internal void Stop()
        {
            if (isStarted)
            {
                FiddlerApplication.BeforeRequest -= FiddlerApplication_BeforeRequest;
                isStarted = false;
            }
        }

        private void FiddlerApplication_BeforeRequest(Session oSession)
        {
            if (!Config.EnableGoodCat || !oSession.fullUrl.Contains("/kcsapi/")) return;

            WebHeaderCollection headers = new WebHeaderCollection();
            foreach (HTTPHeaderItem headerItem in oSession.oRequest.headers)
                headers.Add(headerItem.Name, headerItem.Value);

            byte[] requestBody = oSession.requestBodyBytes;

            oSession.utilCreateResponseAndBypassServer();

            bool needRetry;
            do
            {
                try
                {
                    NewMethod(oSession, headers, requestBody);
                    needRetry = false;
                }
                catch (Exception)
                {
                    Config.CatCount++;
                    needRetry = true;
                }
            }
            while (needRetry);
        }

        private static void NewMethod(Session oSession, WebHeaderCollection headers, byte[] requestBody)
        {
            HttpWebRequest newRequest = (HttpWebRequest)WebRequest.Create(oSession.fullUrl);
            //WebHeaderCollection newHeaders = newRequest.Headers;
            //newHeaders.Clear();
            //newHeaders.Add(headers);
            foreach (string headerName in headers.AllKeys)
            {
                switch (headerName.ToLower())
                {
                    case "accept":
                        newRequest.Accept = headers[headerName];
                        break;
                    case "connection":
                        newRequest.KeepAlive = false;
                        break;
                    case "content-type":
                        newRequest.ContentType = headers[headerName];
                        break;
                    case "proxy-connection":
                        newRequest.KeepAlive = false;
                        break;
                    case "if-modified-since":
                        DateTime result;
                        if (DateTime.TryParse(headers[headerName], out result))
                            newRequest.IfModifiedSince = result;
                        break;
                    case "range":
                        string[] range = headers[headerName].Split('=');
                        string[] bytes = range[1].Split('-');
                        if (bytes[1] == "")
                            newRequest.AddRange(range[0], int.Parse(bytes[0]));
                        else
                            newRequest.AddRange(range[0], int.Parse(bytes[0]), int.Parse(bytes[1]));
                        break;
                    case "referer":
                        newRequest.Referer = headers[headerName];
                        break;
                    case "user-agent":
                        newRequest.UserAgent = headers[headerName];
                        break;
                    case "transfer-enconding":
                        newRequest.TransferEncoding = headers[headerName];
                        break;
                    default:
                        break;
                }
            }

            newRequest.AllowAutoRedirect = false;
            newRequest.ContentLength = requestBody.Length;
            newRequest.Method = "POST";
            newRequest.Timeout = 12000;

            Configuration.ConfigurationData.ConfigConnection config = Configuration.Config.Connection;
            if (config.UseUpstreamProxy)
                newRequest.Proxy = new WebProxy(config.UpstreamProxyAddress, config.UpstreamProxyPort);

            Stream requestStream = newRequest.GetRequestStream();
            requestStream.Write(requestBody, 0, requestBody.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)newRequest.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            byte[] responseBody = Encoding.UTF8.GetBytes(reader.ReadToEnd());
            reader.Close();

            WebHeaderCollection responseHeaders = response.Headers;
            responseHeaders.Set(HttpResponseHeader.Connection, "Close");
            foreach (string headerName in responseHeaders.AllKeys)
                oSession.oResponse.headers[headerName] = responseHeaders[headerName];

            oSession.ResponseBody = responseBody;
        }
    }

    [DataContract(Name = "GoodCat")]
    public class Config : DataStorage
    {
        public override void Initialize()
        {
            EnableGoodCat = false;
            CatCount = 0U;
        }

        [DataMember]
        public bool EnableGoodCat { get; set; }

        [DataMember]
        public uint CatCount { get; set; }
    }
}