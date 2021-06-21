using CommandLine;

namespace PlacesInBulgaria.Verbs
{
    [Verb("category", HelpText = "Филтрирарне по категория.")]
    public class CategoryVerb
    {
        [Option('n', "name", Required = true, HelpText = "Име на категорията.")]
        public string Name { get; set; }
    }
}
