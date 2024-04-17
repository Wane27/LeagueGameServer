namespace CharScripts
{
     
    public class CharScriptKayle: ICharScript

    {
        Spell Spell;
        public void OnActivate(ObjAIBase owner, Spell spell)

        {

            Spell = spell;


            {
                ApiEventManager.OnHitUnit.AddListener(this, owner, OnHitUnit, false);
            }
        }
        public void OnHitUnit(DamageData damageData)

        
        {
            var owner = Spell.CastInfo.Owner;
            var target = damageData.Target;
            AddBuff("JudicatorHolyFervorDebuff", 5f, 1, Spell, target, owner,false);

        }
        


 
        public void OnDeactivate(ObjAIBase owner, Spell spell)
        {
            ApiEventManager.OnHitUnit.RemoveListener(this);
        }
        public void OnUpdate(float diff)
        {
        }
    }
}