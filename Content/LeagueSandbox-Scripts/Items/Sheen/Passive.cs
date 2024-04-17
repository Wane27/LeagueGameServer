namespace ItemPassives
{
    public class ItemID_3057 : IItemScript
    {
        ObjAIBase Itemowner;
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(ObjAIBase owner)
        {
            Itemowner = owner as Champion;
            for (byte i = 0; i < 4; i++) { ApiEventManager.OnSpellCast.AddListener(this, Itemowner.Spells[i], BuffAdd, false); }
        }
        public void BuffAdd(Spell spell)
        {
            AddBuff("Sheen", 10.0f, 1, spell, Itemowner, Itemowner);
        }
        public void OnDeactivate(ObjAIBase owner)
        {
            ApiEventManager.OnSpellCast.RemoveListener(this);
        }
    }
}
