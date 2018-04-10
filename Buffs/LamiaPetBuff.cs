using Terraria;
using Terraria.ModLoader;

namespace BaitTackle.Buffs
{
    class LamiaPetBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lamia Princess");
            Description.SetDefault("\"The Royal Lamia Princess has chosen you!\"");


            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;                             // Sets the buff time to cover 24hours?
            player.GetModPlayer<MPlayer>(mod).lamiaPet = true;    // Sets the pet to true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("LamiaPet")] <= 0; // Sets to true if count is less than or equal to 0
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("LamiaPet"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}
