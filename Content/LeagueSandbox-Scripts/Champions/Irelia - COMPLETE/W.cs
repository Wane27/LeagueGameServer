namespace Spells
{
    public class IreliaHitenStyle : ISpellScript
    {
        ObjAIBase Irelia;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            Irelia = owner = spell.CastInfo.Owner as Champion;
            ApiEventManager.OnLevelUpSpell.AddListener(this, spell, OnLevelUp, true);
        }
        public void OnLevelUp(Spell spell)
        {
            AddBuff("IreliaHitenStyle", 250000f, 1, spell, Irelia, Irelia);
        }
        public void OnSpellCast(Spell spell)
        {
            Irelia.CancelAutoAttack(true);
            AddBuff("IreliaHitenStyleCharged", 6.0f, 1, spell, Irelia, Irelia);
            if (Irelia.HasBuff("IreliaHitenStyle")) { Irelia.RemoveBuffsWithName("IreliaHitenStyle"); }
        }
    }
}
