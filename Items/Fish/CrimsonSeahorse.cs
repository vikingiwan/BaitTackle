using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BaitTackle.Items.Fish
{
    class CrimsonSeahorse : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Seahorse");

            Tooltip.SetDefault("Quest Item");
        }

        public override void SetDefaults()
        {
            item.width = 33;
            item.height = 45;
            item.maxStack = 1;
            item.uniqueStack = true;
            item.rare = -11;
        }

        public override bool IsQuestFish()
        {
            return true;
        }

        public override bool IsAnglerQuestAvailable()
        {
            return NPC.downedBoss2;
        }

        public override void AnglerQuestChat(ref string description, ref string catchLocation)
        {
            description = "Sometimes I wish I could ride a horse through the sea....Oh wait, I can!" +"\n" + "Bring me a Crimson Seahorse to be my faithful steed!";
            catchLocation = "\n" + "(Caught in Crimson after Brain of Cthulhu or Eater of Worlds has been defeated)";
        }
    }
}
