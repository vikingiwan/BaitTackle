using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace BaitTackle.Items.Accessories
{
    class UberTackleBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Über Tackle Box");

            Tooltip.SetDefault("Everything a Master Baiter could ever want!"
                + "\n" + "Fishing line never breaks"
                + "\n" + "Reduced chance to consume bait"
                + "\n" + "Increases fishing power by 50"
                + "\n" + "Use 5 lures instead of 1"
                + "\n" + "*Does not come with tissues or lotion*");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.HighTestFishingLine);
            item.width = 30;
            item.height = 34;
            item.accessory = true;
            item.rare = -12;
            item.value = Item.buyPrice(5, 0, 0, 0); //plat, gold, silver, copper
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //Fishing Line never breaks
            player.accFishingLine = true;
            //Decrease chance to consume bait
            player.accTackleBox = true;
            //Increase fishing skill by 50
            player.fishingSkill += 50;
            //Add sonar buff
            player.AddBuff(122, 1, true);
            //Add crate buff
            player.AddBuff(123, 1, true);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AnglerHat, 1);
            recipe.AddIngredient(ItemID.AnglerVest, 1);
            recipe.AddIngredient(ItemID.AnglerPants, 1);
            recipe.AddIngredient(ItemID.AnglerEarring, 1);
            recipe.AddIngredient(ItemID.HighTestFishingLine, 1);
            recipe.AddIngredient(ItemID.TackleBox, 1);
            recipe.AddIngredient(ItemID.GoldenFishingRod, 1);
            recipe.AddIngredient(ItemID.MasterBait, 5);
            recipe.AddIngredient(ItemID.SonarPotion, 5);
            recipe.AddIngredient(ItemID.CratePotion, 5);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ItemID.Diamond, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}