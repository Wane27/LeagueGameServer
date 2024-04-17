namespace Buffs
{
    internal class LeblancChaosOrb : IBuffGameScript
    {
        Buff Orb;
        Particle P;
        ObjAIBase Leblanc;
        AttackableUnit Unit;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.DAMAGE,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };


        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Unit = unit;
            Orb = buff;
            Leblanc = ownerSpell.CastInfo.Owner as Champion;
            ApiEventManager.OnDeath.AddListener(this, Unit, OnDeath, true);
            P = AddParticleTarget(Leblanc, Unit, "LeBlanc_Base_W_aoe_impact", Unit, buff.Duration, 1);
        }
        public void OnDeath(DeathData deathData)
        {
            Orb.DeactivateBuff();
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(P);
        }
    }
}
