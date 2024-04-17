namespace CharScripts
{
    public class CharScriptJax : ICharScript
    {
        float Damage;
        ObjAIBase Jax;
        AttackableUnit Target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Jax = owner as Champion;
            ApiEventManager.OnLaunchAttack.AddListener(this, Jax, OnLaunchAttack, false);
        }
        public void OnLaunchAttack(Spell spell)
        {
            AddBuff("JaxPassive", 4f, 1, spell, Jax, Jax);
        }
    }
}
