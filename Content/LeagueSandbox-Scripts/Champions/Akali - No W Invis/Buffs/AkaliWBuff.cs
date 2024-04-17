namespace Buffs
{
    class AkaliWBuff : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.AURA
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            StatsModifier.MoveSpeed.PercentBonus += 0.2f * ownerSpell.CastInfo.SpellLevel;
            unit.AddStatModifier(StatsModifier);
        }
    }
}
