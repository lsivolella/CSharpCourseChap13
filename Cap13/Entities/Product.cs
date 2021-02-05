namespace Cap13.Entities
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Units { get; set; }

        public Product(string name, double price, int units)
        {
            Name = name;
            Price = price;
            Units = units;
        }

        public double Total()
        {
            return Price * Units;
        }
    }
}
