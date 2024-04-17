namespace Buffs
{
    class EvelynnWPassive : IBuffGameScript
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
            StatsModifier.MoveSpeed.FlatBonus = 4 * ownerSpell.CastInfo.SpellLevel;
            Evelynn.AddStatModifier(StatsModifier);
        }
    }
}