using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BaitTackle.Items
{
    class RoyalPungi : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Pungi");
            Tooltip.SetDefault("The sound of this instrument is said to even charm royalty");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Seaweed);
            item.height = 16;
            item.width = 16;
            item.rare = -12;
            item.shoot = mod.ProjectileType("LamiaPetProj");
            item.buffType = mod.BuffType("LamiaPetBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}
