using System;
using Humanizer;
using Humanizer.Inflections;
using System.Globalization;
using Humanizer.Bytes;
using Humanizer.Localisation;

namespace HumanizerDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      Action<string> Display = Console.WriteLine;
      Display("Man".Pluralize()); //=> "Men"
      Display("string".Pluralize()); //=> "strings";

      Display("Men".Pluralize(inputIsKnownToBeSingular: false)); //=> "Men"
      Display("Man".Pluralize(inputIsKnownToBeSingular: false)); //=> "Men"
      Display("string".Pluralize(inputIsKnownToBeSingular: false)); //=> "strings"

      Display("Men".Singularize()); //=> "Man"
      Display("strings".Singularize()); //=> "string"

      Display("Men".Singularize(inputIsKnownToBePlural: false)); //=> "Man"
      Display("Man".Singularize(inputIsKnownToBePlural: false)); //=> "Man"
      Display("strings".Singularize(inputIsKnownToBePlural: false)); //=> "string"

      Vocabularies.Default.AddIrregular("person", "people");
      Vocabularies.Default.AddIrregular("person", "people", matchEnding: false);
      Vocabularies.Default.AddUncountable("fish");
      Vocabularies.Default.AddPlural("bus", "buses");
      Vocabularies.Default.AddSingular("(vert|ind)ices$", "$1ex");

      Display("case".ToQuantity(0)); //=> "0 cases"
      Display("case".ToQuantity(1)); // => "1 case"
      Display("case".ToQuantity(5)); // => "5 cases"
      Display("man".ToQuantity(0) ); //=> "0 men"
      Display("man".ToQuantity(1) ); //=> "1 man"
      Display("man".ToQuantity(2) ); //=> "2 men"

      Display("men".ToQuantity(2)); //=> "2 men"
      Display("process".ToQuantity(2)); //=> "2 processes"
      Display("process".ToQuantity(1)); //=> "1 process"
      Display("processes".ToQuantity(2)); //=> "2 processes"
      Display("processes".ToQuantity(1)); //=> "1 process"

      Display("case".ToQuantity(5, ShowQuantityAs.Words)); //=> "five cases"
      Display("case".ToQuantity(5, ShowQuantityAs.None)); //=> "cases"

      Display("dollar".ToQuantity(2, "C0", new CultureInfo("en-US"))); //=> "$2 dollars"
      Display("dollar".ToQuantity(2, "C2", new CultureInfo("en-US"))); //=> "$2.00 dollars"
      Display("cases".ToQuantity(12000, "N0")); //=> "12,000 cases"

      Display(1.Ordinalize()); //=> "1st"
      Display(5.Ordinalize()); // => "5th"

      Display("some_title".Pascalize()); //=> "SomeTitle"
      Display("some_title".Camelize()); //=> "someTitle"

      Display("SomeTitle".Underscore()); // => "some_title"

      Display("some_title".Dasherize()); //=> "some-title"
      Display("some_title".Hyphenate()); //=> "some-title"

      Display("SomeText".Kebaberize()); //=> "some-text"

      Display($"{2.Milliseconds()}"); //=> TimeSpan.FromMilliseconds(2)
      Display($"{2.Seconds()}"); //=> TimeSpan.FromSeconds(2)
      Display($"{2.Minutes()}"); //=> TimeSpan.FromMinutes(2)
      Display($"{2.Hours()}"); //=> TimeSpan.FromHours(2)
      Display($"{2.Days()}"); //=> TimeSpan.FromDays(2)
      Display($"{2.Weeks()}"); //=> TimeSpan.FromDays(14)

      Display($"{DateTime.Now.AddDays(2).AddHours(3).AddMinutes(-5)}");
      Display($"{DateTime.Now + 2.Days() + 3.Hours() - 5.Minutes()}");

      Display($"{In.TheYear(2010)}"); // Returns the first of January of 2010
      Display($"{In.January}"); // Returns 1st of January of the current year
      Display($"{In.FebruaryOf(2009)}"); // Returns 1st of February of 2009
      
      Display($"{In.One.Second}"); //  DateTime.UtcNow.AddSeconds(1);
      Display($"{In.Two.SecondsFrom(DateTime.Now)}");
      Display($"{In.Three.Minutes}"); // With corresponding From method
      Display($"{In.Three.Hours}"); // With corresponding From method
      Display($"{In.Three.Days}"); // With corresponding From method
      Display($"{In.Three.Weeks}"); // With corresponding From method
      Display($"{In.Three.Months}"); // With corresponding From method
      Display($"{In.Three.Years}"); // With corresponding From method
      
      Display($"{On.January.The4th}"); // Returns 4th of January of the current year
      Display($"{On.February.The(12)}"); // Returns 12th of Feb of the current year

      var someDateTime = new DateTime(2011, 2, 10, 5, 25, 45, 125);

      // Returns new DateTime(2008, 2, 10, 5, 25, 45, 125) changing the year to 2008
      Display($"{someDateTime.In(2008)}");

      // Returns new DateTime(2011, 2, 10, 2, 25, 45, 125) changing the hour to 2:25:45.125
      Display($"{someDateTime.At(2)}");

      // Returns new DateTime(2011, 2, 10, 2, 20, 15, 125) changing the time to 2:20:15.125
      Display($"{someDateTime.At(2, 20, 15)}");

      // Returns new DateTime(2011, 2, 10, 12, 0, 0) changing the time to 12:00:00.000
      Display($"{someDateTime.AtNoon()}");

      // Returns new DateTime(2011, 2, 10, 0, 0, 0) changing the time to 00:00:00.000
      Display($"{someDateTime.AtMidnight()}");

      Display($"{1.25.Billions()}"); //=> 1250000000
      Display($"{3.Hundreds().Thousands()}");  //=> 300000

      Display($"{1.ToWords()}"); //=> "one"
      Display($"{10.ToWords()}"); //=> "ten"
      Display($"{11.ToWords()}"); //=> "eleven"
      Display($"{122.ToWords()}"); //=> "one hundred and twenty-two"
      Display($"{3501.ToWords()}"); //=> "three thousand five hundred and one"

      Display($"{0.ToOrdinalWords()}"); //=> "zeroth"
      Display($"{1.ToOrdinalWords()}"); //=> "first"
      Display($"{2.ToOrdinalWords()}"); //=> "second"
      Display($"{8.ToOrdinalWords()}"); //=> "eighth"
      Display($"{10.ToOrdinalWords()}"); //=> "tenth"
      Display($"{11.ToOrdinalWords()}"); //=> "eleventh"
      Display($"{12.ToOrdinalWords()}"); //=> "twelfth"
      Display($"{20.ToOrdinalWords()}"); //=> "twentieth"
      Display($"{21.ToOrdinalWords()}"); //=> "twenty first"
      Display($"{121.ToOrdinalWords()}"); //=> "hundred and twenty first"

      Display($"{10.ToOrdinalWords(new CultureInfo("en-US"))}"); //=> "tenth"
      Display($"{1.ToOrdinalWords(GrammaticalGender.Masculine, new CultureInfo("pt-BR"))}");// => "primeiro"
      Display($"{1.ToOrdinalWords(GrammaticalGender.Masculine, new CultureInfo("fr-FR"))}");// => "premier"

      // for English UK locale
      Display($"{new DateTime(2015, 1, 1).ToOrdinalWords() }"); //=> "1st January 2015"
      Display($"{new DateTime(2015, 2, 12).ToOrdinalWords()}"); //=> "12th February 2015"
      Display($"{new DateTime(2015, 3, 22).ToOrdinalWords()}"); //=> "22nd March 2015"
      // for English US locale
      Display($"{new DateTime(2015, 1, 1).ToOrdinalWords() }"); //=> "January 1st, 2015"
      Display($"{new DateTime(2015, 2, 12).ToOrdinalWords()}"); //=> "February 12th, 2015"
      Display($"{new DateTime(2015, 3, 22).ToOrdinalWords()}"); //=> "March 22nd, 2015"

      Display($"{1.ToRoman()}");  //=> "I"
      Display($"{2.ToRoman()}");  //=> "II"
      Display($"{3.ToRoman()}");  //=> "III"
      Display($"{4.ToRoman()}");  //=> "IV"
      Display($"{5.ToRoman()}");  //=> "V"
      Display($"{6.ToRoman()}");  //=> "VI"
      Display($"{7.ToRoman()}");  //=> "VII"
      Display($"{8.ToRoman()}");  //=> "VIII"
      Display($"{9.ToRoman()}");  //=> "IX"
      Display($"{10.ToRoman()}"); // => "X"
      Display($"{50.ToRoman()}"); // => "L"
      Display($"{1000.ToRoman()}"); // => "M"

      Display($"{"I".FromRoman()}"); //=> 1
      Display($"{"II".FromRoman()}"); //=> 2
      Display($"{"III".FromRoman()}"); //=> 3
      Display($"{"IV".FromRoman()}"); //=> 4
      Display($"{"V".FromRoman()}"); //=> 5

      Display($"{1d.ToMetric()}"); // => "1"
      Display($"{1230d.ToMetric()}"); // => "1.23k"
      Display($"{0.1d.ToMetric()}"); // => "100m"

      Display($"{"1".FromMetric()}"); // => 1
      Display($"{"1.23k".FromMetric()}"); // => 1230
      Display($"{"100m".FromMetric()}"); // => 0.1

      var fileSize = (10).Kilobytes();

      Display($"{fileSize.Bits}"); //      => 81920
      Display($"{fileSize.Bytes}"); //     => 10240
      Display($"{fileSize.Kilobytes}"); // => 10
      Display($"{fileSize.Megabytes}"); // => 0.009765625
      Display($"{fileSize.Gigabytes}"); // => 9.53674316e-6
      Display($"{fileSize.Terabytes}"); // => 9.31322575e-9

      Display($"{3.Bits()}");
      Display($"{5.Bytes()}");
      Display($"{(10.5).Kilobytes()}");
      Display($"{(2.5).Megabytes()}");
      Display($"{(10.2).Gigabytes()}");
      Display($"{(4.7).Terabytes()}");

      //ByteSize total = (10).Gigabytes() + (512).Megabytes() - (2.5).Gigabytes();
      //Display($"{total.Subtract((2500).Kilobytes()).Add((25).Megabytes())}");

      var maxFileSize = (10).Kilobytes();

      Display($"{maxFileSize.LargestWholeNumberSymbol}");  // "KB"
      Display($"{maxFileSize.LargestWholeNumberValue}");   // 10

      Display($"{7.Bits().ToString()}");         // 7 b
      Display($"{8.Bits().ToString()}");         // 1 B
      Display($"{(.5).Kilobytes().Humanize()}");   // 512 B
      Display($"{(1000).Kilobytes().ToString()}"); // 1000 KB
      Display($"{(1024).Kilobytes().Humanize()}"); // 1 MB
      Display($"{(.5).Gigabytes().Humanize()}");   // 512 MB
      Display($"{(1024).Gigabytes().ToString()}"); // 1 TB

      var b = (10.505).Kilobytes();

      // Default number format is #.##
      Display($"{b.ToString("KB")}");         // 10.52 KB
      Display($"{b.Humanize("MB")}");         // .01 MB
      Display($"{b.Humanize("b")}");          // 86057 b

      // Default symbol is the largest metric prefix value >= 1
      Display($"{b.ToString("#.#")}");        // 10.5 KB

      // All valid values of double.ToString(string format) are acceptable
      Display($"{b.ToString("0.0000")}");     // 10.5050 KB
      Display($"{b.Humanize("000.00")}");     // 010.51 KB

      // You can include number format and symbols
      Display($"{b.ToString("#.#### MB")}");  // .0103 MB
      Display($"{b.Humanize("0.00 GB")}");    // 0 GB
      Display($"{b.Humanize("#.## B")}");     // 10757.12 B

      ByteSize output;
      ByteSize.TryParse("1.5mb", out output);

      Display($"{ByteSize.Parse("5b")}");
      Display($"{ByteSize.Parse("1.55B")}");
      Display($"{ByteSize.Parse("1.55KB")}");
      Display($"{ByteSize.Parse("1.55 kB ")}"); // Spaces are trimmed
      Display($"{ByteSize.Parse("1.55 kb")}");
      Display($"{ByteSize.Parse("1.55 MB")}");
      Display($"{ByteSize.Parse("1.55 mB")}");
      Display($"{ByteSize.Parse("1.55 mb")}");
      Display($"{ByteSize.Parse("1.55 GB")}");
      Display($"{ByteSize.Parse("1.55 gB")}");
      Display($"{ByteSize.Parse("1.55 gb")}");
      Display($"{ByteSize.Parse("1.55 TB")}");
      Display($"{ByteSize.Parse("1.55 tB")}");
      Display($"{ByteSize.Parse("1.55 tb")}");

      var size = ByteSize.FromMegabytes(10);
      var measurementInterval = TimeSpan.FromSeconds(1);

      var text = size.Per(measurementInterval).Humanize();
      // 10 MB/s

      text = size.Per(measurementInterval).Humanize(TimeUnit.Minute);
      // 600 MB/min

      text = size.Per(measurementInterval).Humanize(TimeUnit.Hour);
      // 35.15625 GB/hour

      Display($"{19854651984.Bytes().Per(1.Seconds()).Humanize("#.##")}");
      // 18.49 GB/s

      //ModelMetadataProviders.Current = new HumanizerMetadataProvider();



      Display("Press any key to exit :");
      Console.ReadKey();
    }
  }
}
