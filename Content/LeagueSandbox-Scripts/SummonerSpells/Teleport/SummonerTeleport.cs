/*namespace Spells
{
    public class SummonerTeleport : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true
        };
        public void OnStartCasting(Champion owner, Spell spell, AttackableUnit target)
        {
            var p101 = AddParticleTarget(owner, "Summoner_Teleport_purple.troy", owner);
            var p102 = AddParticleTarget(owner, "teleport.troy", owner);
            var p103 = AddParticleTarget(owner, "Teleport_target.troy", target);
            var p104 = AddParticleTarget(owner, "Scroll_Teleport.troy", target);
            owner.StopChampionMovement();
            CreateTimer(3.5f, () =>
            {
                var p201 = AddParticleTarget(owner, "Summoner_TeleportArrive_purple.troy", owner);
                var p202 = AddParticleTarget(owner, "teleportarrive.troy", owner);
                var p203 = AddParticleTarget(owner, "scroll_teleportarrive.troy", owner);
            });
        }
        public void OnFinishCasting(Champion owner, Spell spell, AttackableUnit target)
        {
            CreateTimer(4f, () =>
            {
                owner.TeleportTo(target.X, target.Y);
            });
        }
    }

}*/
namespace Spells
{
    public class SummonerTeleport : ISpellScript
    {
        private ObjAIBase Owner;
        private AttackableUnit Target;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            CastingBreaksStealth = false,
            ChannelDuration = 4.0f,
            TriggersSpellCasts = true,
            NotSingleTargetSpell = false
        };

        public void OnSpellChannel(Spell spell)
        {
            Target = spell.CastInfo.Targets[0].Unit;
            Owner = spell.CastInfo.Owner as Champion;
            var p101 = AddParticleTarget(Owner, Owner, "Summoner_Teleport_purple.troy", Owner);
            var p102 = AddParticleTarget(Owner, Owner, "teleport.troy", Owner);
            var p103 = AddParticleTarget(Owner, Target, "Teleport_target.troy", Target);
            var p104 = AddParticleTarget(Owner, Target, "Scroll_Teleport.troy", Target);
        }

        public void OnSpellChannelCancel(Spell spell, ChannelingStopSource reason)
        {
        }

        public void OnSpellPostChannel(Spell spell)
        {
            Target = spell.CastInfo.Targets[0].Unit;
            Owner = spell.CastInfo.Owner as Champion;
            TeleportTo(Owner, Target.Position.X, Target.Position.Y);
            AddParticleTarget(Owner, Owner, "TeleportArrive", Owner, flags: 0);
            var p201 = AddParticleTarget(Owner, Owner, "Summoner_TeleportArrive_purple.troy", Owner);
            var p202 = AddParticleTarget(Owner, Owner, "teleportarrive.troy", Owner);
            var p203 = AddParticleTarget(Owner, Owner, "scroll_teleportarrive.troy", Owner);
        }
    }
}
