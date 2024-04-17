namespace Buffs
{
    internal class LissandraREnemy2 : IBuffGameScript
    {
        //string Nvoa;
        Particle Cast;
        Particle Impact;
        Particle Expand;
        Particle RingGreen;
        ObjAIBase Lissandra;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.STUN,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; }
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Lissandra = ownerSpell.CastInfo.Owner as Champion;
            buff.SetStatusEffect(StatusFlags.Stunned, true);
            Cast = AddParticleTarget(Lissandra, unit, "Lissandra_Base_R_cast", unit, buff.Duration);
            Expand = AddParticleTarget(Lissandra, unit, "Lissandra_Base_R_expand", unit, buff.Duration);
            Impact = AddParticleTarget(Lissandra, unit, "Lissandra_Base_R_Dirt_Impact", unit, buff.Duration);
            RingGreen = AddParticleTarget(Lissandra, unit, "Lissandra_Base_R_ring_green", unit, buff.Duration);
            AddParticleTarget(Lissandra, unit, "Lissandra_Base_R_skin", unit, buff.Duration);
            AddParticleTarget(Lissandra, unit, "Lissandra_Base_R_Mark", unit, buff.Duration);
            AddParticleTarget(Lissandra, unit, "Lissandra_Base_R_stun", unit, buff.Duration);
        }

        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            //RemoveParticle(Iceblock);
            RemoveParticle(RingGreen);
            buff.SetStatusEffect(StatusFlags.Stunned, false);
        }
    }
}