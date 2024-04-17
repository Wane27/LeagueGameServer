namespace Buffs
{
    internal class TaricEHud : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.STUN,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        Particle stun;
        public void OnActivate(AttackableUnit target, Buff buff, Spell spell)
        {
            AddParticleTarget(spell.CastInfo.Owner, target, "Dazzle_tar.troy", target, buff.Duration);
            stun = AddParticleTarget(spell.CastInfo.Owner, target, "Taric_HammerFlare.troy", target, buff.Duration);
        }
        public void OnDeactivate(AttackableUnit target, Buff buff, Spell spell)
        {
            RemoveParticle(stun);
        }
    }
}