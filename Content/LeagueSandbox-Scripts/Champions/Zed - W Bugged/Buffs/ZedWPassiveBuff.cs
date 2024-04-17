namespace Buffs
{
    class ZedWPassiveBuff : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.AURA,
            BuffAddType = BuffAddType.REPLACE_EXISTING,
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            StatsModifier.AttackDamage.PercentBonus += 0.05f * ownerSpell.CastInfo.SpellLevel;
            unit.AddStatModifier(StatsModifier);
        }
    }
}
