namespace ReignSystem.Parameter.Data
{
    public readonly struct Population
    {
        public readonly float size;
        public readonly float satisfaction;
        public readonly Species species;

        public Population(float size, float satisfaction, Species species)
        {
            this.size = size;
            this.satisfaction = satisfaction;
            this.species = species;
        }

        public Population WithSize(float size) => new Population(size, satisfaction, species);
        public Population WithSatisfaction(float satisfaction) => new Population(size, satisfaction, species);
    }
}