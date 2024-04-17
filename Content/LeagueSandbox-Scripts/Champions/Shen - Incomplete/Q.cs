namespace Spells
{
    public class ShenVorpalStar : ISpellScript
    {
        float Health;
        float Damage;
        ObjAIBase Shen;
        SpellMissile Missile;
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata() { TriggersSpellCasts = true };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            Shen = owner = spell.CastInfo.Owner as Champion;
            ApiEventManager.OnSpellHit.AddListener(this, spell, TargetExecute, false);
        }
        public void OnSpellPostCast(Spell spell)
        {
            Missile = spell.CreateSpellMissile(new MissileParameters { Type = MissileType.Target, });
        }

        public void TargetExecute(Spell spell, AttackableUnit target, SpellMissile missile, SpellSector sector)
        {
            missile.SetToRemove();
            AddBuff("ShenVorpalStar", 5f, 1, spell, target, Shen);
            AddParticleTarget(Shen, target, "shen_vorpalStar_tar", target);
            Health = 2 + (4 * Shen.Spells[0].CastInfo.SpellLevel) + (Shen.Stats.HealthPoints.Total * 0.015f);
            Damage = 20f + (Shen.Spells[0].CastInfo.SpellLevel * 40f) + (Shen.Stats.AbilityPower.Total * 0.6f);
            target.TakeDamage(Shen, Damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
            if (target.IsDead) { Shen.TakeHeal(Shen, Health, spell); }
        }
    }
}
