namespace Buffs
{
    class EvelynnW : IBuffGameScript
    {
        ObjAIBase Evelynn;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING,
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Evelynn = ownerSpell.CastInfo.Owner as Champion;
            StatsModifier.MoveSpeed.PercentBonus = 0.20f + (0.01f * ownerSpell.CastInfo.SpellLevel);
            Evelynn.AddStatModifier(StatsModifier);
        }
    }
}