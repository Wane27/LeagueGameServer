namespace ItemSpells
{
    public class PotionOfGiantStrength : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata()
        {
            // TODO
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            AddBuff("PotionOfGiantStrength", 300.0f, 1, spell, owner, owner);
        }
    }
}
