namespace Spells
{
    public class SummonerExhaust : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            // TODO
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (target != null)
            {
                AddParticleTarget(owner, target, "Global_SS_Exhaust", target);
                AddBuff("SummonerExhaustDebuff", 2.5f, 1, spell, target, owner);
            }
        }
    }
}

