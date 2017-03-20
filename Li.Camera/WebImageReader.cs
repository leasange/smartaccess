using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Li.Camera
{
    /// <summary>
    /// 读取Web图片
    /// </summary>
    public class WebImageReader
    {
        public delegate void ReadImageCallBack(Image image,Exception ex);
        public static Image ReadImage(string url)
        {
            WebRequest req = WebRequest.Create(url);
            var resp = req.GetResponse();
            var stream = resp.GetResponseStream();
            MemoryStream ms=new MemoryStream();
            byte[] bts=new byte[1024];
            while (true)
            {
                int count = stream.Read(bts, 0, 1024);
                if (count > 0)
                {
                    ms.Write(bts, 0, count);
                }
                else break;
            }
            if (ms.Length>0)
            {
                Image image = Image.FromStream(ms);
                ms.Dispose();
                return image;
            }
            return null;
        }
        public static void ReadImageAsync(string url, ReadImageCallBack callback)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    try
                    {
                        Image image = ReadImage(url);
                        callback(image,null);
                    }
                    catch (Exception ex)
                    {
                        callback(null, ex);
                    }
                }));
        }
    }
}
