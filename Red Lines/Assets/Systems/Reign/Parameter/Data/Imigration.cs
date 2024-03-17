namespace ReignSystem.Parameter.Data
{
    public readonly struct Imigration
    {
        public readonly Species species;
        public readonly float emigrants;

        public Imigration(Species species, float emigrants)
        {
            this.species = species;
            this.emigrants = emigrants;
        }

        public Imigration WithSpecies(Species species) => new Imigration(species, emigrants);
        public Imigration WithEmigrants(float emigrants) => new Imigration(species, emigrants);
    }

}