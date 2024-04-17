namespace CharScripts
{
    public class CharScriptDarius : ICharScript
    {
        ObjAIBase Darius;
        AttackableUnit Target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Darius = owner as Champion;
            ApiEventManager.OnLaunchAttack.AddListener(this, Darius, OnLaunchAttack, false);
        }
        public void OnLaunchAttack(Spell spell)
        {
            Target = spell.CastInfo.Targets[0].Unit;
            if (!(Target is ObjBuilding || Target is BaseTurret))
            {
                AddBuff("DariusHemo", 5.0f, 1, spell, Target, Darius);
            }
        }
    }
}
