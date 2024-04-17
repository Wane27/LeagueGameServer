namespace Buffs
{
    internal class NasusQStacks : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.STACKS_AND_RENEWS,
            MaxStacks = 999999
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
    }
}
