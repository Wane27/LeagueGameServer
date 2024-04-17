namespace CharScripts
{
    public class CharScriptZedShadow : ICharScript
    {
        ObjAIBase Shadow;
        AttackableUnit Target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Shadow = owner as Minion;
            ApiEventManager.OnDeath.AddListener(this, Shadow, OnDeath, true);
        }
        public void OnDeath(DeathData data)
        {
            SetStatus(Shadow, StatusFlags.NoRender, true);
            AddParticleTarget(Shadow, Shadow, "Become_Transparent.troy", Shadow, 10, 10);
        }
    }
}
