namespace ReignSystem.Parameter.Data
{
    public readonly struct BorderStatus
    {
        public readonly float conflict;
        public readonly float health;

        public BorderStatus(float conflict, float health)
        {
            this.conflict = conflict;
            this.health = health;
        }

        public BorderStatus WithConflict(float conflict) => new BorderStatus(conflict, health);
        public BorderStatus WithHealth(float health) => new BorderStatus(conflict, health);
    }
}