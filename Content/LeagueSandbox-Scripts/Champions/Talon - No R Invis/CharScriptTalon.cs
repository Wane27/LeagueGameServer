namespace CharScripts
{
    public class CharScriptTalon : ICharScript
    {
        float Damage;
        float Ampdamage;
        ObjAIBase Talon;
        AttackableUnit Target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Talon = owner as Champion;
            ApiEventManager.OnLaunchAttack.AddListener(this, Talon, OnLaunchAttack, false);
        }
        public void OnLaunchAttack(Spell spell)
        {
            Target = Talon.TargetUnit;
            Damage = Talon.Stats.AttackDamage.Total * 0.1f;
            Ampdamage = Talon.Stats.AttackDamage.Total * (0.03f * Talon.Spells[2].CastInfo.SpellLevel);
            if (Target.HasBuff("TalonSlow") || Target.HasBuff("TalonESlow") || Target.HasBuff("Stun") || Target.HasBuff("Slow") || Target.HasBuff("Disarm") || Target.HasBuff("Silence") || Target.HasBuff("Blind") || Target.HasBuff("Pulverize") || Target.HasBuff("Frozen_Mallet_Slow"))
            {
                Target.TakeDamage(Talon, Damage, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
            }
            if (Target.HasBuff("TalonDamageAmp"))
            {
                Target.TakeDamage(Talon, Ampdamage, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
            }
            if (Talon.HasBuff("TalonShadowAssaultBuff")) { Talon.RemoveBuffsWithName("TalonShadowAssaultBuff"); }
        }
    }
}
