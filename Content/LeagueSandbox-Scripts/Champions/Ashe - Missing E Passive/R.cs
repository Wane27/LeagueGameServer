namespace Spells
{
    public class EnchantedCrystalArrow : ISpellScript
    {
        Spell Arrow;
        float Damage;
        ObjAIBase Ashe;
        SpellMissile Missile;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnSpellPostCast(Spell spell)
        {
            Arrow = spell;
            Ashe = spell.CastInfo.Owner as Champion;
            Missile = spell.CreateSpellMissile(new MissileParameters { Type = MissileType.Circle, });
            ApiEventManager.OnSpellMissileHit.AddListener(this, Missile, TargetExecute, false);
        }
        public void TargetExecute(SpellMissile missile, AttackableUnit target)
        {
            Missile = missile;
            Damage = 200 + (Ashe.Spells[3].CastInfo.SpellLevel * 150) + Ashe.Stats.AttackDamage.FlatBonus + (Ashe.Stats.AbilityPower.Total * 0.9f);
            if (target is Champion)
            {
                Missile.SetToRemove();
                AddBuff("Stun", 2f, 1, Arrow, target, Ashe, false);
                AddParticleTarget(Ashe, target, "Ashe_Base_R_tar.troy", target, lifetime: 1f);
                target.TakeDamage(Ashe, Damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
            }
        }
    }
}
