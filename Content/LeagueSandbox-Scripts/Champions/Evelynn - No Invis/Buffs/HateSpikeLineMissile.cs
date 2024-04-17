namespace Buffs
{
    class HateSpikeLineMissile : IBuffGameScript
    {
        Buff LineMissile;
        ObjAIBase Evelynn;
        public static AttackableUnit Unit;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            LineMissile = buff;
            Evelynn = ownerSpell.CastInfo.Owner as Champion;
            ApiEventManager.OnSpellCast.AddListener(this, Evelynn.Spells[0], QOnSpellCast);
        }
        public void QOnSpellCast(Spell spell)
        {
            Unit = Evelynn.TargetUnit != null ? Evelynn.TargetUnit : LineMissile.SourceUnit;
            if (Unit.HasBuff("HateSpikeLine"))
            {
                SpellCast(Evelynn, 3, SpellSlotType.ExtraSlots, Unit.Position, Unit.Position, true, Vector2.Zero);
                //SpellCast(Evelynn, 3, SpellSlotType.ExtraSlots, false, Unit.Position, Unit.Position ,Vector2.Zero);
                Minion a = AddMinion(Evelynn, "TestCube", "TestCube", Evelynn.Position, Evelynn.Team, Evelynn.SkinID, true, false);
                FaceDirection(Unit.Position, a);
                AddBuff("HateSpikeLine", 0.3f, 1, spell, a, Evelynn, false);
                ForceMovement(a, null, GetPointFromUnit(a, 650), 2200, 0, 0, 0);
            }
            else
            {
                Evelynn.SetTargetUnit(null, true);
            }
        }
    }
}