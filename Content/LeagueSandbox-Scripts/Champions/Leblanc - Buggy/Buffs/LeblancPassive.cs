namespace Buffs
{
    internal class LeblancPassive : IBuffGameScript
    {
        Spell Mini;
        Buff Passive;
        ObjAIBase Leblanc;
        AttackableUnit Unit;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };


        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Unit = unit;
            Mini = ownerSpell;
            Passive = buff;
            Leblanc = ownerSpell.CastInfo.Owner as Champion;
            ApiEventManager.OnTakeDamage.AddListener(this, Leblanc, OnTakeDamage, false);
        }
        public void OnTakeDamage(DamageData damageData)
        {
            if (Leblanc.Stats.HealthPoints.Total * 0.4 >= Leblanc.Stats.CurrentHealth && Leblanc.HasBuff("LeblancPassive"))
            {
                Passive.DeactivateBuff();
            }
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            AddBuff("LeblancMIFull", 1f, 1, ownerSpell, Leblanc, Leblanc, false);
            AddBuff("LeblancPassiveCooldown", 3f, 1, ownerSpell, Leblanc, Leblanc, false);
        }
    }
}
