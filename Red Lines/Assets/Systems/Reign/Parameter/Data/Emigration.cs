namespace ReignSystem.Parameter.Data
{
    public readonly struct Emigration
    {
        public readonly float emigrants;
        public readonly int destinationReignIndex;

        public Emigration(Species species, float emigrants, int destinationReignIndex)
        {
            this.emigrants = emigrants;
            this.destinationReignIndex = destinationReignIndex;
        }

        public Emigration WithEmigrants(float emigrants) => new Emigration(species, emigrants, destinationReignIndex);
        public Emigration WithDestinationReignIndex(int destinationReignIndex) => new Emigration(species, emigrants, destinationReignIndex);
    }

}