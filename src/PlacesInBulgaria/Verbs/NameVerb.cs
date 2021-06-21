using CommandLine;

namespace PlacesInBulgaria.Verbs
{
    [Verb("name", HelpText = "Филтрирарне по име.")]
    public class NameVerb
    {
        [Option('n', "name", Required = true, HelpText = "Име на категорията.")]
        public string Name { get; set; }
    }
}
