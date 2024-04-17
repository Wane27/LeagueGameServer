namespace Buffs
{
    internal class Radiance : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            StatsModifier.AttackDamage.FlatBonus += 10f + (ownerSpell.CastInfo.SpellLevel * 20);
            StatsModifier.AbilityPower.FlatBonus += 10f + (ownerSpell.CastInfo.SpellLevel * 20);
            unit.AddStatModifier(StatsModifier);
        }
    }
}
