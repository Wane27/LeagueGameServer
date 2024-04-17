namespace Buffs
{
    class FioraQCD : IBuffGameScript
    {
        Buff QCDBuff;
        ObjAIBase Fiora;
        float TrueCooldown;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            QCDBuff = buff;
            Fiora = ownerSpell.CastInfo.Owner as Champion;
            Fiora.SetSpell("FioraQ", 0, true);
            ApiEventManager.OnSpellPostCast.AddListener(this, Fiora.Spells[0], Q2OnSpellCast);
        }
        public void Q2OnSpellCast(Spell spell) { QCDBuff.DeactivateBuff(); }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            TrueCooldown = (18 - (2 * Fiora.Spells[0].CastInfo.SpellLevel)) * (1 + Fiora.Stats.CooldownReduction.Total);
            Fiora.Spells[0].SetCooldown(TrueCooldown);
        }
    }
}