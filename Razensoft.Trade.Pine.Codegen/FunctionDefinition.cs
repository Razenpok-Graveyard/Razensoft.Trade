using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Codegen
{
    public class FunctionDefinition
    {
        public FunctionDefinition(
            string name,
            string type,
            string description,
            string returns,
            List<string> parameters)
        {
            Name = name;
            Type = type;
            Description = description;
            Returns = returns;
            Parameters = parameters;
        }

        public string Name { get; }

        public string Type { get; }

        public string Description { get; }

        public string Returns { get; }

        public List<string> Parameters { get; }
    }
}