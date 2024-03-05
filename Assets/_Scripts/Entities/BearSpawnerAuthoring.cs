using UnityEngine;
using Unity.Entities;

public class BearSpawnerAuthoring : MonoBehaviour
{
    public GameObject prefab;
    public int Amount;
}

class BearSpawnerBaker : Baker<BearSpawnerAuthoring>
{
    public override void Bake(BearSpawnerAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);

        AddComponent(entity, new SpawnerComponent
        {
            Prefab = GetEntity(authoring.prefab, TransformUsageFlags.None),
            Amount = authoring.Amount
        });
    }
}
