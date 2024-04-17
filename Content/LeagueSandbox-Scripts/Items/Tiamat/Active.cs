namespace ItemSpells
{
    public class ItemTiamatCleave : ISpellScript
    {
        ObjAIBase Itemowner;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            Itemowner = owner;
            if (Itemowner.CurrentWaypoint != null) { FaceDirection(Itemowner.CurrentWaypoint, Itemowner); }
        }
        public void OnSpellPostCast(Spell spell)
        {
            var targetPos = GetPointFromUnit(Itemowner, 125f);
            AddParticle(Itemowner, null, "TiamatMelee_itm_active.troy", targetPos);
            var units = GetUnitsInRange(targetPos, 350f, true);
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].Team != Itemowner.Team && !(units[i] is ObjBuilding || units[i] is BaseTurret))
                {
                    units[i].TakeDamage(Itemowner, Itemowner.Stats.AttackDamage.Total, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_SPELLAOE, false);
                }
            }
        }
    }
}
