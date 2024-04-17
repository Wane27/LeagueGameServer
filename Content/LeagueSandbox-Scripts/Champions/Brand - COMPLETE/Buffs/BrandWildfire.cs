namespace Buffs
{
    internal class BrandWildfire : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.STACKS_AND_OVERLAPS,
            MaxStacks = 5
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
    }
}
