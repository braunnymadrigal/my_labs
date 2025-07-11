namespace backend.Database
{
    public static class Database
    {
        public static Dictionary<string, (int, int)> drinks { get; set; }
        public static Dictionary<int, int> coins { get; set; }

        static Database()
        {
            drinks = new Dictionary<string, (int, int)>
            {
                { "coca cola", (10, 800) },
                { "pepsi", (8, 750) },
                { "fanta", (10, 950) },
                { "sprite", (15, 975) }
            };

            coins = new Dictionary<int, int>
            {
                { 25, 25 },
                { 50, 50 },
                { 100, 30 },
                { 500, 20 }
            };
        }
    }
}
