namespace Buffs
{
    internal class HextechGunbladePassive : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.HEAL
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        Particle potion;

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            var owner = ownerSpell.CastInfo.Owner;
            StatsModifier.SpellVamp.FlatBonus = 0.2f;
          //StatsModifier.CooldownReduction.FlatBonus = 10f;

            unit.AddStatModifier(StatsModifier);
            //TODO: CooldownReduction
        }
    }
}
