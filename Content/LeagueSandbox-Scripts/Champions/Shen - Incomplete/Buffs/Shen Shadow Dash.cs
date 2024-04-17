namespace Buffs
{
    internal class Shen_Shadow_Dash : IBuffGameScript
    {
        Particle Taunt;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.TAUNT,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            if (unit is ObjAIBase Taunter)
            {
                FaceDirection(ownerSpell.CastInfo.Owner.Position, Taunter);
                Taunter.SetTargetUnit(ownerSpell.CastInfo.Owner, true);
                Taunter.UpdateMoveOrder(OrderType.AttackTo, true);
            }
            Taunt = AddParticleTarget(ownerSpell.CastInfo.Owner, unit, "LOC_Taunt", unit, buff.Duration, bone: "head");
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(Taunt);
            (unit as ObjAIBase).SetTargetUnit(null, true);
        }
    }
}
