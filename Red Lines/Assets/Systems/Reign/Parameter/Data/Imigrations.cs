using System.Collections.Generic;
namespace ReignSystem.Parameter.Data
{
    public readonly struct Imigrations
    {
        public readonly IReadOnlyDictionary<Species, Imigration> emigrations;

        public Imigrations(IReadOnlyDictionary<Species, Imigration> emigrations)
        {
            this.emigrations = emigrations;
        }

        public Imigrations WithEmigrations(IReadOnlyDictionary<Species, Imigration> emigrations) => new Imigrations(emigrations);
    }

}