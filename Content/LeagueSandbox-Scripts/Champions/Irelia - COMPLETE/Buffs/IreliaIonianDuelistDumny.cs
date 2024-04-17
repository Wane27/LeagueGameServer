namespace Buffs
{
    internal class IreliaIonianDuelistDumny : IBuffGameScript
    {
        Spell Dumny;
        ObjAIBase Irelia;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffAddType = BuffAddType.STACKS_AND_RENEWS,
            MaxStacks = 5
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Dumny = ownerSpell;
            Irelia = ownerSpell.CastInfo.Owner as Champion;
        }
    }
}
