namespace Buffs
{
    internal class RivenFengShuiEngine : IBuffGameScript
    {
        Particle Sword;
        Particle Glow_L;
        Particle Glow_R;
        ObjAIBase Riven;
        float TrueCooldown;
        Buff FengShuiEngine;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };


        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            FengShuiEngine = buff;
            Riven = ownerSpell.CastInfo.Owner as Champion;
            Riven.SetSpell("RivenIzunaBlade", 3, true);
            Glow_L = AddParticleTarget(Riven, Riven, "Riven_Base_R_Buff.troy", Riven, buff.Duration, bone: "L_HAND");
            Glow_R = AddParticleTarget(Riven, Riven, "Riven_Base_R_Buff.troy", Riven, buff.Duration, bone: "R_HAND");
            Sword = AddParticleTarget(Riven, Riven, "Riven_Base_R_Sword", Riven, buff.Duration, bone: "BUFFBONE_GLB_WEAPON_2");
            StatsModifier.AttackDamage.PercentBonus = 0.3f + (0.1f * Riven.Spells[3].CastInfo.SpellLevel);
            StatsModifier.Range.FlatBonus = 75f;
            Riven.AddStatModifier(StatsModifier);
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(Sword);
            RemoveParticle(Glow_L);
            RemoveParticle(Glow_R);
            Riven.SetSpell("RivenFengShuiEngine", 3, true);
            TrueCooldown = (85f - (10 * Riven.Spells[3].CastInfo.SpellLevel)) * (1 + Riven.Stats.CooldownReduction.Total);
            Riven.Spells[3].SetCooldown(TrueCooldown, true);
        }
    }
}
