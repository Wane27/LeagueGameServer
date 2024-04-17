namespace Buffs
{
    internal class LeblancSlide : IBuffGameScript
    {
        Buff Slide;
        ObjAIBase Leblanc;
        AttackableUnit Unit;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };


        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Unit = unit;
            Slide = buff;
            Leblanc = ownerSpell.CastInfo.Owner as Champion;
            Leblanc.SetSpell("LeblancSlideReturn", 1, true);
            ApiEventManager.OnSpellCast.AddListener(this, Leblanc.GetSpell("LeblancSlideReturn"), W2OnSpellCast);
        }
        public void W2OnSpellCast(Spell spell)
        {
            Slide.DeactivateBuff();
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Leblanc.SetSpell("LeblancSlide", 1, true);
            Leblanc.RemoveBuffsWithName("LeblancSlideMove");
        }
    }
}
