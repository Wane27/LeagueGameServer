namespace Spells
{
    public class BrandBasicAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            ApiEventManager.OnLaunchAttack.AddListener(this, owner, OnLaunchAttack, true);
        }
        public void OnLaunchAttack(Spell spell)
        {
            spell.CastInfo.Owner.SetAutoAttackSpell("BrandBasicAttack", false);
        }
    }
    public class BrandBasicAttack2 : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            ApiEventManager.OnLaunchAttack.AddListener(this, owner, OnLaunchAttack, true);
        }
        public void OnLaunchAttack(Spell spell)
        {
            spell.CastInfo.Owner.SetAutoAttackSpell("BrandBasicAttack2", false);
        }
    }
    public class BrandCritAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            ApiEventManager.OnLaunchAttack.AddListener(this, owner, OnLaunchAttack, true);
        }
        public void OnLaunchAttack(Spell spell)
        {
            spell.CastInfo.Owner.SetAutoAttackSpell("BrandCritAttack", false);
        }
    }
    public class BrandScorchAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            ApiEventManager.OnLaunchAttack.AddListener(this, owner, OnLaunchAttack, true);
        }
        public void OnLaunchAttack(Spell spell)
        {
            spell.CastInfo.Owner.SetAutoAttackSpell("BrandScorchAttack", false);
        }
    }
}