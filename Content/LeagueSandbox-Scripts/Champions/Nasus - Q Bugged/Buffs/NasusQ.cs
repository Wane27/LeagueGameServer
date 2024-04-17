namespace Buffs
{
    internal class NasusQ : IBuffGameScript
    {
        Particle Buf;
        Buff AttackBuff;
        ObjAIBase Nasus;
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
            Nasus = ownerSpell.CastInfo.Owner as Champion;
            Nasus.SkipNextAutoAttack();
            Nasus.CancelAutoAttack(false, true);
            StatsModifier.Range.FlatBonus = 50.0f;
            Nasus.AddStatModifier(StatsModifier);
            ApiEventManager.OnPreAttack.AddListener(this, Nasus, OnPreAttack, false);
            ApiEventManager.OnLaunchAttack.AddListener(this, Nasus, OnLaunchAttack, false);
            SealSpellSlot(Nasus, SpellSlotType.SpellSlots, 0, SpellbookType.SPELLBOOK_CHAMPION, true);
            Buf = AddParticleTarget(Nasus, Nasus, "Nasus_Base_Q_Buf.troy", Nasus, buff.Duration, 1, "BUFFBONE_CSTM_WEAPON_1");
        }
        public void OnPreAttack(Spell spell)
        {
            if (AttackBuff != null && AttackBuff.StackCount != 0 && !AttackBuff.Elapsed())
            {
                //PlaySound("Play_vo_Talon_TalonNoxianDiplomacyAttack_OnCast", Talon);
            }
        }

        public void OnLaunchAttack(Spell spell)
        {
            if (AttackBuff != null && AttackBuff.StackCount != 0 && !AttackBuff.Elapsed())
            {
                Nasus.SkipNextAutoAttack();
                SpellCast(Nasus, 0, SpellSlotType.ExtraSlots, false, Nasus.TargetUnit, Vector2.Zero);
                AttackBuff.DeactivateBuff();
            }
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(Buf);
            if (buff.TimeElapsed >= buff.Duration)
            {
                ApiEventManager.OnPreAttack.RemoveListener(this);
                ApiEventManager.OnLaunchAttack.RemoveListener(this);
            }
            SealSpellSlot(Nasus, SpellSlotType.SpellSlots, 0, SpellbookType.SPELLBOOK_CHAMPION, false);
            TrueCooldown = (9 - Nasus.Spells[0].CastInfo.SpellLevel) * (1 + Nasus.Stats.CooldownReduction.Total);
            Nasus.Spells[0].SetCooldown(TrueCooldown, true);
        }
    }
}
