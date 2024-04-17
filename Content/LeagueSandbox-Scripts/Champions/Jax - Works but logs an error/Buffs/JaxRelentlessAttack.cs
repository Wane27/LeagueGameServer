namespace Buffs
{
    internal class JaxRelentlessAttack : IBuffGameScript
    {
        ObjAIBase Jax;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.STACKS_AND_RENEWS,
            MaxStacks = 3
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Jax = ownerSpell.CastInfo.Owner as Champion;
            switch (buff.StackCount)
            {
                case 3:
                    SpellCast(Jax, 2, SpellSlotType.ExtraSlots, false, Jax.TargetUnit, Vector2.Zero);
                    buff.DeactivateBuff();
                    break;
            }
        }
    }
}
