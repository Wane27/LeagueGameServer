namespace Spells
{
    public class JaxEmpowerTwo : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            owner.CancelAutoAttack(true);
            AddBuff("JaxEmpowerTwo", 5f, 1, spell, owner, owner, false);
        }
    }
    public class JaxEmpowerAttack : ISpellScript
    {
        float Damage;
        ObjAIBase Jax;
        AttackableUnit Target;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            Target = target;
            Jax = owner = spell.CastInfo.Owner as Champion;
        }

        public void OnSpellCast(Spell spell)
        {
            Damage = (40 * Jax.Spells[1].CastInfo.SpellLevel) + (Jax.Stats.AbilityPower.Total * 0.6f);
            Target.TakeDamage(Jax, Damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
            AddParticleTarget(Jax, Target, "EmpowerTwo_hit.troy", Target, 1f);
            AddParticleTarget(Jax, Target, "EmpowerTwoHit_tar.troy", Target, 1f);
        }
    }
}
