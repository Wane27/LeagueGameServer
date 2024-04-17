namespace Buffs
{
    internal class TalonShadowAssaultBuff : IBuffGameScript
    {
        Particle Invis;
        Particle Sound;
        Particle linger;
        ObjAIBase Talon;
        Buff AssaultBuff;
        float TrueCooldown;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };


        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Talon = ownerSpell.CastInfo.Owner as Champion;
            StatsModifier.MoveSpeed.PercentBonus += 0.4f;
            Talon.AddStatModifier(StatsModifier);
            Talon.SetSpell("TalonShadowAssaultToggle", 3, true);
            Invis = AddParticleTarget(Talon, Talon, "Talon_Base_R_Cas_Invis.troy", Talon, 2.5f);
            Sound = AddParticleTarget(Talon, Talon, "talon_ult_sound.troy", Talon, 10f);
            linger = AddParticle(Talon, null, "Ashe_Skin06_E_tar_linger.troy", Talon.Position, 10f);
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(Sound);
            RemoveParticle(linger);
            Talon.SetSpell("TalonShadowAssault", 3, true);
            PlaySound("Play_vo_Talon_TalonShadowAssaultBuff_OnBuffDeactivate", Talon);
            TrueCooldown = (85f - (10 * Talon.Spells[3].CastInfo.SpellLevel)) * (1 + Talon.Stats.CooldownReduction.Total);
            Talon.Spells[3].SetCooldown(TrueCooldown, true);
        }
    }
}
