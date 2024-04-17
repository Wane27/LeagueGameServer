namespace CharScripts
{
    public class CharScriptLeblanc : ICharScript
    {
        ObjAIBase Leblanc;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Leblanc = owner as Champion;
            AddBuff("LeblancPassive", 25000f, 1, spell, Leblanc, Leblanc, true);
        }
    }
}
