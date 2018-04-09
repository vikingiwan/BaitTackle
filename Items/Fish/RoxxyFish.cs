using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BaitTackle.Items.Fish
{
    class RoxxyFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Roxxy");

            Tooltip.SetDefault(string.Format("[c/faff00: Princess of the Ocean]"));
        }

        public override void SetDefaults()
        {
            item.width = 33;
            item.height = 36;
            item.maxStack = 999;
            item.rare = 11;
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
