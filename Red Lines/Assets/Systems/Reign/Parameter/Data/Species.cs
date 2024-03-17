namespace ReignSystem.Parameter.Data
{
    public readonly struct Species
    {
        public readonly float waterConsumption;
        public readonly float foodConsumption;
        public readonly float economyStrength;
        public readonly float politicalStrength;
        public readonly float emigrationFraction;
        public readonly Agenda agenda;

        public Species(float waterConsumption, float foodConsumption, float economyStrength, float politicalStrength, float emigrationFraction, Agenda agenda)
        {
            this.waterConsumption = waterConsumption;
            this.foodConsumption = foodConsumption;
            this.economyStrength = economyStrength;
            this.politicalStrength = politicalStrength;
            this.emigrationFraction = emigrationFraction;
            this.agenda = agenda;
        }
    }
}