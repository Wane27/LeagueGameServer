namespace Buffs
{
    internal class PotionOfBrilliance : IBuffGameScript
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
            StatsModifier.AbilityPower.FlatBonus = 25f + (8.3f * owner.Stats.Level);
            StatsModifier.CooldownReduction.FlatBonus = 0.1f;

            unit.AddStatModifier(StatsModifier);
            //TODO: CooldownReduction
        }
    }
}
