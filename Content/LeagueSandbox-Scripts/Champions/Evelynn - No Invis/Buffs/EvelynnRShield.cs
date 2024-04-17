namespace Buffs
{
    class EvelynnRShield : IBuffGameScript
    {
        float HP;
        float CHP;
        float Damage;
        float ShieldN;
        Particle Shield;
        ObjAIBase Evelynn;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING,
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Evelynn = ownerSpell.CastInfo.Owner as Champion;
            HP = Evelynn.Stats.HealthPoints.Total * 1;
            CHP = Evelynn.Stats.CurrentHealth;
            Shield = AddParticleTarget(Evelynn, unit, "Evelynn_R_Shield.troy", unit, buff.Duration);
            if (CHP + (75 * (1 + Evelynn.Spells[3].CastInfo.SpellLevel)) > HP)
            {
                Evelynn.Stats.CurrentHealth += 75 * (1 + Evelynn.Spells[3].CastInfo.SpellLevel);
                StatsModifier.HealthPoints.FlatBonus += 75 * (1 + Evelynn.Spells[3].CastInfo.SpellLevel);
                Evelynn.AddStatModifier(StatsModifier);
            }
            else
            {
                Evelynn.Stats.CurrentHealth += 75 * (1 + Evelynn.Spells[3].CastInfo.SpellLevel);
            }
            ApiEventManager.OnTakeDamage.AddListener(this, Evelynn, TakeDamage, false);
        }
        public void TakeDamage(DamageData damageData)
        {
            Damage += damageData.Damage;
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            ShieldN = (75 * (1 + Evelynn.Spells[3].CastInfo.SpellLevel)) - Damage;
            if (ShieldN > 0)
            {
                Evelynn.TakeDamage(Evelynn, ShieldN, DamageType.DAMAGE_TYPE_TRUE, DamageSource.DAMAGE_SOURCE_SPELL, false);
            }
            else
            {

            }
            RemoveParticle(Shield);
        }
    }
}