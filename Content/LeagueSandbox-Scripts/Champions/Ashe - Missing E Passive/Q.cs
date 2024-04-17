namespace Spells
{
    public class FrostShot : ISpellScript
    {
        ObjAIBase Ashe;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellCast(Spell spell)
        {
            Ashe = spell.CastInfo.Owner as Champion;
            if (!Ashe.HasBuff("FrostShot"))
            {
                AddBuff("FrostShot", 250000f, 1, spell, Ashe, Ashe, true);
                spell.SetCooldown(0.5f, true);
            }
            else
            {
                RemoveBuff(Ashe, "FrostShot");
            }
        }
    }
    public class FrostArrow : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
    }
}
