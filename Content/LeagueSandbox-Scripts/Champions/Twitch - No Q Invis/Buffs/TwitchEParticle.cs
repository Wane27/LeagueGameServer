namespace Buffs
{
    internal class TwitchEParticle : IBuffGameScript
    {
        float Damage;
        Spell Expunge;
        Buff Particle;
        ObjAIBase Twitch;
        AttackableUnit Unit;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };


        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Unit = unit;
            Particle = buff;
            Expunge = ownerSpell;
            Twitch = ownerSpell.CastInfo.Owner as Champion;
        }
    }
}
