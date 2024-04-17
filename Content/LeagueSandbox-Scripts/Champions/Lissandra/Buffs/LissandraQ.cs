namespace Buffs
{
    public class LissandraQ : IBuffGameScript
    {
        Particle SLOW;
        ObjAIBase Lissandra;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Lissandra = ownerSpell.CastInfo.Owner as Champion;
            StatsModifier.MoveSpeed.PercentBonus -= 0.13f + (0.03f * Lissandra.Spells[2].CastInfo.SpellLevel);
            unit.AddStatModifier(StatsModifier);
            SLOW = AddParticleTarget(ownerSpell.CastInfo.Owner, unit, "Global_Slow.troy", unit, buff.Duration);
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(SLOW);
        }
    }
}
