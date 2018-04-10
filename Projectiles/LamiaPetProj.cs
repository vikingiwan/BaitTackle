using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BaitTackle.Projectiles
{
    class LamiaPetProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Turtle);

            projectile.height = 90;
            projectile.width = 90;

            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
            aiType = ProjectileID.Bunny;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.turtle = false; // Sets the default cloned pet to false;
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            MPlayer modPlayer = player.GetModPlayer<MPlayer>(mod);
            if (player.dead)
            {
                modPlayer.lamiaPet = false;
            }
            if (modPlayer.lamiaPet)
            {
                projectile.timeLeft = 2; // Remain at 2 while tutorialPet == true;
            }
        }
    }
}
