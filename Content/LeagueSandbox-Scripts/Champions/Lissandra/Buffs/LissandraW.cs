namespace Buffs
{
    internal class LissandraW : IBuffGameScript
    {
        string Nvoa;
        Particle Stun;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.STUN,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; }
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            buff.SetStatusEffect(StatusFlags.Stunned, true);
            Nvoa = unit is Champion ? "Lissandra_Base_W_root_champion" : "Lissandra_Base_W_root_minion";
            Stun = AddParticleTarget(ownerSpell.CastInfo.Owner, unit, Nvoa, unit, buff.Duration);
        }

        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(Stun);
            buff.SetStatusEffect(StatusFlags.Stunned, false);
        }
    }
}