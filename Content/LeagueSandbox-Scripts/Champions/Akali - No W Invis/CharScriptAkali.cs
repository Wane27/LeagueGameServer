namespace CharScripts
{
    public class CharScriptAkali : ICharScript
    {
        float Ampdamage;
        ObjAIBase Akali;
        AttackableUnit Target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Akali = owner as Champion;
            Akali.Stats.SpellVamp.PercentBonus = 6 + (Akali.Stats.AttackDamage.FlatBonus % 6);
            ApiEventManager.OnLaunchAttack.AddListener(this, Akali, OnLaunchAttack, false);
        }
        public void OnLaunchAttack(Spell spell)
        {
            Target = spell.CastInfo.Targets[0].Unit;
            Ampdamage = 20 + (25 * Akali.Spells[0].CastInfo.SpellLevel) + (Akali.Stats.AbilityPower.Total * 0.5f);
            if (Target.HasBuff("AkaliMota"))
            {
                Target.TakeDamage(Akali, Ampdamage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
                AddParticleTarget(Akali, Target, "akali_mark_impact_tar", Target, 10f);
                RemoveBuff(Target, "AkaliMota");
            }
        }
    }
}

