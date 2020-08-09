using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson5.Examples
{
    /// <summary>
    /// LINQ Examples model
    /// </summary>
    public class LINQExamples
    {
        /// <summary>
        /// Run LINQ Examples
        /// </summary>
        public void Run()
        {
            // example of querying list of strings 
            this.QueryStringList();

            // example of querying collection
            this.QueryCollection();

            // example of querying animal data
            this.QueryAnimalData();
        }

        /// <summary>
        /// Query list of strings
        /// </summary>
        private void QueryStringList()
        {
            var dogs = new List<string>
            {
                "K 9", "Brian Griffin", "Scooby Doo",
                "Old Yeller", "Rin Tin Tin", "Benji",
                "Charlie B. Barkin", "Lassie", "Snoopy"
            };

            // Get strings with spaces and put in 
            // alphabetical order
            //var dogsWithSpaces = new List<string>();
            //foreach (var dog in dogs)
            //{
            //    if (dog.Contains(" "))
            //    {
            //        dogsWithSpaces.Add(dog);
            //    }
            //}

            //dogsWithSpaces.Sort();

            var dogsWithSpaces = from dog in dogs
                                 where dog.Contains(" ")
                                 orderby dog ascending
                                 select dog;
        }

        /// <summary>
        /// Query Animal collection
        /// </summary>
        private void QueryCollection()
        {
            var animalList = new List<Animal>()
            {
                new Animal
                {
                    Name = "German Shepherd",
                    Height = 25,
                    Weight = 77
                },
                new Animal
                {
                    Name = "Chihuahua",
                    Height = 7,
                    Weight = 4.4
                },
                new Animal
                {
                    Name = "Saint Bernard",
                    Height = 30,
                    Weight = 200
                }
            };

            // Get big dogs which weight is greater than 70 and height is greater than 20
            //var bigDogs = from animal in animalList
            //              where (animal.Weight > 70) && (animal.Height > 20)
            //              select animal;

            //animalList.Find(delegate (Animal animal) { return animal.ID == Guid.NewGuid(); });
            //animalList.Find(animal => { return animal.ID == Guid.NewGuid(); });

            var bigDogs = animalList.Where(animal => animal.Weight > 70 && animal.Height > 20).Select(animal => animal);
        }

        /// <summary>
        /// Query animal owner data
        /// </summary>
        private void QueryAnimalData()
        {
            // create owners
            var owners = new List<Owner>
            {
                new Owner
                {
                    Name = "Doug Parks"
                },
                new Owner
                {
                    Name = "Sally Smith",
                },
                new Owner
                {
                    Name = "Paul Brooks",
                }
            };

            // create animals
            var animals = new List<Animal>
            {
                new Animal
                {
                    Name = "German Shepherd",
                    Height = 25,
                    Weight = 77,
                    OwnerID = owners[0].ID
                },
                new Animal
                {
                    Name = "Chihuahua",
                    Height = 7,
                    Weight = 4.4,
                    OwnerID = owners[1].ID
                },
                new Animal
                {
                    Name = "Saint Bernard",
                    Height = 30,
                    Weight = 200,
                    OwnerID = owners[2].ID
                },
                new Animal
                {
                    Name = "Pug",
                    Height = 12,
                    Weight = 16,
                    OwnerID = owners[0].ID
                },
                new Animal
                {
                    Name = "Beagle",
                    Height = 15,
                    Weight = 23,
                    OwnerID = owners[2].ID
                }
            };


            // select animal name and height group
            var animalHeightGroup = from animal in animals
                                    select new
                                    {
                                        AnimalName = animal.Name,
                                        AnimalHeight = animal.Height
                                    };

            var animalHeightGroupList = animalHeightGroup.ToList();

            // Join info in owners and animals using
            // equal values for IDs
            // Store values for animal and owner
            var innerJoinOp1 = from animal in animals
                               join owner in owners on animal.OwnerID
                               equals owner.ID
                               select new { OwnerName = owner.Name, AnimalName = animal.Name };

            var innerJoinOp2 = animals.Join(owners, animal => animal.OwnerID, owner => owner.ID,
                (animal, owner) => new { OwnerName = owner.Name, AnimalName = animal.Name });

            // Get all animals and put them in a
            // newly created owner group if their
            // IDs match the owners ID 
            var groupJoinOp1 = from owner in owners
                               orderby owner.ID
                               join animal in animals on owner.ID
                               equals animal.OwnerID into ownerGroup
                               select new
                               {
                                   Owner = owner.Name,
                                   Animals = from owner1 in ownerGroup
                                             orderby owner1.Name
                                             select owner1
                               };

            var groupJoinOp2 = owners.OrderBy(o => o.ID).GroupJoin(animals, owner => owner.ID, animal => animal.OwnerID,
                (owner, animal) => new { Owner = owner.Name, Animals = animal.OrderBy(o => o.Name) });
        }
    }
}
