namespace Spells
{
    public class JaxCounterStrike : ISpellScript
    {
        ObjAIBase Jax;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnSpellPostCast(Spell spell)
        {
            Jax = spell.CastInfo.Owner as Champion;
            if (!Jax.HasBuff("JaxCounterStrike"))
            {
                spell.SetCooldown(1f, true);
                AddBuff("JaxCounterStrike", 2f, 1, spell, Jax, Jax, false);
            }
            else
            {
                RemoveBuff(Jax, "JaxCounterStrike");
            }
        }
    }
}
