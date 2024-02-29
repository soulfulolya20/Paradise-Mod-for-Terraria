using Terraria;
using Terraria.ModLoader;
using ParadiseMod.Projectiles;

namespace ParadiseMod.Buffs;

public class ParadiseMinionBuff : ModBuff
{
    public override void SetStaticDefaults()
    {
        Main.buffNoSave[Type] = true;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<ParadiseMinion>()] > 0)
        {
            player.buffTime[buffIndex] = 18000;
            return;
        }
        
        player.DelBuff(buffIndex);
        buffIndex--;
    }
}