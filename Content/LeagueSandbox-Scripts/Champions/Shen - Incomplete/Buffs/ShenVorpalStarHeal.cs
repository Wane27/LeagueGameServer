namespace Buffs
{
    internal class ShenVorpalStarHeal : IBuffGameScript
    {
        float Time;
        float Health;
        Particle Heal;
        ObjAIBase Shen;
        Spell VorpalStar;
        AttackableUnit Unit;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.HEAL,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Unit = unit;
            VorpalStar = ownerSpell;
            Shen = buff.SourceUnit as Champion;
            Heal = AddParticleTarget(Shen, unit, "shen_vorpalStar_lifetap_tar_02", unit, buff.Duration);
            Health = (2 + (4 * Shen.Spells[0].CastInfo.SpellLevel) + (Shen.Stats.HealthPoints.Total * 0.015f)) / 9;
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(Heal);
        }
        public void OnUpdate(float diff)
        {
            Time += diff;
            if (Time >= 300)
            {
                Time = 0;
                Unit.TakeHeal(Shen, Health, VorpalStar);
            }
        }
    }
}
