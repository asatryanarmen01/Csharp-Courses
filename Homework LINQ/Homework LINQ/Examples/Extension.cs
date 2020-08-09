using System.Collections.Generic;

namespace Lesson5.Examples
{
    public static class Extension
    {
        public delegate bool FindAnimal(Animal animal);

        public static bool FindAnimalFrom(this List<Animal> animals, FindAnimal findAnimal)
        {
            foreach (var a in animals)
            {
                if (findAnimal(a))
                {
                    return true;
                }
            }

            return false;
        }
        
    }
}
