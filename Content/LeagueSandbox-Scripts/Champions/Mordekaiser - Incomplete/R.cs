namespace Spells
{
    public class MordekaiserChildrenOfTheGrave : ISpellScript
    {
        AttackableUnit Target;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            NotSingleTargetSpell = true
            // TODO
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            Target = target;
        }

        public void OnSpellCast(Spell spell)
        {
            AddBuff("MordekaiserCOTGDot", 10.4f, 1, spell, Target, spell.CastInfo.Owner);
        }
    }
}