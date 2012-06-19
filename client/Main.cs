using JinputSharp;
using System;

namespace Example
{
  class Program
  {
    public static void Main(string[] args)
    {
      Console.Write("Input Hiragana> ");
      Console.WriteLine(Console.ReadLine().ToKanji());
      //Console.WriteLine(new Jinput().Convert(Console.ReadLine()));
      //Console.WriteLine(new Jinput().ConvertToDecoded(Console.ReadLine()));
      //Console.WriteLine(new Jinput().ConvertToJArray(Console.ReadLine()));
    }
  }
}