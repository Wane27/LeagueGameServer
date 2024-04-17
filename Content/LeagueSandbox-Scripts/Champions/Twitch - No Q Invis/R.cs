namespace Spells
{
    public class TwitchFullAutomatic : ISpellScript
    {
        ObjAIBase Twitch;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnSpellCast(Spell spell)
        {
            Twitch = spell.CastInfo.Owner as Champion;
            Twitch.CancelAutoAttack(true);
            AddBuff("TwitchFullAutomatic", Twitch.Spells[0].CastInfo.SpellLevel + 9f, 1, spell, Twitch, Twitch);
        }
    }
    public class TwitchSprayandPrayAttack : ISpellScript
    {
        ObjAIBase Twitch;
        SpellMissile Missile;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            Twitch = spell.CastInfo.Owner as Champion;
            Missile = spell.CreateSpellMissile(new MissileParameters
            {
                Type = MissileType.Circle,
            });
            ApiEventManager.OnSpellMissileHit.AddListener(this, Missile, TargetExecute, false);
        }
        public void TargetExecute(SpellMissile missile, AttackableUnit target)
        {
            if (Twitch.IsNextAutoCrit)
            {
                target.TakeDamage(Twitch, Twitch.Stats.AttackDamage.Total * 2, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_ATTACK, true);
            }
            else
            {
                target.TakeDamage(Twitch, Twitch.Stats.AttackDamage.Total, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
            }
            AddParticleTarget(Twitch, target, "Twitch_Base_R_Tar.troy", target);
        }
    }
}
