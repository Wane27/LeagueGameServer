namespace Buffs
{
    internal class XenZhaoBattleCryPassive : IBuffGameScript
    {
        ObjAIBase XinZhao;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.INTERNAL,
            BuffAddType = BuffAddType.STACKS_AND_RENEWS,
            MaxStacks = 3
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            XinZhao = ownerSpell.CastInfo.Owner as Champion;
            switch (buff.StackCount)
            {
                case 3:
                    AddParticleTarget(XinZhao, XinZhao, "xenZiou_heal_passive.troy", XinZhao);
                    XinZhao.Stats.CurrentHealth += 20 + (6 * XinZhao.Spells[1].CastInfo.SpellLevel) + (XinZhao.Stats.AbilityPower.Total * 0.7f);
                    buff.DeactivateBuff();
                    break;
            }
        }
    }
}
