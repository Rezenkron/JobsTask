using Unity.Entities;

public struct SpawnerComponent : IComponentData
{
    public Entity Prefab;
    public int Amount;
}
