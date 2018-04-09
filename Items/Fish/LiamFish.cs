using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BaitTackle.Items.Fish
{
    class LiamFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dikkerfisch");

            Tooltip.SetDefault("His name is Liam" 
                + "\n" + "He's a good fish");
        }

        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 42;
            item.maxStack = 999;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Sashimi, 1);
            recipe.AddRecipe();
        }
    }
}
