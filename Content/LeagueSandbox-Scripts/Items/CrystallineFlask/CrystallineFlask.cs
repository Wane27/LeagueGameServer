namespace ItemSpells
{
    public class ItemCrystalFlask : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata()
        {
            // TODO
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            AddBuff("ItemCrystalFlask", 12.0f, 1, spell, owner, owner);
        }
    }
}
