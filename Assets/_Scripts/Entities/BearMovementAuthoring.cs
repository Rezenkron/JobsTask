using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class BearMovementAuthoring : MonoBehaviour
{
    public float Speed;
    public float Radius;
}
class BearMovementBaker : Baker<BearMovementAuthoring>
{
    public override void Bake(BearMovementAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);

        AddComponent(entity, new CircleMoveComponent()
        {
            Speed = authoring.Speed,
            Radius = authoring.Radius,
        });

    }
}