using Unity.Entities;
using Unity.Transforms;

public struct CircleMoveComponent : IComponentData
{
    public float Speed;
    public float Radius;
}
