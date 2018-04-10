using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace BaitTackle.NPCs
{
    class Lamia : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lamia Princess");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.Zombie);
            npc.width = 90;
            npc.height = 90;
            npc.damage = 50;
            npc.defense = 10;
            npc.lifeMax = 5000;
            npc.knockBackResist = 0.75f;
            aiType = NPCID.Zombie; // aiType = 3;
            animationType = NPCID.Zombie; // animationType = 3;
            banner = npc.type;
            bannerItem = mod.ItemType("LamiaBanner");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode == true)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.30f;
            }
            else
            {
                return 0f;
            }
        }

        public override void NPCLoot()
        {
            //5% chance
            if (Main.rand.Next(100) <= 5)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("RoxxyFish"), 1);
            }
        }
    }
}
