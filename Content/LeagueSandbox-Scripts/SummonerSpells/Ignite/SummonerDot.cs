namespace Spells
{
    public class SummonerDot : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = false
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (target != null)
            {
                AddBuff("SummonerDot", 5.0f, 1, spell, target, owner);
            }
        }
    }
}

