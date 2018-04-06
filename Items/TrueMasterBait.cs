using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace BaitTackle.Items
{
    class TrueMasterBait : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Master Bait");

            Tooltip.SetDefault("Welcome to the Elite, Master"
                + "\n" + "Consumable");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 999;
            item.rare = -11;
            item.value = Item.buyPrice(0, 1, 50, 0); //plat, gold, silver, copper
            item.bait = 100;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MasterBait, 1);
            recipe.AddIngredient(ItemID.JourneymanBait, 1);
            recipe.AddIngredient(ItemID.ApprenticeBait, 1);
            recipe.AddIngredient(ItemID.EnchantedNightcrawler, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
