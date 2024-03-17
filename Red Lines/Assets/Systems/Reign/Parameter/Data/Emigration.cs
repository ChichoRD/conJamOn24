namespace ReignSystem.Parameter.Data
{
    public readonly struct Emigration
    {
        public readonly Species species;
        public readonly float emigrants;
        public readonly int destinationReignIndex;

        public Emigration(Species species, float emigrants, int destinationReignIndex)
        {
            this.species = species;
            this.emigrants = emigrants;
            this.destinationReignIndex = destinationReignIndex;
        }

        public Emigration WithSpecies(Species species) => new Emigration(species, emigrants, destinationReignIndex);
        public Emigration WithEmigrants(float emigrants) => new Emigration(species, emigrants, destinationReignIndex);
        public Emigration WithDestinationReignIndex(int destinationReignIndex) => new Emigration(species, emigrants, destinationReignIndex);
    }

}