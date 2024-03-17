using System.Collections.Generic;

namespace ReignSystem.Parameter.Data
{
    public readonly struct Emigrations
    {
        public readonly IReadOnlyDictionary<Species, Emigration> emigrations;

        public Emigrations(IReadOnlyDictionary<Species, Emigration> emigrations)
        {
            this.emigrations = emigrations;
        }

        public Emigrations WithEmigrations(IReadOnlyDictionary<Species, Emigration> emigrations) => new Emigrations(emigrations);
    }

}