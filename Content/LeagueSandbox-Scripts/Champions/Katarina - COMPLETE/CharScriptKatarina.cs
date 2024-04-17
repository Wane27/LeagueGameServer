namespace CharScripts
{
    public class CharScriptKatarina : ICharScript
    {
        ObjAIBase Katarina;
        AttackableUnit target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Katarina = owner as Champion;
            ApiEventManager.OnKill.AddListener(this, Katarina, OnKill, false);
            ApiEventManager.OnLaunchAttack.AddListener(this, Katarina, OnLaunchAttack, false);
        }
        public void OnKill(DeathData Data)        
        {  
            for (byte i = 0; i < 4; i++)
            {
                Katarina.Spells[i].LowerCooldown(15);
            }
        }
        public void OnLaunchAttack(Spell spell)
        {
            target = spell.CastInfo.Targets[0].Unit;
            var owner = spell.CastInfo.Owner;
            var MarkAP = spell.CastInfo.Owner.Stats.AbilityPower.Total * 0.15f;
            float MarkDamage = 15f * (owner.GetSpell("KatarinaQ").CastInfo.SpellLevel) + MarkAP;

            if (target.HasBuff("KatarinaQMark"))
            {
                target.TakeDamage(owner, MarkDamage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_PROC, false);
                RemoveBuff(target, "KatarinaQMark");
            }
        }
    }
}
