namespace Buffs
{
    internal class TalonShadowAssaultMisBuff : IBuffGameScript
    {
        float T;
        Buff Buff;
        Buff MisBuff;
        Minion Blade;
        Particle ENEMY;
        Particle GREEN;
        ObjAIBase Talon;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };


        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            string RED;
            string BLUE;
            MisBuff = buff;
            Blade = unit as Minion;
            Talon = Blade.Owner as Champion;
            SetStatus(Blade, StatusFlags.Ghosted, true);
            SetStatus(Blade, StatusFlags.NoRender, true);
            SetStatus(Blade, StatusFlags.Targetable, false);
            SetStatus(Blade, StatusFlags.ForceRenderParticles, true);
            switch (Talon.SkinID)
            {
                case 3:
                    BLUE = "talon_ult_blade_hold_dragon.troy";
                    RED = "talon_ult_blade_hold_team_ID_RED_dragon.troy";
                    break;

                case 4:
                    BLUE = "talon_Skin04_ult_blade_hold.troy";
                    RED = "talon_Skin04_ult_blade_hold_team_ID_RED.troy";
                    break;
                case 5:
                    BLUE = "Talon_Skin05_R_Blade_Hold.troy";
                    RED = "Talon_Skin05_R_Blade_Hold_enemy.troy";
                    break;
                case 20:
                    BLUE = "Talon_Skin20_R_Blade_Hold.troy";
                    RED = "Talon_Skin05_R_Blade_Hold_enemy.troy";
                    break;
                case 29:
                    BLUE = "Talon_Skin29_R_Blade_Hold.troy";
                    RED = "Talon_Skin29_R_Blade_Hold_enemy.troy";
                    break;
                case 38:
                    BLUE = "Talon_Skin38_R_Blade_Hold.troy";
                    RED = "Talon_Skin29_R_Blade_Hold_enemy.troy";
                    break;

                default:
                    BLUE = "talon_ult_blade_hold.troy";
                    RED = "talon_ult_blade_hold_team_ID_RED.troy";
                    break;
            }
            if (Talon.Team == TeamId.TEAM_BLUE)
            {
                ENEMY = AddParticle(Talon, null, RED, Blade.Position, lifetime: buff.Duration, teamOnly: TeamId.TEAM_PURPLE);
                GREEN = AddParticle(Talon, null, BLUE, Blade.Position, lifetime: buff.Duration, teamOnly: Talon.Team);
            }
            else
            {
                ENEMY = AddParticle(Talon, null, RED, Blade.Position, lifetime: buff.Duration, teamOnly: TeamId.TEAM_BLUE);
                GREEN = AddParticle(Talon, null, BLUE, Blade.Position, lifetime: buff.Duration, teamOnly: Talon.Team);
            }
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            if (Blade != null && !Blade.IsDead && Talon != null && !Talon.IsDead)
            {
                if (GREEN != null && ENEMY != null)
                {
                    GREEN.SetToRemove();
                    ENEMY.SetToRemove();
                }
                SpellCast(Talon, 4, SpellSlotType.ExtraSlots, true, Talon, GREEN.Position);
                Blade.Die(CreateDeathData(false, 0, Blade, Blade, DamageType.DAMAGE_TYPE_TRUE, DamageSource.DAMAGE_SOURCE_INTERNALRAW, 0.0f));
            }
        }
        public void OnUpdate(float diff)
        {
            T += diff;
            if (T >= 0f)
            {
                if (!Talon.HasBuff("TalonShadowAssaultBuff"))
                {
                    MisBuff.DeactivateBuff();
                }
                T = 0f;
            }
        }
    }
}
