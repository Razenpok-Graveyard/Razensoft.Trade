namespace Razensoft.Trade.Pine.Codegen
{
    public class VariableDefinition
    {
        public VariableDefinition(string name, string type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
        }

        public string Name { get; }

        public string Type { get; }

        public string Description { get; }
    }
}