namespace ReignSystem.Parameter
{
    public readonly struct InnerReignParameters
    {
        public readonly float water;
        public readonly float food;
        public readonly float population;
        public readonly float content;
        public readonly float economy;
        public readonly float agenda;

        public InnerReignParameters(float water, float food, float population, float content, float economy, float agenda)
        {
            this.water = water;
            this.food = food;
            this.population = population;
            this.content = content;
            this.economy = economy;
            this.agenda = agenda;
        }

        public InnerReignParameters WithWater(float water) => new InnerReignParameters(water, food, population, content, economy, agenda);
        public InnerReignParameters WithFood(float food) => new InnerReignParameters(water, food, population, content, economy, agenda);
        public InnerReignParameters WithPopulation(float population) => new InnerReignParameters(water, food, population, content, economy, agenda);
        public InnerReignParameters WithContent(float content) => new InnerReignParameters(water, food, population, content, economy, agenda);
        public InnerReignParameters WithEconomy(float economy) => new InnerReignParameters(water, food, population, content, economy, agenda);
        public InnerReignParameters WithAgenda(float agenda) => new InnerReignParameters(water, food, population, content, economy, agenda);
    }
}