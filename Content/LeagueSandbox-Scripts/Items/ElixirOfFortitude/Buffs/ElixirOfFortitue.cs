namespace Buffs
{
    internal class PotionOfGiantStrength : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.HEAL
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        Particle potion;

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            var owner = ownerSpell.CastInfo.Owner;
            var extraHP = 120f + (6.39f * owner.Stats.Level);

            StatsModifier.HealthPoints.FlatBonus = extraHP;
            owner.Stats.CurrentHealth = owner.Stats.CurrentHealth + extraHP;
            StatsModifier.AttackDamage.FlatBonus = 15f;

            unit.AddStatModifier(StatsModifier);
        }
    }
}
