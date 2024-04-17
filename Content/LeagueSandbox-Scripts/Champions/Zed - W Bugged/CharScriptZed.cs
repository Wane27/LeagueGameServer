namespace CharScripts
{
    public class CharScriptZed : ICharScript
    {
        ObjAIBase Zed;
        AttackableUnit Target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Zed = owner as Champion;
            ApiEventManager.OnLaunchAttack.AddListener(this, Zed, OnLaunchAttack, false);
        }
        public void OnLaunchAttack(Spell spell)
        {
            Target = Zed.TargetUnit;
            if (Target.Stats.HealthPoints.Total * 0.5f >= Target.Stats.CurrentHealth && !Target.HasBuff("ZedPassiveToolTip") && Target.Team != Zed.Team && !(Target is ObjBuilding || Target is BaseTurret))
            {
                AddBuff("ZedPassiveToolTip", 10f, 1, spell, Target, Zed);
            }
        }
    }
}
