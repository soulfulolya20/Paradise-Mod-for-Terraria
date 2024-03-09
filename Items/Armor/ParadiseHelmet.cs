using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace ParadiseMod.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class ParadiseHelmet : ModItem
{
    public static readonly int AdditiveGenericDamageBonus = 20;
    
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        
        //ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;
    }

    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 18;

        Item.value = Item.buyPrice(gold: 1);
        Item.rare = ItemRarityID.Blue;

        Item.defense = 5;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        bool bodyMatch = body.type == ModContent.ItemType<ParadiseBreastplate>();
        bool legsMatch = legs.type == ModContent.ItemType<ParadiseLeggings>();
        return bodyMatch && legsMatch;
    }
    
    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Melee) += AdditiveGenericDamageBonus / 100f; // Increase dealt damage for all weapon classes by 20%
        player.GetDamage(DamageClass.Ranged) += AdditiveGenericDamageBonus / 100f; // Increase dealt damage for all weapon classes by 20%
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = Language.GetTextValue("Mods.ParadiseMod.ItemSetBonus.ParadiseSet");
        
        player.moveSpeed += 0.10f;
        
        // Give Buff Immunity
        player.buffImmune[BuffID.Darkness] = true;
        player.buffImmune[BuffID.Poisoned] = true;
        player.buffImmune[BuffID.Slow] = true;

    }
}