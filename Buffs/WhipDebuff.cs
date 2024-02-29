using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ParadiseMod.Buffs
{

    public class WhipDebuff : ModBuff
    {
        public static readonly int TagDamage = 5;

        public override void SetStaticDefaults()
        {
            // This allows the debuff to be inflicted on NPCs that would otherwise be immune to all debuffs.
            // Other mods may check it for different purposes.
            BuffID.Sets.IsATagBuff[Type] = true;
        }
    }

    public class WhipAdvancedDebuff : ModBuff
    {
        public static readonly int TagDamagePercent = 30;
        public static readonly float TagDamageMultiplier = TagDamagePercent / 100f;

        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsATagBuff[Type] = true;
        }
    }

    public class WhipDebuffNPC : GlobalNPC
    {
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            // Если снаряд не относится к NPC или ловушке, выходим из метода
            if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
                return;

            // Если снаряд наносит урон и NPC не имеет дебафф "святой огонь", накладываем этот дебафф на NPC
            if (npc.HasBuff<HolyFireDebuff>())
                return;

            // Применяем дебафф "святой огонь" на NPC
            npc.AddBuff(ModContent.BuffType<HolyFireDebuff>(), 300); // Длительность дебаффа в тиках (300 тиков = 5 секунд)
        }
    }
}
