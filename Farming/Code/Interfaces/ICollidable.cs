using Microsoft.Xna.Framework;

namespace Farming
{
    interface ICollidable
    {
        Rectangle BoundingBox { get; }
    }
}
