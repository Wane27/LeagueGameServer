namespace Spells
{
    public class EvelynnW : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
        };

        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            ApiEventManager.OnLevelUpSpell.AddListener(this, spell, OnLevelUp, true);
        }
        public void OnLevelUp(Spell spell)
        {
            var owner = spell.CastInfo.Owner as Champion;
            AddBuff("EvelynnWActive", 250000f, 1, spell, owner, owner);
        }
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            PlayAnimation(owner, "Spell2", 0.5f);
            AddBuff("EvelynnW", 3.0f, 1, spell, owner, owner);
        }
    }
}