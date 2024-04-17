namespace Spells
{
    public class ZedBasicAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (target.Stats.HealthPoints.Total * 0.5f >= target.Stats.CurrentHealth && !target.HasBuff("ZedPassiveToolTip") && target.Team != owner.Team && !(target is ObjBuilding || target is BaseTurret))
            {
                OverrideAnimation(owner, "attack_passive", "Attack1");
            }
            else
            {
                OverrideAnimation(owner, "Attack1", "attack_passive");
            }
        }
    }
    public class ZedBasicAttack2 : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (target.Stats.HealthPoints.Total * 0.5f >= target.Stats.CurrentHealth && !target.HasBuff("ZedPassiveToolTip") && target.Team != owner.Team && !(target is ObjBuilding || target is BaseTurret))
            {
                OverrideAnimation(owner, "attack_passive", "Attack2");
            }
            else
            {
                OverrideAnimation(owner, "Attack2", "attack_passive");
            }
        }
    }
    public class ZedCritAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (target.Stats.HealthPoints.Total * 0.5f >= target.Stats.CurrentHealth && !target.HasBuff("ZedPassiveToolTip") && target.Team != owner.Team && !(target is ObjBuilding || target is BaseTurret))
            {
                OverrideAnimation(owner, "attack_passive", "Crit");
            }
            else
            {
                OverrideAnimation(owner, "Crit", "attack_passive");
            }
        }
    }
}
