#region MIT License
/**
 * Jinput.cs
 *
 * jinput-sharp is Google CGI API for Japanese Input client written in C#.
 *
 * The MIT License
 *
 * Copyright (c) 2012 sta.blockhead
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion

using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace JinputSharp
{
  public class Jinput
  {
    readonly string _apiUrl;

    public Jinput()
    : this(ConfigurationManager.AppSettings["ApiUrl"])
    {
    }

    public Jinput(string apiUrl)
    {
      _apiUrl = String.IsNullOrEmpty(apiUrl)
                ? "http://www.google.com/transliterate?langpair=ja-Hira|ja&text="
                : apiUrl;
    }

    private string getResponseFrom(string url)
    {
      WebRequest req = WebRequest.Create(url);

      using (WebResponse res = req.GetResponse())
      using (Stream stm = res.GetResponseStream())
      using (StreamReader sr = new StreamReader(stm, Encoding.GetEncoding("utf-8")))
      {
        return sr.ReadToEnd();
      }
    }

    public string Convert(string hiragana)
    {
      StringBuilder url = new StringBuilder(_apiUrl);
      url.Append(HttpUtility.UrlEncode(hiragana));

      return getResponseFrom(url.ToString());
    }

    public string ConvertToDecoded(string hiragana)
    {
      string jsonArray = Convert(hiragana).Replace(@"\", "%");

      return HttpUtility.UrlDecode(jsonArray);
    }

    public JArray ConvertToJArray(string hiragana)
    {
      return JArray.Parse(Convert(hiragana));
    }
  }
}