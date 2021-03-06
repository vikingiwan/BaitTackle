﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaitTackle.Projectiles
{
    class UberFishHookProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Über Fish Hook");
        }

        public override void SetDefaults()
        {
            /*	this.netImportant = true;
				this.name = "Gem Hook";
				this.width = 18;
				this.height = 18;
				this.aiStyle = 7;
				this.friendly = true;
				this.penetrate = -1;
				this.tileCollide = false;
				this.timeLeft *= 10;
			*/
            projectile.CloneDefaults(ProjectileID.FishHook);
        }

        // Use this hook for hooks that can have multiple hooks mid-flight: Dual Hook, Web Slinger, Fish Hook, Static Hook, Lunar Hook
        public override bool? CanUseGrapple(Player player)
        {
            int hooksOut = 0;
            for (int l = 0; l < 1000; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == projectile.type)
                {
                    hooksOut++;
                }
            }
            if (hooksOut > 6) // This hook can have 5 hooks out.
            {
                return false;
            }
            return true;
        }

        // Use this to kill oldest hook. For hooks that kill the oldest when shot, not when the newest latches on: Like SkeletronHand
        // You can also change the projectile like: Dual Hook, Lunar Hook
        //public override void UseGrapple(Player player, ref int type)
        //{
        //	int hooksOut = 0;
        //	int oldestHookIndex = -1;
        //	int oldestHookTimeLeft = 100000;
        //	for (int i = 0; i < 1000; i++)
        //	{
        //		if (Main.projectile[i].active && Main.projectile[i].owner == projectile.whoAmI && Main.projectile[i].type == projectile.type)
        //		{
        //			hooksOut++;
        //			if (Main.projectile[i].timeLeft < oldestHookTimeLeft)
        //			{
        //				oldestHookIndex = i;
        //				oldestHookTimeLeft = Main.projectile[i].timeLeft;
        //			}
        //		}
        //	}
        //	if (hooksOut > 1)
        //	{
        //		Main.projectile[oldestHookIndex].Kill();
        //	}
        //}

        // Amethyst Hook is 300, Static Hook is 600
        public override float GrappleRange()
        {
            return 800f;
        }

        public override void NumGrappleHooks(Player player, ref int numHooks)
        {
            numHooks = 5;
        }

        // default is 11, Lunar is 24
        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            speed = 30f;
        }

        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = 30;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 playerCenter = Main.player[projectile.owner].MountedCenter;
            Vector2 center = projectile.Center;
            Vector2 distToProj = playerCenter - projectile.Center;
            float projRotation = distToProj.ToRotation() - 1.57f;
            float distance = distToProj.Length();
            while (distance > 30f && !float.IsNaN(distance))
            {
                distToProj.Normalize();                 //get unit vector
                distToProj *= 24f;                      //speed = 24
                center += distToProj;                   //update draw position
                distToProj = playerCenter - center;    //update distance
                distance = distToProj.Length();
                Color drawColor = lightColor;

                //Draw chain
                spriteBatch.Draw(mod.GetTexture("Items/Tools/UberFishHookChain"), new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y),
                    new Rectangle(0, 0, Main.chain30Texture.Width, Main.chain30Texture.Height), drawColor, projRotation,
                    new Vector2(Main.chain30Texture.Width * 0.5f, Main.chain30Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}
