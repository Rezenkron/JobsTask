using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct SpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        SpawnObjects(state);
    }

    public void SpawnObjects(SystemState state)
    {
        foreach (RefRW<SpawnerComponent> spawner in SystemAPI.Query<RefRW<SpawnerComponent>>())
        {
            Random random = new Random(1);

            for (int i = spawner.ValueRO.Amount; i > 0; i--)
            {
                Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
                state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(random.NextFloat(100), 0, random.NextFloat(100)));
                spawner.ValueRW.Amount--;
            }
        }
    }
}
