namespace CharScripts
{
    public class CharScriptEvelynn : ICharScript
    {
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            ApiEventManager.OnTakeDamage.AddListener(this, owner, SelfWasDamaged, false);
        }
        private void SelfWasDamaged(DamageData damageData)
        {
        }
    }
}

