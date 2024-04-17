namespace Talents
{
    internal class Talent_4313 : ITalentScript
    {
        public void OnActivate(ObjAIBase owner, byte rank)
        {
            var manaRegen = new StatsModifier();
            manaRegen.ManaRegeneration.FlatBonus = 0.2f * rank;
            owner.AddStatModifier(manaRegen);
        }
    }
}
