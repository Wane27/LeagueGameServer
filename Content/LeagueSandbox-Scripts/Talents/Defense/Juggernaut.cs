namespace Talents
{
    internal class Talent_4232 : ITalentScript
    {
        public void OnActivate(ObjAIBase owner, byte rank)
        {
            var healthModifier = new StatsModifier();
            healthModifier.HealthPoints.PercentBonus = 0.03f;
            owner.AddStatModifier(healthModifier);
            owner.Stats.CurrentHealth = owner.Stats.HealthPoints.Total;
        }
    }
}
