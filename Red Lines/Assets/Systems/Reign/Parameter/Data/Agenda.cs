namespace ReignSystem.Parameter.Data
{
    public readonly struct Agenda
    {
        public readonly float territory;
        public readonly float growth;
        public readonly float war;
        public readonly float expansion;
        public readonly float inclusion;
        public readonly float capitalism;
        public readonly float nacionalism;

        public Agenda(float territory, float growth, float war, float expansion, float inclusion, float capitalism, float nacionalism)
        {
            this.territory = territory;
            this.growth = growth;
            this.war = war;
            this.expansion = expansion;
            this.inclusion = inclusion;
            this.capitalism = capitalism;
            this.nacionalism = nacionalism;
        }
    }
}