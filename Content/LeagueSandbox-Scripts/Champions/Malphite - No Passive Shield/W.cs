namespace Spells
{
    public class Obduracy : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true
        };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            AddBuff("MalphiteCleave", 25000f, 1, spell, owner, owner, infiniteduration: true);
        }
        public void OnSpellCast(Spell spell)
        {
            var owner = spell.CastInfo.Owner;
            AddParticleTarget(owner, owner, "Malphite_Enrage_glow.troy", owner, 5f);
            AddBuff("ObduracyBuff", 5f, 1, spell, owner, owner);
        }
    }
}