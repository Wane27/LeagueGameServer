namespace Buffs
{
    internal class IreliaHitenStyle : IBuffGameScript
    {
        Particle P;
        Particle P2;
        Particle P3;
        ObjAIBase Irelia;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Irelia = ownerSpell.CastInfo.Owner as Champion;
            P = AddParticleTarget(Irelia, Irelia, "irelia_hitenstyle_passive", Irelia, buff.Duration, 1, "BUFFBONE_GLB_WEAPON_1");
            P2 = AddParticleTarget(Irelia, Irelia, "irelia_hitenstlye_passive_glow", Irelia, buff.Duration, 1, "BUFFBONE_GLB_WEAPON_1");
            P3 = AddParticleTarget(Irelia, Irelia, "irelia_hitenstlye_passive_glow_end", Irelia, buff.Duration, 1, "BUFFBONE_GLB_WEAPON_1");
            ApiEventManager.OnLaunchAttack.AddListener(this, Irelia, OnLaunchAttack, false);
        }
        public void OnLaunchAttack(Spell spell)
        {
            Irelia.Stats.CurrentHealth += 3 + (2 * Irelia.Spells[1].CastInfo.SpellLevel);
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(P);
            RemoveParticle(P2);
            RemoveParticle(P3);
            ApiEventManager.OnLaunchAttack.RemoveListener(this, Irelia);
        }
    }
}
