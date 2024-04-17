namespace Spells
{
    public class SummonerMana : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            // TODO
        };

        private const float PERCENT_MAX_MANA_HEAL = 0.40f;

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            foreach (var unit in GetChampionsInRange(owner.Position, 600, true))
            {
                if (unit.Team == owner.Team)
                {
                    RestoreMana(owner);
                }
            }
        }

        private void RestoreMana(ObjAIBase target)
        {
            var maxMp = target.Stats.ManaPoints.Total;
            var newMp = target.Stats.CurrentMana + (maxMp * PERCENT_MAX_MANA_HEAL);
            target.Stats.CurrentMana = newMp < maxMp ? newMp : maxMp;
            AddParticleTarget(target, target, "global_ss_clarity_02", target);
        }
    }
}

