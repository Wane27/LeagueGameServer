namespace CharScripts
{
    public class CharScriptCaitlyn : ICharScript
    {
        ObjAIBase Caitlyn;
        AttackableUnit Target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Caitlyn = owner as Champion;
            //AddBuff("CaitlynHeadshotpassive", 25000.0f, 1, Spell, owner, owner);;
        }
    }
}
