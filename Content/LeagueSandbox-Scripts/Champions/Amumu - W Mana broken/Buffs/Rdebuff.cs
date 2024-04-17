namespace Buffs
{
    internal class CurseoftheSadMummyCastEffects : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.SLOW,
            BuffAddType = BuffAddType.REPLACE_EXISTING,
            MaxStacks = 1
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            SetStatus(unit, StatusFlags.CanMove, false);
            SetStatus(unit, StatusFlags.CanAttack, false);
            AddParticleTarget(ownerSpell.CastInfo.Owner, null, "Global_Slow.troy", unit, buff.Duration);
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            SetStatus(unit, StatusFlags.CanMove, true);
            SetStatus(unit, StatusFlags.CanAttack, true);
        }
    }
}
