namespace Inventory.Model
{
    public class ItemDto
    {
        private const float GSTPercentage = 18;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category   { get; set; }
        public  float GSTPrice{ get; set; }

        public float Price
        {
            get { return Price; }
            set
            {
                Price = value;
                GSTPrice = value + (value / GSTPercentage);
            }
        }

       


    }
}
