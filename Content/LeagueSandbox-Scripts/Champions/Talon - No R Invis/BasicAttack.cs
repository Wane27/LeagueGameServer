namespace Spells
{
    public class TalonBasicAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("TalonNoxianDiplomacyBuff"))
            {
                OverrideAnimation(owner, "Spell1", "Attack1");
            }
            else
            {
                OverrideAnimation(owner, "Attack1", "Spell1");
            }
        }
    }
    public class TalonBasicAttack2 : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("TalonNoxianDiplomacyBuff"))
            {
                OverrideAnimation(owner, "Spell1", "Attack2");
            }
            else
            {
                OverrideAnimation(owner, "Attack2", "Spell1");
            }
        }
    }
    public class TalonCritAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("TalonNoxianDiplomacyBuff"))
            {
                OverrideAnimation(owner, "Spell1", "Crit");
            }
            else
            {
                OverrideAnimation(owner, "Crit", "Spell1");
            }
        }
    }
}
