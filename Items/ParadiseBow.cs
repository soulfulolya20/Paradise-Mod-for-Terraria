using Microsoft.Xna.Framework;
using ParadiseMod.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ParadiseMod.Items;

public class ParadiseBow: ModItem
{
    
    public override void SetDefaults()
    {
        // useStyle = 5;
        // autoReuse = true;
        // useAnimation = 19;
        // useTime = 19;
        // width = 28;
        // height = 60;
        // shoot = 1;
        // useAmmo = AmmoID.Arrow;
        // UseSound = SoundID.Item5;
        // damage = 38;
        // shootSpeed = 12.5f;
        // noMelee = true;
        // value = sellPrice(0, 8);
        // ranged = true;
        // rare = 6;
        // knockBack = 2.25f;
        Item.damage = 40;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 30;
        Item.height = 80;
        Item.useTime = 32;
        Item.useAnimation = 32;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 3;
        Item.value = Item.sellPrice(platinum: 1, gold: 40);
        Item.rare = ItemRarityID.LightPurple; // редкость
        Item.UseSound = SoundID.Item5;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<ParadiseBowProjectile>();
        Item.useAmmo = AmmoID.Arrow;
        Item.shootSpeed = 8.25f;
    }
    
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
        float ceilingLimit = target.Y;
        if (ceilingLimit > player.Center.Y - 200f) {
            ceilingLimit = player.Center.Y - 200f;
        }
        // Loop these functions 3 times.
        for (int i = 0; i < 7; i++) {
            position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
            position.Y -= 100 * i;
            Vector2 heading = target - position;
    
            if (heading.Y < 0f) {
                heading.Y *= -1f;
            }
    
            if (heading.Y < 20f) {
                heading.Y = 20f;
            }
    
            heading.Normalize();
            heading *= velocity.Length();
            heading.Y += Main.rand.Next(-40, 41) * 0.02f;
            Projectile.NewProjectile(source, position, heading,  ModContent.ProjectileType<ParadiseBowProjectile>(), damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
        }
    
        return false;
    }
    
    
    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.DirtBlock, 10);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}