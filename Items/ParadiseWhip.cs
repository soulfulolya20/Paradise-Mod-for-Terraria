using Terraria.ModLoader;
using ParadiseMod.Buffs;
using Terraria.Localization;
using Terraria.ID;
using ParadiseMod.Projectiles;
using Terraria;


namespace ParadiseMod.Items;

public class ParadiseWhip: ModItem
{
    public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(WhipDebuff.TagDamage);
    
    public override void SetDefaults() {
        // This method quickly sets the whip's properties.
        // Mouse over to see its parameters.
        Item.DefaultToWhip(ModContent.ProjectileType<WhipProjectile>(), 20, 2, 4);
        Item.rare = ItemRarityID.Green;
        // Item.channel = true;
    }
    
    public override void AddRecipes() {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.DirtBlock, 10);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }

    // Makes the whip receive melee prefixes
    public override bool MeleePrefix() {
        return true;
    }
}