using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace BaitTackle
{
    public class MPlayer : ModPlayer
    {
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
                if (uberBoxEquipped)
                {

                    mp.lureCount = 5;
                }
                else
                {
                    mp.lureCount = 1;
                }
            }
        }


        public byte LureCount
        {
            get { return lureCount; }
            set
            {
                if (value < 1)
                {
                    lureCount = 1;
                }
                else if (value > 100)
                {
                    lureCount = 100;
                }
                else
                {
                    lureCount = value;
                }
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
    }
}
