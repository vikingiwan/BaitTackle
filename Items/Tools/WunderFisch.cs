using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BaitTackle.Items.Tools
{
    class WunderFisch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("WunderFisch");
            Tooltip.SetDefault("The only tool you'll need!"
                +"\n" + "*DISCLAIMER: Not actually edible");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.AdamantitePickaxe);

            item.width = 50;
            item.height = 56;
            item.maxStack = 1;
            item.useTime = 1;
            item.rare = -12;
            item.autoReuse = true;

            //Tool Powers
            item.pick = 250;
            item.axe = 250;
            item.hammer = 250;
        }
    }
}
