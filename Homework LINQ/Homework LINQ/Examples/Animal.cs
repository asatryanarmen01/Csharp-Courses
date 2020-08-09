using System;

namespace Lesson5.Examples
{
    /// <summary>
    /// Animal model
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// Animal Id
        /// </summary>
        public Guid ID { get; private set; }

        /// <summary>
        /// Animal Owner Id
        /// </summary>
        public Guid OwnerID { get; set; }

        /// <summary>
        /// Animal name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Animal weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Animal height
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Create animal instance
        /// </summary>
        public Animal()
        {
            this.ID = Guid.NewGuid();
            this.Name = "No Name";
            this.Weight = 0;
            this.Height = 0;
        }

        /// <summary>
        /// Create animal instance
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public Animal(string name, double weight, double height = 0) : this()
        {
            this.Name = name;
            this.Weight = weight;
            this.Height = height;
        }

        /// <summary>
        /// Override ToString for Animal models
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Name} weighs {this.Weight}lbs and is {this.Height} inches tall";
        }
    }
}
