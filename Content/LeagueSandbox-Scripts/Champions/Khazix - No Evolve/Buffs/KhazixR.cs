namespace Buffs
{
    internal class KhazixR : IBuffGameScript
    {
        ObjAIBase Khazix;
        float TrueCooldown;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Khazix = ownerSpell.CastInfo.Owner as Champion;
            TrueCooldown = (9 - Khazix.Spells[0].CastInfo.SpellLevel) * (1 + Khazix.Stats.CooldownReduction.Total);
            Khazix.Spells[3].SetCooldown(TrueCooldown, true);
        }
    }
}
