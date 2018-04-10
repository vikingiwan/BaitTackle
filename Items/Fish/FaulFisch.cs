using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BaitTackle.Items.Fish
{
    class FaulFisch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Faulfish");

            Tooltip.SetDefault("Eww...");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 48;
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
