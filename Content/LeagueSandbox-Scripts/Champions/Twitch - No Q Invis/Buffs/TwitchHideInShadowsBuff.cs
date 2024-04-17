namespace Buffs
{
    internal class TwitchHideInShadowsBuff : IBuffGameScript
    {
        ObjAIBase Twitch;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Twitch = ownerSpell.CastInfo.Owner as Champion;
            StatsModifier.AttackSpeed.PercentBonus += (Twitch.Spells[0].CastInfo.SpellLevel * 0.05f) + 0.35f;
            Twitch.AddStatModifier(StatsModifier);
        }
    }
}
