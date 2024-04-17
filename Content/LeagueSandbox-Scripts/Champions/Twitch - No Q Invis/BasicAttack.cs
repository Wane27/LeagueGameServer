namespace Spells
{
    public class TwitchBasicAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            IsDamagingSpell = true,
            TriggersSpellCasts = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("TwitchFullAutomatic"))
            {
                OverrideAnimation(owner, "Spell4", "Attack1");
            }
            else
            {
                OverrideAnimation(owner, "Attack1", "Spell4");
            }
        }
    }
    public class TwitchBasicAttack2 : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            IsDamagingSpell = true,
            TriggersSpellCasts = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            owner.SetAutoAttackSpell("TwitchBasicAttack", false);
            OverrideAnimation(owner, "Attack1", "Attack2");
            if (owner.HasBuff("TwitchFullAutomatic"))
            {
                OverrideAnimation(owner, "Spell4", "Attack2");
            }
            else
            {
                OverrideAnimation(owner, "Attack2", "Spell4");
            }
        }
    }
    public class TwitchBasicAttack3 : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            IsDamagingSpell = true,
            TriggersSpellCasts = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            owner.SetAutoAttackSpell("TwitchBasicAttack", false);
            OverrideAnimation(owner, "Attack1", "Attack3");
            if (owner.HasBuff("TwitchFullAutomatic"))
            {
                OverrideAnimation(owner, "Spell4", "Attack3");
            }
            else
            {
                OverrideAnimation(owner, "Attack3", "Spell4");
            }
        }
    }
    public class TwitchCritAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            IsDamagingSpell = true,
            TriggersSpellCasts = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("TwitchFullAutomatic"))
            {
                OverrideAnimation(owner, "Spell4", "Crit");
            }
            else
            {
                OverrideAnimation(owner, "Crit", "Spell4");
            }
        }
    }
}
