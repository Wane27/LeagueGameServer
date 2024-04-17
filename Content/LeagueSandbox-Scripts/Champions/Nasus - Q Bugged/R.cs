namespace Spells
{
    public class NasusR : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata()
        {
            // TODO
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            AddBuff("NasusR", 15f, 1, spell, owner, owner);
            AddParticleTarget(owner, owner, "Nasus_Base_R_Aura.troy", owner, 15f);
        }
    }
}