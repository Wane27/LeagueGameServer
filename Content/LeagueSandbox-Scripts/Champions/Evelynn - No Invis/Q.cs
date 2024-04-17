namespace Spells
{
    public class EvelynnQ : ISpellScript
    {
        ObjAIBase Evelynn;
        private readonly AttackableUnit Unit = Buffs.EvelynnQ.Unit;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            Evelynn = owner = spell.CastInfo.Owner as Champion;
            ApiEventManager.OnLevelUpSpell.AddListener(this, spell, OnLevelUp, true);
        }
        public void OnLevelUp(Spell spell)
        {
            AddBuff("EvelynnQ", 250000f, 1, spell, Evelynn, Evelynn);
        }

        public void OnSpellPostCast(Spell spell)
        {
            var ownerSkinID = Evelynn.SkinID;
            if (Unit != null)
            {
                //SpellCast(Evelynn, 3, SpellSlotType.ExtraSlots, false, Unit, Vector2.Zero);
            }
        }
    }

    public class HateSpikeLineMissile : ISpellScript
    {
        float Damage;
        ObjAIBase Evelynn;
        SpellMissile Missile;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            IsDamagingSpell = true,
            TriggersSpellCasts = true
        };
        public static List<AttackableUnit> UnitsHit = new List<AttackableUnit>();
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            UnitsHit.Clear();
            Evelynn = owner = spell.CastInfo.Owner as Champion;
            Missile = spell.CreateSpellMissile(new MissileParameters { Type = MissileType.Circle });
            ApiEventManager.OnSpellMissileHit.AddListener(this, Missile, TargetExecute, true);
            if (Missile != null) { }
        }

        public void TargetExecute(SpellMissile missile, AttackableUnit target)
        {
            if (!UnitsHit.Contains(target))
            {
                UnitsHit.Add(target);
                Damage = 15 + (Evelynn.Spells[0].CastInfo.SpellLevel * 15) + Evelynn.Stats.AbilityPower.Total;
                target.TakeDamage(Evelynn, Damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
                AddParticleTarget(Evelynn, target, "Evelynn_Q_tar", target);
            }
        }
    }
}