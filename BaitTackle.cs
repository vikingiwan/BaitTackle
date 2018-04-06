using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BaitTackle
{
    class BaitTackle : Mod
    {
        public BaitTackle()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load()
        {
            AddGlobalItem("MultiLureFishingPole", new GlobalFishingPoleItem());
        }

        private MPlayer GetModPlayer()
        {
            return Main.player[Main.myPlayer].GetModPlayer<MPlayer>(this);
        }
    }
}