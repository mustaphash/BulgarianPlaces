using CommandLine;
using PlacesInBulgaria.Verbs;
using PlacesInBulgaria.Verbs.Parsers;
using System.Collections.Generic;

namespace PlacesInBulgaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<AreaVerb, CategoryVerb, NameVerb, LongAndLatVerb>(args)
                .MapResult(
                  (AreaVerb opts) => new AreaParser().Parse(opts).GetAwaiter().GetResult(),
                  (CategoryVerb opts) => new CategoryParser().ParseCategory(opts).GetAwaiter().GetResult(),
                  (NameVerb opts) => new NameParser().ParseName(opts).GetAwaiter().GetResult(),
                  (LongAndLatVerb opts) => new LongAndLatParser().ParseLongAndLat(opts, opts).GetAwaiter().GetResult(),
                  (IEnumerable<Error> errs) => new ExeptionParser().ExceptionHandling(errs).GetAwaiter().GetResult());
        }
    }
}
