namespace Buffs
{
    class EvelynnPassive : IBuffGameScript
    {
        float T = 0;
        ObjAIBase Evelynn;
        AttackableUnit Unit;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Unit = unit;
            Evelynn = ownerSpell.CastInfo.Owner as Champion;
        }
        public void OnUpdate(float diff)
        {
            T += diff;
            if (T >= 0) { }
        }
    }
}