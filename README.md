# jinput-sharp #

**jinput-sharp** is **[Google CGI API for Japanese Input]** client written in C#.

## Usage ##

**[Google CGI API for Japanese Input]** returns **JSON style array** for conversion candidates of inputted **japanese hiragana**.

### Configuration of App.config ###

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <appSettings>
        <add key="ApiUrl" value="http://www.google.com/transliterate?langpair=ja-Hira|ja&amp;text=" />
      </appSettings>
    </configuration>

### Simple usage in console application ###

    using JinputSharp;
    using System;

    public class Program
    {
      public static void Main(string[] args)
      {
        Console.WriteLine("ひらがな".ToKanji());
      }
    }

### Getting plain JSON style array ###

    new Jinput().Convert("ひらがな");

### Getting decoded JSON style array ###

    new Jinput().ConvertToDecoded("ひらがな");

### Getting JArray object ###

    new Jinput().ConvertToJArray("ひらがな");

## Required assembly ##

jinput-sharp uses **[Json.NET]**.

### Before using Json.NET with MonoDevelop ###

#### Extracting Json.NET zip file and installing Json.NET assembly to GAC ####

    $ unzip Json35r8.zip
    $ cd Bin/DotNet/
    $ sudo gacutil -i Newtonsoft.Json.dll -package 2.0
    Package exported to: /usr/lib/mono/2.0/Newtonsoft.Json.dll -> ../gac/Newtonsoft.Json/3.5.0.0__30ad4fe6b2a6aeed/Newtonsoft.Json.dll
    Installed Newtonsoft.Json.dll into the gac (/usr/lib/mono/gac)

#### Configuration of pkg config file for Json.NET(e.g. Newtonsoft.Json_3.5.pc) ####

    Name: Json.NET
    Description: Json.NET - Json.NET is a popular high-performance JSON framework for .NET
    Version: 3.5.0.0
    Libs: -r:/usr/lib/mono/gac/Newtonsoft.Json/3.5.0.0__30ad4fe6b2a6aeed/Newtonsoft.Json.dll

#### Copying pkg config file to your system pkg config dir ####

    $ sudo cp Newtonsoft.Json_3.5.pc /usr/lib/pkgconfig

## License ##

Copyright &copy; 2012 sta.blockhead

Licensed under the **[MIT License]**.


[Google CGI API for Japanese Input]: http://www.google.co.jp/ime/cgiapi.html
[Json.NET]: http://james.newtonking.com/projects/json-net.aspx
[MIT License]: http://www.opensource.org/licenses/mit-license.php
