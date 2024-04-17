namespace Buffs
{
    internal class ItemCrystalFlask : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.HEAL,
            BuffAddType = BuffAddType.STACKS_AND_CONTINUE,
            MaxStacks = 3
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        Particle potion;

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            StatsModifier.ManaRegeneration.FlatBonus = 5f;
            StatsModifier.HealthRegeneration.FlatBonus = 10f;

            unit.AddStatModifier(StatsModifier);
        }
    }
}
