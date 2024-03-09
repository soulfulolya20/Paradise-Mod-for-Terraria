using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace ParadiseMod.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class ParadiseLeggings : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }
    
    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 18;

        Item.value = Item.buyPrice(gold: 1);
        Item.rare = ItemRarityID.Blue;

        Item.defense = 5;
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.07f;
    }
}