namespace Buffs
{
    internal class VisionWard : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.INTERNAL,
            BuffAddType = BuffAddType.RENEW_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        Region revealStealthed;

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            revealStealthed = AddUnitPerceptionBubble(unit, 1000.0f, 25000f, unit.Team, true);
            ApiEventManager.OnDeath.AddListener(this, unit, OnDeactivate);
        }
        public void OnDeactivate(DeathData death)
        {
            revealStealthed.SetToRemove();
        }
    }
}
