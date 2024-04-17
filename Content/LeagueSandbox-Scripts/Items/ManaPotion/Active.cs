﻿namespace ItemSpells
{
    public class FlaskOfCrystalWater : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata()
        {
            // TODO
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            AddBuff("FlaskOfCrystalWater", 15.0f, 1, spell, owner, owner);
        }
    }
}
