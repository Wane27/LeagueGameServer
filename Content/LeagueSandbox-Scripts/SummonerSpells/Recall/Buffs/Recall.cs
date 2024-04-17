namespace Buffs
{
    class Recall : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_DEHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; }

        private Champion owner;
        private Buff sourceBuff;
        bool willRemove;

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            owner = unit as Champion;
            sourceBuff = buff;

            ApiEventManager.OnTakeDamage.AddListener(this, unit, OnTakeDamage, true);
        }

        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            ApiEventManager.OnTakeDamage.RemoveListener(this, ownerSpell.CastInfo.Owner);
        }

        private void OnTakeDamage(DamageData damageData)
        {
            if (damageData.DamageSource != DamageSource.DAMAGE_SOURCE_PERIODIC)
            {
                willRemove = true;
            }
        }

        public void OnUpdate(float diff)
        {
            if (willRemove)
            {
                StopChanneling(owner, ChannelingStopCondition.Cancel, ChannelingStopSource.LostTarget);

                RemoveBuff(sourceBuff);
            }
        }
    }
}
