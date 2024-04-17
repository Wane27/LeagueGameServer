namespace ItemPassives
{
    public class ItemID_3022 : IItemScript
    {
		private ObjAIBase owner;
        private Spell spell;
		AttackableUnit Target;
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(ObjAIBase owner)
        {
			ApiEventManager.OnLaunchAttack.AddListener(this, owner, OnLaunchAttack, false);
        }
        public void OnLaunchAttack(Spell spell)        
        {
			var owner = spell.CastInfo.Owner;
            Target = spell.CastInfo.Targets[0].Unit;
			AddBuff("Frozen Mallet Slow", 3f, 1, spell, Target, owner);
        }    
        public void OnDeactivate(ObjAIBase owner)
        {
			ApiEventManager.OnLaunchAttack.RemoveListener(this);
        }
    }
}