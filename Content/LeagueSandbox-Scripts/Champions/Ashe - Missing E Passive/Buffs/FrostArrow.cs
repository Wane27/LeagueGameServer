namespace Buffs
{
    class FrostArrow : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.SLOW,
            BuffAddType = BuffAddType.RENEW_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            StatsModifier.MoveSpeed.PercentBonus -= 0.1f + (ownerSpell.CastInfo.Owner.Spells[0].CastInfo.SpellLevel * 0.05f);
            unit.AddStatModifier(StatsModifier);
        }
    }
}
