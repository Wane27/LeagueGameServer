namespace Buffs
{
    internal class Radiance_ally : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            StatsModifier.AttackDamage.FlatBonus += (10f + (ownerSpell.CastInfo.SpellLevel * 20)) / 2;
            StatsModifier.AbilityPower.FlatBonus += (10f + (ownerSpell.CastInfo.SpellLevel * 20)) / 2;
            unit.AddStatModifier(StatsModifier);
        }
    }
}
