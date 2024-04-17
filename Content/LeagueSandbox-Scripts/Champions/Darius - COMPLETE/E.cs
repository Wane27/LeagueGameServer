namespace Spells
{
    public class DariusAxeGrabCone : ISpellScript
    {
        private Spell AOE;
        private ObjAIBase Darius;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            AOE = spell;
            Darius = owner = spell.CastInfo.Owner as Champion;
            ApiEventManager.OnSpellHit.AddListener(this, AOE, TargetExecute, false);
            ApiEventManager.OnLevelUpSpell.AddListener(this, spell, OnLevelUp, false);
        }
        public void OnLevelUp(Spell spell)
        {
            AddBuff("DariusAxeGrabArmorPen", 25000f, 1, spell, Darius, Darius);
        }
        public void OnSpellPostCast(Spell spell)
        {
            AOE.CreateSpellSector(new SectorParameters { Length = 540f, SingleTick = true, ConeAngle = 24.76f, Type = SectorType.Cone });
        }
        public void TargetExecute(Spell spell, AttackableUnit target, SpellMissile missile, SpellSector sector)
        {
            if (target.Team != Darius.Team && !(target is ObjBuilding || target is BaseTurret))
            {
                (target as ObjAIBase).UpdateMoveOrder(OrderType.AttackTo, true);
                ForceMovement(target, "RUN", Darius.Position, 1700f, 0, 50.0f, 0, movementOrdersType: ForceMovementOrdersType.CANCEL_ORDER);
            }
            AddParticleTarget(Darius, target, "darius_Base_E_tar.troy", target, 10f);
            AddParticleTarget(Darius, target, "darius_Base_E_tar_02.troy", target, 10f);
            AddParticleTarget(Darius, target, "darius_Base_E_tar_unit_trail.troy", target, 10f);
            AddParticleTarget(Darius, target, "Darius_Base_E_Axegrab_Collision.troy", target, 10f);
        }
    }
}
