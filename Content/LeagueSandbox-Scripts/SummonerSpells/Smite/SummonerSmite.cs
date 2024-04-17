namespace Spells
{
    public class SummonerSmite : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            // TODO
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            AddParticleTarget(owner, target, "Global_SS_Smite", target);
            var damage = new float[] {390, 410, 430, 450, 480, 510, 540, 570, 600, 640, 680, 420,
                760, 800, 850, 900, 950, 1000}[owner.Stats.Level - 1];
            target.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_TRUE, DamageSource.DAMAGE_SOURCE_SPELL, false);
        }
    }
}

