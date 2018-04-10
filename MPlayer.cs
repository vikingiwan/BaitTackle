using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace BaitTackle
{
    public class MPlayer : ModPlayer
    {


        //Pet Stuff
        public bool lamiaPet = false;

        public override void ResetEffects()
        {
            lamiaPet = false;
        }



        //Fish stuff

        int miscFishChance = 5;

        // Multiple lure stuff
        // <----------------
        private const string LURE_COUNT = "lurecount";
        private byte lureCount = 1;
        public bool uberBoxEquipped = false;

        public override void PostUpdateEquips()
        {


            MPlayer mp = player.GetModPlayer<MPlayer>(mod);

            for (int k = 0; k < player.armor.Length; k++)
            {
                if (player.armor[k].type == mod.ItemType("UberTackleBox"))
                {

                    uberBoxEquipped = true;
                    break;
                }
                else uberBoxEquipped = false;
            }

            if (uberBoxEquipped)
            {
                mp.lureCount = 5;
            }
            
            if (!uberBoxEquipped)
            {
                mp.lureCount = 1;
            }

        }



        public byte LureCount
        {
            get { return lureCount; }
            set
            {
                lureCount = value;
            }
        }

        public override bool Autoload(ref string name)
        {
            return true;
        }

        public override TagCompound Save()
        {
            return new TagCompound {
                { LURE_COUNT, lureCount }
            };
        }

        public override void Load(TagCompound tag)
        {
            lureCount = tag.GetByte(LURE_COUNT);
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            try
            {
                lureCount = reader.ReadByte();
            }
            catch (EndOfStreamException)
            {
                lureCount = 1;
            }
        }
        // ---------------->


        //Custom Fishing stuff

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (junk)
            {
                return;
            }

            // CONDITIONS FOR REFERENCE:
            // player.ZoneBeach --> if a biome is required
            // player.FindBuffIndex(BuffID.BabySlime) > -1 --> If a buff is required
            // Main.dayTime --> Daytime requried
            // !Main.dayTime --> Nighttime requried
            // questFish == mod.ItemType("CustomFishingQuest") --> If a quest is requried
            // Main.rand.Next(100) <= 10 --> replace 10 with percent chance to catch


            //CrimsonSeahorse Quest
            if (player.ZoneCrimson && liquidType == 0 && questFish == mod.ItemType("CrimsonSeahorse") && Main.rand.Next(1) == 0)   
            {
                caughtType = mod.ItemType("CrimsonSeahorse"); // Fish/Item to give
            }

            //WunderFisch
            if (liquidType == 0 && player.ZoneBeach && NPC.downedMoonlord && Main.rand.Next(100) <= 3)
            {
                caughtType = mod.ItemType("WunderFisch");
            }

            // Honey Fish
            if (liquidType == 2)
            {
                if (Main.rand.Next(100) <= 10)
                {
                    caughtType = mod.ItemType("HornetFish");
                }
            }

            // Misc Fish
            if (liquidType == 0)
            {
                if (Main.rand.Next(100) <= miscFishChance)
                {
                    caughtType = mod.ItemType("JadeFish");
                }
                else if (Main.rand.Next(100) <= miscFishChance)
                {
                    caughtType = mod.ItemType("RegalTang");
                }
                else if (Main.rand.Next(100) <= miscFishChance)
                {
                    caughtType = mod.ItemType("LiamFish");
                }
                else if (Main.rand.Next(100) <= miscFishChance)
                {
                    caughtType = mod.ItemType("FaulFisch");
                }
            }

            //Misc Ocean Fish
            if (liquidType == 0 && player.ZoneBeach)
            {
                if (Main.rand.Next(100) <= miscFishChance)
                {
                    caughtType = mod.ItemType("RoxxyFish");
                }
            }
        }

    }
}
