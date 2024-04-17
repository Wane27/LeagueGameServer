namespace Spells
{
    public class EvelynnR : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = false
        };

        private ObjAIBase Evelynn;
        private Spell Spell;

        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            Spell = spell;
            Evelynn = owner = Spell.CastInfo.Owner as Champion;
        }

        public void OnSpellPostCast(Spell spell)
        {
            var targetPos = new Vector2(spell.CastInfo.TargetPosition.X, spell.CastInfo.TargetPosition.Z);
            var ownerPos = Evelynn.Position;
            var distance = Vector2.Distance(ownerPos, targetPos);
            FaceDirection(targetPos, Evelynn);
            AddParticle(Evelynn, null, "Evelynn_R_cas.troy", targetPos, 5f, 1);
            var units = GetUnitsInRange(targetPos, 350f, true);
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].Team != Evelynn.Team && !(units[i] is ObjBuilding || units[i] is BaseTurret))
                {
                    var ELevel = Evelynn.Spells[3].CastInfo.SpellLevel;
                    var damage = 55 + (40 * (ELevel - 1)) + (Evelynn.Stats.AbilityPower.Total * 0.6f);
                    AddParticleTarget(Evelynn, units[i], "Evelynn_R_tar.troy", units[i], 5f, 1);
                    units[i].TakeDamage(Evelynn, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
                    AddBuff("EvelynnRSlow", 2f, 1, spell, units[i], Evelynn, false);
                }
            }
        }
    }
    public class EvelynnRHeal : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = false
        };

        private ObjAIBase Evelynn;
        private Spell Spell;

        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            Spell = spell;
            Evelynn = owner = Spell.CastInfo.Owner as Champion;
        }

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            var missile = spell.CreateSpellMissile(new MissileParameters
            {
                Type = MissileType.Target,
            });
            ApiEventManager.OnSpellHit.AddListener(this, spell, TargetExecute, false);
        }
        public void TargetExecute(Spell spell, AttackableUnit target, SpellMissile missile, SpellSector sector)
        {
            if (target == Evelynn)
            {
                //AddBuff("EvelynnRShield", 6f, 1, spell, Evelynn, Evelynn, false);
                missile.SetToRemove();
            }
        }
    }
}