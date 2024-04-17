namespace Spells
{
    public class FioraFlurry : ISpellScript
    {
        Spell Flurry;
        ObjAIBase Fiora;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            Flurry = spell;
            Fiora = owner = spell.CastInfo.Owner as Champion;
            AddBuff("FioraFlurry", 3.0f, 1, spell, Fiora, Fiora);
        }
    }
}