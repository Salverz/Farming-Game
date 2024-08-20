namespace Farming
{
    interface IPlant
    {
        public int PricePerUnit { get; }
        public bool IsFullyGrown { get; }

        public void Grow();
        public void Draw();
    }
}
