namespace Buffs
{
    internal class SpectralFury : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        Particle p;

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            p = AddParticleTarget(ownerSpell.CastInfo.Owner, unit, "spectral_fury_activate_speed", unit, buff.Duration, size: 2);
            StatsModifier.MoveSpeed.PercentBonus = 0.2f;
            StatsModifier.AttackSpeed.PercentBonus = 0.4f;
            unit.AddStatModifier(StatsModifier);
        }

        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(p);
        }
    }
}
