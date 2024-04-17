namespace Buffs
{
    internal class MordekaiserCOTGDot : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.SLOW,
            BuffAddType = BuffAddType.STACKS_AND_RENEWS
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        float timeSinceLastTick;
        AttackableUnit Unit;
        float TickingDamage;
        ObjAIBase Owner;
        Buff Buff;
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Owner = ownerSpell.CastInfo.Owner;
            Unit = unit;

            var damage = unit.Stats.HealthPoints.Total * (0.12f + (0.025f * (ownerSpell.CastInfo.SpellLevel - 1)) + (Owner.Stats.AbilityPower.Total * 0.0002f));

            AddParticleTarget(Owner, unit, "mordekeiser_cotg_tar.troy", unit, buff.Duration);
            unit.TakeDamage(Owner, damage, DamageType.DAMAGE_TYPE_TRUE, DamageSource.DAMAGE_SOURCE_SPELL, false);
            Owner.Stats.CurrentHealth += damage;

            ApiEventManager.OnDeath.AddListener(this, unit, OnDeath, true);
        }

        public void OnDeath(DeathData deathData)
        {
            var ghost = AddMinion(Owner, deathData.Unit.Model, deathData.Unit.Model, deathData.Unit.Position, Buff.SourceUnit.Team);
            AddParticleTarget(Owner, ghost, "mordekeiser_cotg_skin.troy", ghost, lifetime: 30f);
            AddBuff("MordekaiserCOTGPet", 40f, 1, Buff.OriginSpell, ghost, ghost);
        }

        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            ApiEventManager.OnDeath.RemoveListener(this);
        }

        public void OnUpdate(float diff)
        {
            timeSinceLastTick += diff;

            if (timeSinceLastTick >= 1000.0f)
            {
                var damage = Unit.Stats.HealthPoints.Total * (0.012f + (0.0025f * (Buff.OriginSpell.CastInfo.SpellLevel - 1)) + (Owner.Stats.AbilityPower.Total * 0.00002f));
                Unit.TakeDamage(Unit, TickingDamage, DamageType.DAMAGE_TYPE_TRUE, DamageSource.DAMAGE_SOURCE_PERIODIC, false);
                Owner.Stats.CurrentHealth += Unit.Stats.GetPostMitigationDamage(TickingDamage, DamageType.DAMAGE_TYPE_MAGICAL, Owner);
                timeSinceLastTick = 0;
            }
        }
    }
}