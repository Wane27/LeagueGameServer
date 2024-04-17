namespace Spells
{
    public class DesperatePower : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = false,
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            owner.Spells[0].LowerCooldown((float)1.5);   //Q
            owner.Spells[1].LowerCooldown((float)1.5);   //W
            owner.Spells[2].LowerCooldown((float)1.5);   //E
            //owner.Spells[3].LowerCooldown((float)1.5);   //R
        }

        public void OnSpellCast(Spell spell)
        {
            var owner = spell.CastInfo.Owner as Champion;
            AddBuff("DesperatePower", 8.0f, 1, spell, owner, owner);
        }

       
    }
}
