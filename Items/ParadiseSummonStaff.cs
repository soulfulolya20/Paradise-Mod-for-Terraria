using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using ParadiseMod.Projectiles;
using ParadiseMod.Buffs;
using Terraria.DataStructures;

namespace ParadiseMod.Items;

public class ParadiseSummonStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
        ItemID.Sets.GamepadWholeScreenUseRange[Type] = true;
        ItemID.Sets.LockOnIgnoresCollision[Type] = true;
    }

    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 30;
        Item.scale = 0.4f;

        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item44;

        Item.DamageType = DamageClass.Summon;
        Item.damage = 30;
        Item.knockBack = 2f;
        Item.mana = 10;
        Item.noMelee = true;

        Item.value = Item.buyPrice(gold: 1);

        Item.shoot = ModContent.ProjectileType<ParadiseMinion>();
        Item.buffType = ModContent.BuffType<ParadiseMinionBuff>();
    }

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage,
        ref float knockback)
    {
        position = Main.MouseWorld;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type,
        int damage, float knockback)
    {
        player.AddBuff(Item.buffType, 2);

        var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, Main.myPlayer);

        projectile.originalDamage = Item.damage;

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