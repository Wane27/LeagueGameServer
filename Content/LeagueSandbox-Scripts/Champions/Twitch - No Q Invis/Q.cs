namespace Spells
{
    public class TwitchHideInShadows : ISpellScript
    {
        ObjAIBase Twitch;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnSpellPostCast(Spell spell)
        {
            Twitch = spell.CastInfo.Owner as Champion;
            OverrideAnimation(Twitch, "Run_STEALTH", "Run");
            spell.SetCooldown(0, true);
            CreateTimer(1, () =>
            {
                Twitch.SetTargetUnit(null, true);
                AddBuff("TwitchHideInShadows", Twitch.Spells[0].CastInfo.SpellLevel + 9f, 1, spell, Twitch, Twitch);
            });
        }
    }
}
