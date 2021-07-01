using CommandLine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlacesInBulgaria.Verbs.Parsers
{
    class ExeptionParser
    {
        public Task<int> ExceptionHandling(IEnumerable<Error> errors)
        {
            Console.WriteLine("Something went wrong.");
            return Task.FromResult(0);
        }
    }
}
