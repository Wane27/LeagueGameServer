namespace Spells
{
    public class DetonatingShot : ISpellScript
    {
        float Damage;
        ObjAIBase Tristana;
        SpellMissile Missile;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            Tristana = owner = spell.CastInfo.Owner as Champion;
            ApiEventManager.OnSpellHit.AddListener(this, spell, TargetExecute, false);
            ApiEventManager.OnLevelUpSpell.AddListener(this, spell, OnLevelUp, true);
        }
        public void OnLevelUp(Spell spell)
        {
            AddBuff("DetonatingShot", 250000f, 1, spell, Tristana, Tristana);
        }
        public void OnSpellPostCast(Spell spell)
        {
            Missile = spell.CreateSpellMissile(new MissileParameters { Type = MissileType.Target });
        }
        public void TargetExecute(Spell spell, AttackableUnit target, SpellMissile missile, SpellSector sector)
        {
            AddBuff("ExplosiveShotDebuff", 5f, 1, spell, target, Tristana, false);
            missile.SetToRemove();
        }
    }
}
