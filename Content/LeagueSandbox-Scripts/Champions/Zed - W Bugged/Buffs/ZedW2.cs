namespace Buffs
{
    public class ZedW2 : IBuffGameScript
    {
        ObjAIBase Zed;
        ZedWHandler Handler;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Zed = ownerSpell.CastInfo.Owner as Champion;
            Zed.SetSpell("ZedW2", 1, true, true);
            Handler = Zed.GetBuffWithName("ZedWHandler").BuffScript as ZedWHandler;
            ApiEventManager.OnSpellCast.AddListener(this, Zed.Spells[1], Handler.ShadowSwap);
        }

        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            if (!Handler.QueueSwap)
            {
                Zed.RemoveBuffsWithName("ZedWHandler");
            }
            Zed.SetSpell("ZedShadowDash", 1, true, true);
        }
    }
}
