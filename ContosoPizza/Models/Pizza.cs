namespace ContosoPizza.Models
{
    /// <summary>
    /// Simple Pizza
    /// </summary>
    public class Pizza
    {
        /// <summary>
        /// Unique Identifier (int) 
        /// for Pizza
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Name of the Pizza (string)
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// Is this Pizza Gluten Free
        /// (bool true --> yes)
        /// </summary>
        public bool IsGlutenFree { get; set; }
    
    } // end of class

} // end of namespace
