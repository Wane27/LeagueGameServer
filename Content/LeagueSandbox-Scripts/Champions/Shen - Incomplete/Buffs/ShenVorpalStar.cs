namespace Buffs
{
    class ShenVorpalStar : IBuffGameScript
    {
        Spell Vorpal;
        ObjAIBase Shen;
        Buff VorpalStar;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_DEHANCER
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            VorpalStar = buff;
            Vorpal = ownerSpell;
            Shen = ownerSpell.CastInfo.Owner as Champion;
            ApiEventManager.OnTakeDamage.AddListener(this, unit, TakeDamage, false);
        }
        public void TakeDamage(DamageData damageData)
        {
            if (damageData.Attacker != Shen && damageData.Attacker.Team == Shen.Team)
            {
                VorpalStar.DeactivateBuff();
                AddBuff("ShenVorpalStarHeal", 3f, 1, Vorpal, damageData.Attacker, Shen);
            }
        }
    }
}
