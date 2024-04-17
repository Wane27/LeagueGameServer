namespace Spells
{
    public class CassiopeiaTwinFang : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters
            {
                Type = MissileType.Target
            }
        };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            ApiEventManager.OnSpellHit.AddListener(this, spell, TargetExecute, false);
        }
        public void TargetExecute(Spell spell, AttackableUnit target, SpellMissile missile, SpellSector sector)
        {
            var owner = spell.CastInfo.Owner as Champion;
            var APratio = owner.Stats.AbilityPower.Total;
            var damage = 30 + spell.CastInfo.SpellLevel * 25 + APratio;
            //todo  amplifying her Poison ,  poison damage against the target by 20%, stacking up to two times.

            AddParticleTarget(owner, target, "Cassiopeia_Base_E_TwinFang_tar.troy", target, 1f);
            target.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
            if (target.HasBuff("CassiopeiaPoisonTicker"))
            {
                for (byte i = 0; i < 4; i++)
                {
                    owner.Spells[i].LowerCooldown(4);
                }
                //cassio ticker 3 buff
            }
            if (target.HasBuff("CassiopeiaPoisonTicker2"))
            {
                for (byte i = 0; i < 4; i++)
                {
                    owner.Spells[i].LowerCooldown(4);
                }
                //cassio ticker 4 buff
            }
        }
    }
}
