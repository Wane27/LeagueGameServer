namespace Spells
{
    public class CaitlynPiltoverPeacemaker : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            MissileParameters = new MissileParameters
            {
                Type = MissileType.Circle
            }
            // TODO
        };

        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            ApiEventManager.OnSpellHit.AddListener(this, spell, TargetExecute, false);
        }

        public void TargetExecute(Spell spell, AttackableUnit target, SpellMissile missile, SpellSector sector)
        {
            if (missile is SpellCircleMissile skillshot)
            {
                var owner = spell.CastInfo.Owner;
                var reduc = Min(skillshot.ObjectsHit.Count, 5);
                var baseDamage = new[] { 20, 60, 100, 140, 180 }[spell.CastInfo.SpellLevel - 1] +
                                 (1.3f * owner.Stats.AttackDamage.Total);
                var damage = baseDamage * (1 - (reduc / 10));
                target.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
            }
        }
    }
}
