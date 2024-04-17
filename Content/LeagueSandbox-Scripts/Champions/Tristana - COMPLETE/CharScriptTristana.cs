namespace CharScripts
{
    public class CharScriptTristana : ICharScript
    {
        Spell Passive;
        ObjAIBase Tristana;
        AttackableUnit Target;
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Passive = spell;
            Tristana = owner as Champion;
            ApiEventManager.OnKill.AddListener(this, Tristana, OnKill, false);
            ApiEventManager.OnLevelUp.AddListener(this, Tristana, OnLevelUp, false);
        }
        public void OnKill(DeathData deathData)
        {
            Tristana.Spells[1].SetCooldown(0f, true);
        }
        public void OnLevelUp(AttackableUnit target)
        {
            StatsModifier.Range.FlatBonus = 7.5f;
            Tristana.AddStatModifier(StatsModifier);
        }
    }
}
