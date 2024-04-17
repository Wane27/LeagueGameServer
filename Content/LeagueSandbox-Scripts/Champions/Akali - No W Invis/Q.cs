namespace Spells
{
    public class AkaliMota : ISpellScript
    {
        float Damage;
        ObjAIBase Akali;
        SpellMissile Missile;
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata() { TriggersSpellCasts = true };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            Akali = owner = spell.CastInfo.Owner as Champion;
            ApiEventManager.OnSpellHit.AddListener(this, spell, TargetExecute, false);
        }
        public void OnSpellPostCast(Spell spell)
        {
            Missile = spell.CreateSpellMissile(new MissileParameters { Type = MissileType.Target, });
        }

        public void TargetExecute(Spell spell, AttackableUnit target, SpellMissile missile, SpellSector sector)
        {
            Damage = 15f + (Akali.Spells[0].CastInfo.SpellLevel * 20f) + (Akali.Stats.AbilityPower.Total * 0.4f);
            target.TakeDamage(Akali, Damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
            AddBuff("AkaliMota", 6f, 1, spell, target, Akali);
            missile.SetToRemove();
        }
    }
}
