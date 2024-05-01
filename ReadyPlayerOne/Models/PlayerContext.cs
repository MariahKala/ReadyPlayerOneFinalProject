using Microsoft.EntityFrameworkCore;
using ReadyPlayerOne.Models;

//Adding Authorization
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ReadyPlayerOne.Models
{
    //Changed from DB Context to IdentityDbContext<User> 
    public class PlayerContext : IdentityDbContext<User>
    {
        public PlayerContext(DbContextOptions<PlayerContext> options)
           : base(options)
        { }
        //Main Player Class
        public DbSet<Player> Players { get; set; } = null!;
        //Adding Alignment
        public DbSet<Alignment> Alignments { get; set; } = null!;
        //Adding PlayerImage
        public DbSet<PlayerImage> PlayerImages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { //might need to add base.OnModelCreating(modelBuilder); See Ch4 Slide 46
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alignment>().HasData(
            // Good Alignments
            new Alignment { AlignmentID = "1", AlignmentType = "Lawful Good" },
            new Alignment { AlignmentID = "2", AlignmentType = "Neutral Good" },
            new Alignment { AlignmentID = "3", AlignmentType = "Chaotic Good" },

            // Neutral Alignments
            new Alignment { AlignmentID = "4", AlignmentType = "Lawful Neutral" },
            new Alignment { AlignmentID = "5", AlignmentType = "True Neutral" },
            new Alignment { AlignmentID = "6", AlignmentType = "Chaotic Neutral" },

            // Evil Alignments
            new Alignment { AlignmentID = "7", AlignmentType = "Lawful Evil" },
            new Alignment { AlignmentID = "8", AlignmentType = "Neutral Evil" },
            new Alignment { AlignmentID = "9", AlignmentType = "Chaotic Evil" }
          );

            //Seeding Data from Images
            modelBuilder.Entity<PlayerImage>().HasData(
            new PlayerImage { PlayerImageID = "1", Image = "BlondeElfMaleWarrior.jpg" },
            new PlayerImage { PlayerImageID = "2", Image = "BlondeWarlock.jpg" },
            new PlayerImage { PlayerImageID = "3", Image = "BlondeWitch.jpg" },
            new PlayerImage { PlayerImageID = "4", Image = "DarkHairedPriestess.jpg" },
            new PlayerImage { PlayerImageID = "5", Image = "ElfFemaleFighter.jpg" },
            new PlayerImage { PlayerImageID = "6", Image = "FemaleSamuraiWarrior.jpg" },
            new PlayerImage { PlayerImageID = "7", Image = "FemaleWarriorInSilverArmor.jpg" },
            new PlayerImage { PlayerImageID = "8", Image = "FemaleWaterCreature.jpg" },
            new PlayerImage { PlayerImageID = "9", Image = "GoldenArcher.jpg" },
            new PlayerImage { PlayerImageID = "10", Image = "GreenFairy.jpg" },
            new PlayerImage { PlayerImageID = "11", Image = "HumanBoyWithCloak.jpg" },
            new PlayerImage { PlayerImageID = "12", Image = "HumanFemaleKnight.jpg" },
            new PlayerImage { PlayerImageID = "13", Image = "HumanGirlWithCloak.jpg" },
            new PlayerImage { PlayerImageID = "14", Image = "HumanMaleDruid.jpg" },
            new PlayerImage { PlayerImageID = "15", Image = "MaleSeaCreature.jpg" },
            new PlayerImage { PlayerImageID = "16", Image = "MaleWarriorInSilverArmor.jpg" },
            new PlayerImage { PlayerImageID = "17", Image = "MaleWithFlowerCrown.jpg" },
            new PlayerImage { PlayerImageID = "18", Image = "ManWithSkullArmor.jpg" },
            new PlayerImage { PlayerImageID = "19", Image = "MermaidWithBlueHair.jpg" },
            new PlayerImage { PlayerImageID = "20", Image = "OlderManHuman.jpg" },
            new PlayerImage { PlayerImageID = "21", Image = "OlderManWarrior.jpg" },
            new PlayerImage { PlayerImageID = "22", Image = "OldWomanMage.jpg" },
            new PlayerImage { PlayerImageID = "23", Image = "OldWomanMage.jpg" },
            new PlayerImage { PlayerImageID = "24", Image = "WomanWithWhiteHair.jpg" },
            new PlayerImage { PlayerImageID = "25", Image = "YoungRogue.png" }
            );


            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    PlayerID = 1,
                    PlayerName = "Esther Ulrick",
                    Class = "Mage",
                    Health = "3",
                    Strength = "3",
                    Intelligence = "9",
                    Stamina = "3",
                    Stealth = "6",
                    Luck = "3",
                    AlignmentID = "3",
                    PlayerImageID = "24"
                },

                new Player
                {
                    PlayerID = 2,
                    PlayerName = "Rhiordan Tannick",
                    Class = "Warrior",
                    Health = "3"        ,
                    Strength = "3",
                    Intelligence = "3",
                    Stamina = "3",
                    Stealth = "3",
                    Luck = "3",
                    AlignmentID = "3",
                    PlayerImageID = "18"
                },
                new Player
                {
                    PlayerID = 3,
                    PlayerName = "Bevil Starling",
                    Class = "Rogue",
                    Health = "3",
                    Strength = "3",
                    Intelligence = "3",
                    Stamina = "3",
                    Stealth = "3",
                    Luck = "3",
                    AlignmentID = "3",
                    PlayerImageID = "25"

                }

        );


        }
    }
}
