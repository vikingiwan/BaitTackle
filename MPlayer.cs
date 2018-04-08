using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace BaitTackle
{
    public class MPlayer : ModPlayer
    {

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

            //CrimsonSeahorse Quest
            if (player.ZoneCrimson && liquidType == 0 && questFish == mod.ItemType("CrimsonSeahorse") && Main.rand.Next(1) == 0)   // layer.ZoneBeach (is the zone required to catch the fish(zonebeach is the ocean biome))|||||||||| (player.FindBuffIndex(BuffID.BabySlime) > -1 defines the codition(example: if the player has that buff then you can catch that fish otherwise you can't)||||, the liquid where type where you can catch the fish (== 0 is water, 1 is lava, 2 is honey)||||, the time(if it's day or night to be able to catch the fish(Main.dayTime is day and !Main.dayTime is night))|||||, questFish == mod.ItemType("CustomFishingQuest") this tells the game that you need to have the customquestfish to be able to cath the fish||||, and  Main.rand.Next(1) == 0) is the chatch % chance to catch the customfish
            {
                caughtType = mod.ItemType("CrimsonSeahorse"); //what fish to catch under these conditions.
            }

            if (liquidType == 2 && Main.rand.Next(1) == 0)   //and this is an example of how to add a fish to be able to catch it witout the quest like the crates or other fishes|||| player.ZoneJungle (is the zone required to catch the fish(ZoneJungle is the jungle biome))|||||  (player.FindBuffIndex(BuffID.BabySlime) > -1 defines the codition(example: if the player has that buff then you can catch that fish otherwise you can't)||||, the liquid where type where you can catch the fish (== 0 is water, 1 is lava, 2 is honey)||||, the time(if it's day or night to be able to catch the fish(Main.dayTime is day and !Main.dayTime is night))||||||||, and  Main.rand.Next(1) == 0) is the chatch % chance to catch the customfish
            {
                caughtType = mod.ItemType("HornetFish"); //what fish/item to catch under these conditions.
            }
        }

    }
}
