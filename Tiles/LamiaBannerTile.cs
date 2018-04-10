﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BaitTackle.Tiles
{
    class LamiaBannerTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("LamiaBanner"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)          //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("Lamia")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
}
