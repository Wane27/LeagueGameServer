namespace ItemPassives
{
    public class ItemID_3074 : IItemScript
    {
        ObjAIBase Itemowner;
        AttackableUnit Target;
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(ObjAIBase owner)
        {
            Itemowner = owner as Champion;
            ApiEventManager.OnHitUnit.AddListener(this, owner, TargetExecute, false);
        }
        public void TargetExecute(DamageData data)
        {
            Target = data.Target;
            AddParticleTarget(Itemowner, Target, "TiamatMelee_itm_hydra.troy", Target);
            var units = GetUnitsInRange(Target.Position, 250f, true);
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].Team != Itemowner.Team && !(units[i] is ObjBuilding || units[i] is BaseTurret))
                {
                    var damage = Itemowner.Stats.AttackDamage.Total * 0.2f;
                    units[i].TakeDamage(Itemowner, damage, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_SPELLAOE, false);
                }
            }
        }
        public void OnDeactivate(ObjAIBase owner)
        {
            ApiEventManager.OnHitUnit.RemoveListener(this);
        }
    }
}
