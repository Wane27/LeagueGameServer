namespace Buffs
{
    class EvelynnRSlow : IBuffGameScript
    {
        Particle SLOW;
        ObjAIBase Evelynn;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.SLOW,
            BuffAddType = BuffAddType.REPLACE_EXISTING,
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Evelynn = ownerSpell.CastInfo.Owner as Champion;
            AddBuff("EvelynnRShield", 6f, 1, ownerSpell, Evelynn, Evelynn, false);
            if (Evelynn.HasBuff("EvelynnWActive")) { AddBuff("EvelynnWPassive", 3f, 1, ownerSpell, Evelynn, Evelynn, false); }
            SLOW = AddParticleTarget(Evelynn, unit, "Global_Slow.troy", unit, buff.Duration);
            SpellCast(Evelynn, 4, SpellSlotType.ExtraSlots, true, Evelynn, unit.Position);
            StatsModifier.MoveSpeed.PercentBonus -= 0.1f + (0.2f * ownerSpell.CastInfo.SpellLevel);
            unit.AddStatModifier(StatsModifier);
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell) { RemoveParticle(SLOW); }
    }
}