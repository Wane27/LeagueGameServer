namespace Spells
{
    public class AuraofDespair : ISpellScript
    {
        ObjAIBase Owner;
        float timeSinceLastTick = 1000f;
        Spell Spell;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
        };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            Owner = owner;
            Spell = spell;
        }
        public void OnSpellPostCast(Spell spell)
        {
            if (!Owner.HasBuff("AuraofDespair"))
            {
                AddBuff("AuraofDespair", 1, 1, spell, Owner, Owner, true);
                timeSinceLastTick = 1000f;
                spell.SetCooldown(0.5f, true);
            }
            else
            {
                RemoveBuff(Owner, "AuraofDespair");
            }
        }
    }
}