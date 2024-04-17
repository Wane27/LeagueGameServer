namespace Buffs
{
    internal class PoppyParagonSpeed : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING,
            MaxStacks = 1
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        private float timeSinceLastTick;
        private AttackableUnit Unit;
        private float TickingDamage;
        private ObjAIBase Owner;
        private Spell spell;
        private bool limiter = false;
        float perlevelbonus;

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            var owner = ownerSpell.CastInfo.Owner;
            Owner = owner;
            perlevelbonus = 15f + ownerSpell.CastInfo.SpellLevel * 2;
            owner.Stats.MoveSpeed.PercentBonus += 0.01f * perlevelbonus;
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Owner.Stats.MoveSpeed.PercentBonus -= 0.01f * perlevelbonus;
            Owner.RemoveBuffsWithName("PoppyParagonSpeed");
        }
    }
}