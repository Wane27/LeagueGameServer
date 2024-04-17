namespace Spells
{
    public class EvelynnE : ISpellScript
    {
        float Damage;
        ObjAIBase Evelynn;
        AttackableUnit Target;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
            // TODO
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            Target = target;
            Evelynn = owner = spell.CastInfo.Owner as Champion;
            FaceDirection(Target.Position, Evelynn, true);
        }
        public void OnSpellPostCast(Spell spell)
        {
            AddBuff("EvelynnE", 3.0f, 1, spell, Evelynn, Evelynn);
            if (Evelynn.HasBuff("EvelynnWActive")) { AddBuff("EvelynnWPassive", 3f, 1, spell, Evelynn, Evelynn, false); }
            Damage = 30 + (40 * spell.CastInfo.SpellLevel) + (Evelynn.Stats.AttackDamage.FlatBonus * 0.4f) + Evelynn.Stats.AbilityPower.Total;
            Target.TakeDamage(Evelynn, Damage, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
            AddParticleTarget(Evelynn, Target, "Evelynn_E_tar", Target);
        }
    }
}