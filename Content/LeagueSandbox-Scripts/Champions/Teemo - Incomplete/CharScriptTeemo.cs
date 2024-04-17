namespace CharScripts
{
    public class CharScriptTeemo : ICharScript
    {
        Spell Passive;
        ObjAIBase Teemo;
        AttackableUnit Target;
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Passive = spell;
            Teemo = owner as Champion;
            ApiEventManager.OnKill.AddListener(this, Teemo, OnKill, false);
            ApiEventManager.OnLevelUp.AddListener(this, Teemo, OnLevelUp, false);
        }
        public void OnKill(DeathData deathData)
        {
            Teemo.Spells[1].SetCooldown(0f, true);
        }
        public void OnLevelUp(AttackableUnit target)
        {
            StatsModifier.Range.FlatBonus = 7.5f;
            Teemo.AddStatModifier(StatsModifier);
        }
    }
}
