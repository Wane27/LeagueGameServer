namespace CharScripts
{
    public class CharScriptXinZhao : ICharScript
    {
        Spell Passive;
        ObjAIBase XinZhao;
        AttackableUnit Target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Passive = spell;
            XinZhao = owner as Champion;
            ApiEventManager.OnHitUnit.AddListener(this, XinZhao, OnHitUnit, false);
        }
        public void OnHitUnit(DamageData damageData)
        {
            Target = damageData.Target;
            if (!(Target is ObjBuilding || Target is BaseTurret) && !XinZhao.HasBuff("XinZhaoPassive"))
            {
                AddBuff("XenZhaoPuncture", 3.0f, 1, Passive, Target, XinZhao);
            }
            if (!(Target is ObjBuilding || Target is BaseTurret) && Target.HasBuff("XenZhaoPuncture"))
            {
                AddBuff("XenZhaoPuncture", 3.0f, 1, Passive, Target, XinZhao);
            }
        }
    }
}
