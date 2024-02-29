﻿
using ParadiseMod.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ParadiseMod.Items;

public class ParadiseSpear: ModItem
{
    public override void SetStaticDefaults() {
        ItemID.Sets.SkipsInitialUseSound[Item.type] = true; // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
        ItemID.Sets.Spears[Item.type] = true; // This allows the game to recognize our new item as a spear.
    }
    
    public override void SetDefaults()
    {
        Item.damage = 150; // урон
        Item.knockBack = 6.5f; // отбрасывание
        Item.noUseGraphic = true;
        Item.DamageType = DamageClass.Melee; // класс дамага в нашем случае ближний
        // Item.width = 40; // ширина в пикселях
        // Item.height = 40; // высота в пикселях
        Item.useTime = 18; // скорость 
        Item.useAnimation = 12; // ид анимации которую он будет юзать
        Item.useStyle = ItemUseStyleID.Shoot; // стиль битвы
        Item.knockBack = 45; // отбрасывание
        Item.value = Item.sellPrice(platinum: 1, gold: 40);
        Item.rare = ItemRarityID.LightPurple; // редкость
        Item.UseSound = SoundID.Item71; // какой звук при использование 
        Item.autoReuse = true; // автоатака
        Item.noMelee = true;
        
        Item.shootSpeed = 3.7f;
        Item.shoot = ModContent.ProjectileType<ParadiseSpearProjectile>(); // The projectile that is fired from this weapon
    }
    
    public override bool CanUseItem(Player player) {
        // Ensures no more than one spear can be thrown out, use this when using autoReuse
        return player.ownedProjectileCounts[Item.shoot] < 1;
    }
    
    public override bool? UseItem(Player player) {
        // Because we're skipping sound playback on use animation start, we have to play it ourselves whenever the item is actually used.
        if (!Main.dedServ && Item.UseSound.HasValue) {
            SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
        }

        return null;
    }
}