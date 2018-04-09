using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BaitTackle.Items.Fish
{
    class RegalTang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Regal Tang");

            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 45;
            item.maxStack = 999;
            item.rare = 1;
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
