namespace ReignSystem.Parameter.Data
{
    public readonly struct Emigrations
    {
        public readonly float count;
        public readonly Emigration[] emigrations;

        public Emigrations(float count, Emigration[] emigrations)
        {
            this.count = count;
            this.emigrations = emigrations;
        }

        public Emigrations WithCount(float count) => new Emigrations(count, emigrations);
        public Emigrations WithEmigrations(Emigration[] emigrations) => new Emigrations(count, emigrations);
    }

}