namespace Spells
{
    public class CaitlynAceintheHole : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            ChannelDuration = 1.25f,
            TriggersSpellCasts = true
            // TODO
        };

        public void OnSpellPostCast(Spell spell)
        {
            //spell.AddProjectileTarget("CaitlynAceintheHoleMissile", spell.CastInfo.SpellCastLaunchPosition, spell.CastInfo.Targets[0].Unit);
        }

        public void ApplyEffects(ObjAIBase owner, AttackableUnit target, Spell spell, SpellMissile missile)
        {
            if (target != null && !target.IsDead)
            {
                // 250/475/700
                var damage = 250 + (owner.Stats.AttackDamage.Total * 2);
                target.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_SPELL,
                    false);
            }

            missile.SetToRemove();
        }
    }
}