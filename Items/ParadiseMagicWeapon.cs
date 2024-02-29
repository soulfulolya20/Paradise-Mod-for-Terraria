using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using ParadiseMod.Projectiles;

namespace ParadiseMod.Items;

public class ParadiseMagicWeapon : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 30;
        Item.useStyle = ItemUseStyleID.Shoot;

        Item.DamageType = DamageClass.Magic;
        Item.noMelee = true;
        Item.mana = 9;
        Item.damage = 24;
        Item.knockBack = 5f;

        Item.useTime = 20;
        Item.useAnimation = 15;

        Item.UseSound = SoundID.Item71;

        Item.shoot = ModContent.ProjectileType<ParadiseMagicWeaponProjectile>();
        Item.shootSpeed = 1f;
    }
    
    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.DirtBlock, 10);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}