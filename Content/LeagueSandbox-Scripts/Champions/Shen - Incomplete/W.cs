namespace Spells
{
    public class ShenFeint : ISpellScript
    {
        ObjAIBase Shen;
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata() { TriggersSpellCasts = true };
        public void OnSpellCast(Spell spell)
        {
            Shen = spell.CastInfo.Owner as Champion;
            AddBuff("ShenFeint", 3f, 1, spell, Shen, Shen);
        }
    }
}
