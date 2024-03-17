namespace ReignSystem.Parameter
{
    public readonly struct InnerReignParameters
    {
        public readonly float waterBase;
        public readonly float waterReign;
        public readonly float waterGrowthRate;
        public readonly float waterConsumption;
        public readonly float waterAvailable;

        public readonly float foodBase;
        public readonly float food;
        public readonly float foodGrowthRate;
        public readonly float foodConsumption;
        public readonly float foodAvailable;

        public readonly float economy;
        public readonly bool internalConflict;

        public InnerReignParameters(float waterBase, float waterReign, float waterGrowthRate, float waterConsumption, float waterAvailable, float foodBase, float food, float foodGrowthRate, float foodConsumption, float foodAvailable, float economy, bool internalConflict)
        {
            this.waterBase = waterBase;
            this.waterReign = waterReign;
            this.waterGrowthRate = waterGrowthRate;
            this.waterConsumption = waterConsumption;
            this.waterAvailable = waterAvailable;
            this.foodBase = foodBase;
            this.food = food;
            this.foodGrowthRate = foodGrowthRate;
            this.foodConsumption = foodConsumption;
            this.foodAvailable = foodAvailable;
            this.economy = economy;
            this.internalConflict = internalConflict;
        }

        public InnerReignParameters WithWaterReign(float waterReign) =>
            new InnerReignParameters(waterBase, waterReign, waterGrowthRate, waterConsumption, waterAvailable, foodBase, food, foodGrowthRate, foodConsumption, foodAvailable, economy, internalConflict);
        public InnerReignParameters WithWaterConsumption(float waterConsumption) =>
            new InnerReignParameters(waterBase, waterReign, waterGrowthRate, waterConsumption, waterAvailable, foodBase, food, foodGrowthRate, foodConsumption, foodAvailable, economy, internalConflict);
        public InnerReignParameters WithWaterAvailable(float waterAvailable) => 
            new InnerReignParameters(waterBase, waterReign, waterGrowthRate, waterConsumption, waterAvailable, foodBase, food, foodGrowthRate, foodConsumption, foodAvailable, economy, internalConflict);

        public InnerReignParameters WithFood(float food) =>
            new InnerReignParameters(waterBase, waterReign, waterGrowthRate, waterConsumption, waterAvailable, foodBase, food, foodGrowthRate, foodConsumption, foodAvailable, economy, internalConflict);
        public InnerReignParameters WithFoodConsumption(float foodConsumption) =>
            new InnerReignParameters(waterBase, waterReign, waterGrowthRate, waterConsumption, waterAvailable, foodBase, food, foodGrowthRate, foodConsumption, foodAvailable, economy, internalConflict);
        public InnerReignParameters WithFoodAvailable(float foodAvailable) =>
            new InnerReignParameters(waterBase, waterReign, waterGrowthRate, waterConsumption, waterAvailable, foodBase, food, foodGrowthRate, foodConsumption, foodAvailable, economy, internalConflict);

        public InnerReignParameters WithEconomy(float economy) =>
            new InnerReignParameters(waterBase, waterReign, waterGrowthRate, waterConsumption, waterAvailable, foodBase, food, foodGrowthRate, foodConsumption, foodAvailable, economy, internalConflict);

        public InnerReignParameters WithInternalConflict(bool internalConflict) =>
            new InnerReignParameters(waterBase, waterReign, waterGrowthRate, waterConsumption, waterAvailable, foodBase, food, foodGrowthRate, foodConsumption, foodAvailable, economy, internalConflict);
    }
}