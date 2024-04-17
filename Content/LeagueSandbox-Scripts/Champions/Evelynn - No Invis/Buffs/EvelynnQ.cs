namespace Buffs
{
    class EvelynnQ : IBuffGameScript
    {
        float T;
        float H;
        Spell QSpell;
        ObjAIBase Evelynn;
        public static AttackableUnit Unit;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            QSpell = ownerSpell;
            Evelynn = ownerSpell.CastInfo.Owner as Champion;
        }
        public void OnUpdate(float diff)
        {
            T += diff; H += diff;
            if (H >= 0F)
            {
                H = 0F;
                var units = GetUnitsInRange(Evelynn.Position, 450f, true);
                for (int i = 0; i < units.Count; i++)
                {
                    if (units[i].Team != Evelynn.Team && !(units[i] is ObjBuilding || units[i] is BaseTurret))
                    {
                        Unit = units[i];
                        AddBuff("HateSpikeLineMissile", 0.1f, 1, QSpell, Evelynn, units[i] as ObjAIBase, false);
                        AddBuff("HateSpikeLine", 0.1f, 1, QSpell, units[i], Evelynn, false);
                    }
                }
            }
            if (T >= 0F)
            {
                T = 0F;
                if (!Evelynn.HasBuff("HateSpikeLineMissile"))
                {
                    SealSpellSlot(Evelynn, SpellSlotType.SpellSlots, 0, SpellbookType.SPELLBOOK_CHAMPION, true);
                }
                else
                {
                    SealSpellSlot(Evelynn, SpellSlotType.SpellSlots, 0, SpellbookType.SPELLBOOK_CHAMPION, false);
                }
            }
        }
    }
}