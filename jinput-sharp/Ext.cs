#region MIT License
/**
 * Ext.cs
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
using System.Linq;
using System.Text;

namespace JinputSharp
{
  public static class Ext
  {
    [Obsolete("This method must be used in console application.")]
    public static T SelectOneOf<T>(this T[] array)
    {
      for (int i = 0; i < array.Length; i++)
      {
        Console.WriteLine("{0} {1}", i + 1, array[i]);
      }

      int n;
      do
      {
        Console.Write("Select Number> ");
        Int32.TryParse(Console.ReadLine(), out n);
      }
      while (n < 1 || n > array.Length);

      return array[n - 1];
    }

    [Obsolete("This method must be used in console application.")]
    public static string ToKanji(this string hiragana)
    {
      Jinput jinput = new Jinput();
      JArray jar = jinput.ConvertToJArray(hiragana);
      StringBuilder kanji = new StringBuilder();

      foreach (JToken jt in jar)
      {
        var convArray = jt[1].ToArray();
        Console.WriteLine("{0}: {1} for conversion", jt[0], convArray.Length);
        kanji.Append((string)convArray.SelectOneOf());
      }

      return kanji.ToString();
    }
  }
}