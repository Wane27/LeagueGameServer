namespace Buffs
{
    internal class DariusAxeGrabArmorPen : IBuffGameScript
    {
        Particle Slow;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            StatsModifier.ArmorPenetration.PercentBonus = 0.05f * (unit as ObjAIBase).Spells[2].CastInfo.SpellLevel;
            unit.AddStatModifier(StatsModifier);
        }
    }
}
