namespace Buffs
{
    internal class JaxLeapStrikeAttack : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; }

        float Damage;
        ObjAIBase Jax;
        Buff LeapStrike;
        AttackableUnit Unit;
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Unit = unit;
            LeapStrike = buff;
            Jax = LeapStrike.SourceUnit as Champion;
        }
    }
}