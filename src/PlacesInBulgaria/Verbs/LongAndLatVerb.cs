using CommandLine;

namespace PlacesInBulgaria.Verbs
{
    [Verb("longitude and latitude", HelpText = "Филтриране по географска дълцина и широчина.")]
    public class LongAndLatVerb
    {
        [Option('l', "longitude latitude", Required = true, HelpText = "Географска дълцина и широчина.")]

        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
