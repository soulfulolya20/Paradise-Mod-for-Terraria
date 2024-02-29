using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ParadiseMod.Buffs
{
    public class HolyFireDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true; // Указываем, что это дебафф
            Main.pvpBuff[Type] = true; // Разрешаем применение дебаффа в PvP
            Main.buffNoSave[Type] = true; // Запрещаем сохранение дебаффа в файле сохранения мира
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            // Применяем эффект дебаффа
            npc.lifeRegen -= 4; // Урон в секунду от дебаффа
            if (npc.lifeRegen > 0)
                npc.lifeRegen = 0; // Отрицательный урон

            // Уменьшаем длительность дебаффа
            if (npc.buffTime[buffIndex] % 60 == 0)
                npc.life -= 1; // Уменьшаем жизни NPC

            // Проигрываем звук горения (при желании)
            //Main.PlaySound(SoundID.Item45, npc.position);
        }
    }
}