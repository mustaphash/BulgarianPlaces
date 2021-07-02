using CommandLine;

namespace PlacesInBulgaria.Verbs
{
    [Verb("longiAndLati", HelpText = "Филтриране по географска дълцина и широчина.")]
    public class LongAndLatVerb
    {
        [Option('l', "longitude", Required = true, HelpText = "Географска дължина.")]
        public double Longitude { get; set; }

        [Option('l', "latitude", Required = true, HelpText = "Географска широчина.")]
        public double Latitude { get; set; }
    }
}
