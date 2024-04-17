namespace Buffs
{
    internal class ZedRHandler : IBuffGameScript
    {
        ObjAIBase Zed;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Zed = ownerSpell.CastInfo.Owner as Champion;
            Zed.SetSpell("ZedR2", 3, true);
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Zed.SetSpell("ZedUlt", 3, true);
        }
    }
}
