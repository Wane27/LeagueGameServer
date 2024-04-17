namespace Buffs
{
    class HateSpikeLine : IBuffGameScript
    {
        float T = 0;
        AttackableUnit Unit;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Unit = unit;
        }
        public void OnUpdate(float diff)
        {
            T += diff;
            if (T >= 30)
            {
                T = 0;
                AddParticle(Unit, null, "Evelynn_Q_mis", Unit.Position, 5f);
            }
        }
    }
}