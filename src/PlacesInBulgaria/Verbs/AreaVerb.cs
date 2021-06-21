using CommandLine;

namespace PlacesInBulgaria.Verbs
{
    [Verb("area", HelpText = "Филтриране по област.")]
    public class AreaVerb
    {
        [Option('n', "name", Required = true, HelpText = "Име на област в България.")]
        public string Name { get; set; }
    }
}
