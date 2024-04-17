namespace CharScripts
{
    public class CharScriptIrelia : ICharScript
    {
        Spell Passive;
        ObjAIBase Irelia;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Passive = spell;
            Irelia = owner as Champion;
            AddBuff("Voracity", 25000f, 1, Passive, Irelia, Irelia);
        }
    }
}
