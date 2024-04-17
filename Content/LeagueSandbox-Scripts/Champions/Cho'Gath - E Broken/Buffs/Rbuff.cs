namespace Buffs
{
    internal class Feast : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.STACKS_AND_OVERLAPS,
            MaxStacks = 5
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            StatsModifier.Size.PercentBonus = StatsModifier.Size.PercentBonus + 0.2f;
            StatsModifier.Range.FlatBonus = 3.8f*ownerSpell.CastInfo.SpellLevel;
            var HealthBuff = 90f * ownerSpell.CastInfo.SpellLevel ;
            StatsModifier.HealthPoints.BaseBonus += HealthBuff;
            unit.AddStatModifier(StatsModifier);
            unit.Stats.CurrentHealth += HealthBuff;
        }
    }
}
