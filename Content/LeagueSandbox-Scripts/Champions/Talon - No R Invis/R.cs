namespace Spells
{
    public class TalonShadowAssault : ISpellScript
    {
        private ObjAIBase Talon;
        private Spell ShadowAssault;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            ShadowAssault = spell;
            Talon = owner = spell.CastInfo.Owner as Champion;
        }
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            PlayAnimation(Talon, "Spell4");
            for (int bladeCount = 0; bladeCount <= 7; bladeCount++)
            {
                var Start = GetPointFromUnit(Talon, 25f, bladeCount * 45f);
                var End = GetPointFromUnit(Talon, 615f, bladeCount * 45f);
                SpellCast(Talon, 3, SpellSlotType.ExtraSlots, End, Vector2.Zero, true, Start);
                SpellCast(Talon, 5, SpellSlotType.ExtraSlots, End, Vector2.Zero, true, Start);
            }
            AddParticle(Talon, null, "Talon_Base_R_Cas.troy", Talon.Position, 10f);
            AddBuff("TalonShadowAssaultBuff", 2.5f, 1, spell, Talon, Talon, false);
        }
        public void OnSpellPostCast(Spell spell)
        {
            Talon.Spells[3].SetCooldown(0.5f, true);
        }
    }

    public class TalonShadowAssaultMisOne : ISpellScript
    {
        float Damage;
        private ObjAIBase Talon;
        private Spell ShadowAssault;
        private SpellMissile MisOne;
        public List<AttackableUnit> UnitsHit = new List<AttackableUnit>();
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            IsDamagingSpell = true,
            TriggersSpellCasts = true
        };

        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            ShadowAssault = spell;
            Talon = owner = spell.CastInfo.Owner as Champion;
            ApiEventManager.OnSpellHit.AddListener(this, spell, TargetExecute, false);
        }
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            UnitsHit.Clear();
            MisOne = spell.CreateSpellMissile(new MissileParameters
            {
                Type = MissileType.Circle,
                OverrideEndPosition = end
            });
        }
        public void TargetExecute(Spell spell, AttackableUnit target, SpellMissile missile, SpellSector sector)
        {
            Damage = 70 + (50f * Talon.Spells[3].CastInfo.SpellLevel) + (Talon.Stats.AttackDamage.FlatBonus * 0.75f);
            if (target.HasBuff("TalonDamageAmp")) { Damage = Damage + (Damage * 0.03f * Talon.GetSpell("TalonCutthroat").CastInfo.SpellLevel); }
            if (!UnitsHit.Contains(target) && target != Talon && target.Team != Talon.Team && !(target is ObjBuilding || target is BaseTurret))
            {
                UnitsHit.Add(target);
                target.TakeDamage(Talon, Damage, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
                AddParticleTarget(Talon, target, "talon_ult_tar.troy", target, 1f);
            }
        }
    }
    public class TalonShadowAssaultMisOneHalf : ISpellScript
    {
        float Damage;
        private ObjAIBase Talon;
        private Spell ShadowAssault;
        private SpellMissile MisOneHalf;
        public List<AttackableUnit> UnitsHit = new List<AttackableUnit>();
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            IsDamagingSpell = true,
            TriggersSpellCasts = true
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            UnitsHit.Clear();
            ShadowAssault = spell;
            Talon = owner = spell.CastInfo.Owner as Champion;
            MisOneHalf = spell.CreateSpellMissile(new MissileParameters
            {
                Type = MissileType.Circle,
                OverrideEndPosition = end
            });
            ApiEventManager.OnSpellMissileEnd.AddListener(this, MisOneHalf, OnMissileEnd, true);
            if (MisOneHalf != null) { AddParticleTarget(Talon, MisOneHalf, "Talon_Skin29_B_T.troy", MisOneHalf, 25000f); }
        }
        public void OnMissileEnd(SpellMissile missile)
        {
            MisOneHalf = missile;
            Minion Blade = AddMinion(Talon, "TestCubeRender", "TestCubeRender", MisOneHalf.Position, Talon.Team, Talon.SkinID, true, false);
            AddBuff("TalonShadowAssaultMisBuff", 2.24f, 1, ShadowAssault, Blade, Blade, false);
        }

    }
    public class TalonShadowAssaultMisTwo : ISpellScript
    {
        float Damage;
        private ObjAIBase Talon;
        private Spell ShadowAssault;
        private SpellMissile MisTwo;
        public List<AttackableUnit> UnitsHit = new List<AttackableUnit>();
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            MissileParameters = new MissileParameters
            {
                Type = MissileType.Target
            },
            IsDamagingSpell = true,
            TriggersSpellCasts = true
        };

        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            ShadowAssault = spell;
            Talon = owner = spell.CastInfo.Owner as Champion;
            ApiEventManager.OnSpellHit.AddListener(this, spell, TargetExecute, false);
        }
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            UnitsHit.Clear();
            MisTwo = spell.CreateSpellMissile(new MissileParameters
            {
                Type = MissileType.Circle
            });
            if (MisTwo != null) { AddParticleTarget(owner, MisTwo, "Talon_Skin29_B_T.troy", MisTwo, 25000f); }
        }

        public void TargetExecute(Spell spell, AttackableUnit target, SpellMissile missile, SpellSector sector)
        {
            MisTwo = missile;
            if (target == Talon) { MisTwo.SetToRemove(); }
            Damage = 70 + (50f * Talon.Spells[3].CastInfo.SpellLevel) + (Talon.Stats.AttackDamage.FlatBonus * 0.75f);
            if (target.HasBuff("TalonDamageAmp")) { Damage = Damage + (Damage * 0.03f * Talon.GetSpell("TalonCutthroat").CastInfo.SpellLevel); }
            if (!UnitsHit.Contains(target) && target != Talon && target.Team != Talon.Team && !(target is ObjBuilding || target is BaseTurret))
            {
                UnitsHit.Add(target);
                target.TakeDamage(Talon, Damage, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
                AddParticleTarget(Talon, target, "talon_ult_tar.troy", target, 1f);
            }
        }
    }
    public class TalonShadowAssaultToggle : ISpellScript
    {
        float TrueCooldown;
        private ObjAIBase Talon;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            Talon = owner = spell.CastInfo.Owner as Champion;
            if (Talon.HasBuff("TalonShadowAssaultBuff")) { Talon.RemoveBuffsWithName("TalonShadowAssaultBuff"); }
        }
        public void OnSpellPostCast(Spell spell)
        {
            TrueCooldown = (85f - (10 * Talon.Spells[3].CastInfo.SpellLevel)) * (1 + Talon.Stats.CooldownReduction.Total);
            Talon.Spells[3].SetCooldown(TrueCooldown, true);
        }
    }
}
