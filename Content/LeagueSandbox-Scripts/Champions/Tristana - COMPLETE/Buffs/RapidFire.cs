namespace Buffs
{
    internal class RapidFire : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            AddParticleTarget(unit, unit, "RapidFire_cas.troy", unit, 1f, 1f, "WEAPON");
            StatsModifier.AttackSpeed.PercentBonus = 0.1f + (0.2f * ownerSpell.CastInfo.SpellLevel);
            unit.AddStatModifier(StatsModifier);
        }
    }
}
