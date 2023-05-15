using Microsoft.EntityFrameworkCore;
using PetShopApp.Models;

namespace PetShopApp.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options) { }


        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new
                {
                    Id = 1,
                    Name = "Horse",
                    Age = 6,
                    PhotoUrl = "Horse.png",
                    Description = "Horses have oval-shaped hooves," +
                    " long tails, short hair, long slender legs, muscular and deep torso build," +
                    " long thick necks, and large elongated heads. The mane is a region of coarse hairs," +
                    " which extends along the dorsal side of the neck in both domestic and wild species."
                ,
                    CategoryId = 1
                },
                new
                {
                    Id = 2,
                    Name = "Snake",
                    Age = 10,
                    PhotoUrl = "Snake.png",
                    Description = "snake, Any member" +
                    " of about 19 reptile families (suborder Serpentes, order Squamata) that has no limbs," +
                    " voice, external ears, or eyelids, only one functional lung, and a long, slender body." +
                    " About 2,900 snake species are known to exist, most living in the tropics. Their skin is" +
                    " covered with scales.",
                    CategoryId = 2
                },
                new
                {
                    Id = 3,
                    Name = "Eagle",
                    Age = 7,
                    PhotoUrl = "Eagle.png",
                    Description = "In general, an eagle is any bird of " +
                    "prey more powerful than a buteo. An eagle may resemble a vulture in build and flight" +
                    "characteristics but has a fully feathered (often crested) head and strong feet equipped" +
                    "with great curved talons." +
                    " further difference is in foraging habits: eagles subsist mainly on live prey.",
                    CategoryId = 3
                },
                 new
                 {
                     Id = 4,
                     Name = "Salamandra",
                     Age = 5,
                     PhotoUrl = "Salamandra.png",
                     Description = "This is the largest fire salamander species" +
                     " it can reach a length of 324 mm. The females are usually larger than males." +
                     " This species has no coloration on the belly, the underside is completely black." +
                     " View distribution map in BerkeleyMapper.",
                     CategoryId = 4
                 },
                  new
                  {
                      Id = 5,
                      Name = "Snail",
                      Age = 1,
                      PhotoUrl = "Snail.png",
                      Description = "A snail is, in loose terms, a shelled gastropod. The name is most " +
                      "often applied to land snails, terrestrial pulmonate gastropod molluscs.",
                      CategoryId = 5
                  });

            modelBuilder.Entity<Comment>().HasData(
                new { Id = 1, AnimalId = 1, CommentText = "Best animal in the world" },
                new { Id = 2, AnimalId = 1, CommentText = "I love horses!" },
                new { Id = 3, AnimalId = 2, CommentText = "My first pet" },
                new { Id = 4, AnimalId = 2, CommentText = "I'm going from here" },
                new { Id = 5, AnimalId = 3, CommentText = "The strongest bird in the sky" },
                new { Id = 6, AnimalId = 3, CommentText = "Inspiring pride" },
                new { Id = 7, AnimalId = 4, CommentText = "Cool!!!" },
                new { Id = 8, AnimalId = 4, CommentText = "Woww" },
                new { Id = 9, AnimalId = 4, CommentText = "The world in its glory" },
                new { Id = 10, AnimalId = 5, CommentText = "Very interesting" },
                new { Id = 11, AnimalId = 5, CommentText = "Very beautiful" },
                new { Id = 12, AnimalId = 5, CommentText = "I'm excited" }
                );

            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Mammals" },
                new { Id = 2, Name = "Reptiles" },
                new { Id = 3, Name = "Birds" },
                new { Id = 4, Name = "Amphibians" },
                new { Id = 5, Name = "Shellfish" });
        }
    }
}
