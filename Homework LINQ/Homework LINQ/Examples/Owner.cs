using System;

namespace Lesson5.Examples
{
    /// <summary>
    /// Owner model
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Owner Id
        /// </summary>
        public Guid ID { get; private set; }
        
        /// <summary>
        /// Owner name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Create owner instance
        /// </summary>
        public Owner()
        {
            this.ID = Guid.NewGuid(); 
        }
    }
}
