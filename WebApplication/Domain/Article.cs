namespace Domain
{
    public class Article : Entity
    {
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public Article()
        {
            
        }

        public Article(string name, string ingredients, double price)
        {
            Name = name;
            Ingredients = ingredients;
            Price = price;
        }
    }
}