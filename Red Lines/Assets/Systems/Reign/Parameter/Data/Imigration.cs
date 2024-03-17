namespace ReignSystem.Parameter.Data
{
    public readonly struct Imigration
    {
        public readonly float emigrants;

        public Imigration(float emigrants)
        {
            this.emigrants = emigrants;
        }

        public Imigration WithEmigrants(float emigrants) => new Imigration(species, emigrants);
    }

}