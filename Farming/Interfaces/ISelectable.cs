namespace Farming
{
    interface ISelectable
    {
        bool IsHovered { get; set; }
        void Select();
        void Deselect();
    }
}
