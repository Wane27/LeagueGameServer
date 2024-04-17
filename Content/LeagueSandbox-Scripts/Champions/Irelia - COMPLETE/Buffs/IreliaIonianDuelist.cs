namespace Buffs
{
    internal class IreliaIonianDuelist : IBuffGameScript
    {
        Spell Passive;
        ObjAIBase Irelia;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.AURA,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Passive = ownerSpell;
            Irelia = ownerSpell.CastInfo.Owner as Champion;
            var units = GetUnitsInRange(Irelia.Position, 1200f, true);
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].Team != Irelia.Team && units[i] is Champion && units[i] != null)
                {
                    AddBuff("IreliaIonianDuelistDumny", 0.1f, 1, Passive, Irelia, units[i] as ObjAIBase);
                }
            }
            if (Irelia.HasBuff("IreliaIonianDuelistDumny"))
            {
                StatsModifier.Tenacity.FlatBonus += 0.1f + (0.15f * (Irelia.GetBuffWithName("IreliaIonianDuelistDumny").StackCount - 1));
                Irelia.AddStatModifier(StatsModifier);
            }
        }
    }
}
