namespace Spells
{
    public class NasusQ : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            owner.CancelAutoAttack(true);
            AddBuff("NasusQ", 6.0f, 1, spell, owner, owner);
        }
        public void OnSpellPostCast(Spell spell)
        {
            spell.SetCooldown(0, true);
        }
    }
    public class NasusQAttack : ISpellScript
    {
        float QADamage;
        ObjAIBase Nasus;
        AttackableUnit Target;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            Target = target;
            Nasus = owner = spell.CastInfo.Owner as Champion;
        }
        public void OnSpellCast(Spell spell)
        {
            QADamage = 10 + (20 * Nasus.Spells[0].CastInfo.SpellLevel);
            if (Nasus.HasBuff("NasusQStacks"))
            {
                QADamage += Nasus.GetBuffWithName("NasusQStacks").StackCount;
            }
            AddParticleTarget(Nasus, Target, "Nasus_Base_Q_Tar.troy", Target);
            if (Nasus.IsNextAutoCrit)
            {
                Target.TakeDamage(Nasus, QADamage * 2, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_ATTACK, true);
            }
            else
            {
                Target.TakeDamage(Nasus, QADamage, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
            }
            if (Target.IsDead)
            {
                if (Target is Champion)
                {
                    AddBuff("NasusQStacks", 2500000f, 1, spell, Nasus, Nasus);
                    AddBuff("NasusQStacks", 2500000f, 1, spell, Nasus, Nasus);
                    AddBuff("NasusQStacks", 2500000f, 1, spell, Nasus, Nasus);
                    AddBuff("NasusQStacks", 2500000f, 1, spell, Nasus, Nasus);
                    AddBuff("NasusQStacks", 2500000f, 1, spell, Nasus, Nasus);
                    AddBuff("NasusQStacks", 2500000f, 1, spell, Nasus, Nasus);
                }
                else
                {
                    AddBuff("NasusQStacks", 2500000f, 1, spell, Nasus, Nasus);
                    AddBuff("NasusQStacks", 2500000f, 1, spell, Nasus, Nasus);
                    AddBuff("NasusQStacks", 2500000f, 1, spell, Nasus, Nasus);
                }
            }
        }
    }
}
