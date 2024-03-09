using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace ParadiseMod.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class ParadiseBreastplate : ModItem
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

        Item.defense = 6;
    }

    public override void UpdateEquip(Player player)
    {
        
        // Increase Health or Mana
        player.statLifeMax2 += 20;
        player.statManaMax2 += 20;
        
        // Increase Max Minions
        player.maxMinions += 2;
    }
}