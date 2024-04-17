namespace ItemSpells
{
    public class ZhonyasHourglass : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            AddBuff("WoogletsWitchcap", 2.5f, 1, spell, owner, owner, false);
        }
    }
}