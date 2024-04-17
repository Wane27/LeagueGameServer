namespace Spells
{
    public class BlindingDart : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
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
            var ap = owner.Stats.AbilityPower.Total * 0.8f;
            var damage = 35 + (spell.CastInfo.SpellLevel * 45) + ap;
            target.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
            var time = 1.25f + (0.25f * spell.CastInfo.SpellLevel);
            AddBuff("Blind", time, 1, spell, target, owner);
            missile.SetToRemove();
        }
    }
}
