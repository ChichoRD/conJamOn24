namespace ReignSystem.Parameter.Data
{
    public readonly struct Imigrations
    {
        public readonly float count;
        public readonly Imigration[] emigrations;

        public Imigrations(float count, Imigration[] emigrations)
        {
            this.count = count;
            this.emigrations = emigrations;
        }

        public Imigrations WithCount(float count) => new Imigrations(count, emigrations);
        public Imigrations WithEmigrations(Imigration[] emigrations) => new Imigrations(count, emigrations);
    }

}