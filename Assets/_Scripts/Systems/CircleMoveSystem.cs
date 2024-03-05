using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

[BurstCompile]
public partial struct CircleMoveSystem : ISystem
{
    public MoveJob MoveJob;

    public NativeArray<LocalTransform> Bridge;
    public LocalTransform[] Transforms;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        int i = 0;

        foreach (LocalTransform transform in SystemAPI.Query<LocalTransform>())
        {
            i++;
        }

        Transforms = new LocalTransform[i];

        i = 0;

        foreach (LocalTransform transform in SystemAPI.Query<LocalTransform>())
        {
            Transforms[i] = transform;
            i++;
        }

        Bridge = new NativeArray<LocalTransform>(Transforms, Allocator.Persistent);
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (RefRW<CircleMoveComponent> move in SystemAPI.Query<RefRW<CircleMoveComponent>>())
        {
            MoveJob = new MoveJob()
            {
                Bridge = this.Bridge,
                _Speed = move.ValueRO.Speed,
                _Radius = move.ValueRO.Radius,
                _Time = (float) SystemAPI.Time.ElapsedTime
            };

            MoveJob.Schedule(Transforms.Length,1);
        }

    }
}
