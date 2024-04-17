namespace Buffs
{
    internal class TalonNoxianDiplomacyBuff : IBuffGameScript
    {
        Buff AttackBuff;
        ObjAIBase Talon;
        float TrueCooldown;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };


        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            AttackBuff = buff;
            Talon = ownerSpell.CastInfo.Owner as Champion;
            Talon.SkipNextAutoAttack();
            Talon.CancelAutoAttack(false, true);
            StatsModifier.Range.FlatBonus = 50.0f;
            Talon.AddStatModifier(StatsModifier);
            ApiEventManager.OnPreAttack.AddListener(this, Talon, OnPreAttack, false);
            ApiEventManager.OnLaunchAttack.AddListener(this, Talon, OnLaunchAttack, false);
            SealSpellSlot(Talon, SpellSlotType.SpellSlots, 0, SpellbookType.SPELLBOOK_CHAMPION, true);
        }
        public void OnPreAttack(Spell spell)
        {
            if (AttackBuff != null && AttackBuff.StackCount != 0 && !AttackBuff.Elapsed())
            {
                PlaySound("Play_vo_Talon_TalonNoxianDiplomacyAttack_OnCast", Talon);
            }
        }

        public void OnLaunchAttack(Spell spell)
        {
            if (AttackBuff != null && AttackBuff.StackCount != 0 && !AttackBuff.Elapsed())
            {
                Talon.SkipNextAutoAttack();
                SpellCast(Talon, 0, SpellSlotType.ExtraSlots, false, Talon.TargetUnit, Vector2.Zero);
                AttackBuff.DeactivateBuff();
            }
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            if (buff.TimeElapsed >= buff.Duration)
            {
                ApiEventManager.OnPreAttack.RemoveListener(this);
                ApiEventManager.OnLaunchAttack.RemoveListener(this);
            }
            SealSpellSlot(Talon, SpellSlotType.SpellSlots, 0, SpellbookType.SPELLBOOK_CHAMPION, false);
            TrueCooldown = (9 - Talon.Spells[0].CastInfo.SpellLevel) * (1 + Talon.Stats.CooldownReduction.Total);
            Talon.Spells[0].SetCooldown(TrueCooldown, true);
        }
    }
}
