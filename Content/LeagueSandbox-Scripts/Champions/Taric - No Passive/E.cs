namespace Spells
{
    public class Dazzle : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            ApiEventManager.OnSpellHit.AddListener(this, spell, TargetExecute, false);
        }

        public void TargetExecute(Spell spell, AttackableUnit target, SpellMissile missile, SpellSector sector)
        {
            var owner = spell.CastInfo.Owner as Champion;
            var time = 1.1f + (0.1f * spell.CastInfo.SpellLevel);
            var ap = owner.Stats.AbilityPower.Total;
            var damage = 10 + (spell.CastInfo.SpellLevel * 30) + (ap * 0.2f);
            var dist = Vector2.DistanceSquared(owner.Position, target.Position);
            if (dist <= 460 * 460)
            {
                damage = 15 + (spell.CastInfo.SpellLevel * 45) + (ap * 0.3f);
            }
            if (dist <= 295 * 295)
            {
                damage = 20 + (spell.CastInfo.SpellLevel * 60) + (ap * 0.4f);
            }
            target.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
            AddBuff("Stun", time, 1, spell, target, owner, false);
            AddBuff("TaricEHud", time, 1, spell, target, owner, false);
            missile.SetToRemove();
        }
    }
    public class TaricDazzleStunMissile : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };
    }
}