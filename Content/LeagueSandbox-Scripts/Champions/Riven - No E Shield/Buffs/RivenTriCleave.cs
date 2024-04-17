namespace Buffs
{
    internal class RivenTriCleave : IBuffGameScript
    {
        float TrueCooldown;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.STACKS_AND_RENEWS,
            MaxStacks = 3
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            buff.SetStatusEffect(StatusFlags.Ghosted, true);
            if (unit.HasBuff("RivenTriCleave"))
            {
                LogDebug(buff.StackCount.ToString());
                if (buff.StackCount < 3)
                {
                    ownerSpell.SetCooldown(0.5f, true);
                }
                else
                {
                    buff.DeactivateBuff();
                }
            }
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            TrueCooldown = 13 * (1 + unit.Stats.CooldownReduction.Total);
            ownerSpell.SetCooldown(TrueCooldown, true);
            buff.SetStatusEffect(StatusFlags.Ghosted, false);
        }
    }
}
