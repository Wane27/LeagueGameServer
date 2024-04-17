namespace CharScripts
{
    public class CharScriptRiven : ICharScript
    {
        ObjAIBase Riven;
        AttackableUnit Target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Riven = owner as Champion;
            for (byte i = 0; i < 4; i++)
            {
                ApiEventManager.OnSpellCast.AddListener(this, Riven.Spells[i], AddPassiveBuff);
            }
        }
        public void AddPassiveBuff(Spell spell)
        {
            AddBuff("RivenPassiveAABoost", 6f, 1, spell, Riven, Riven);
        }
    }
}
