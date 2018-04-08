using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BaitTackle.Items.Tools
{
    class UberFishHook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Über Fish Hook");
            Tooltip.SetDefault("A strange hook made from....Fish???");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.FishHook);
            item.shootSpeed = 30f; // how quickly the hook is shot.
            item.shoot = mod.ProjectileType("UberFishHookProj");
            item.rare = -12;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FishHook, 1);
            recipe.AddIngredient(mod.ItemType("TrueMasterBait"), 5);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
