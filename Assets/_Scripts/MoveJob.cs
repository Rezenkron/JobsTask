using Unity.Mathematics;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Transforms;

public struct MoveJob : IJobParallelFor
{
    public float _Speed;
    public float _Radius;
    public float _Time;

    public NativeArray<LocalTransform> Bridge;
    LocalTransform localTransform;
    public void Execute(int index)
    {
        localTransform = Bridge[index];
        Update();
    }

    private void Update()
    {
        float angle = 0.0f;
        angle += _Speed * _Time;

        float x = math.cos(angle) * _Radius;
        float z = math.sin(angle) * _Radius;

        localTransform.Position = new float3(localTransform.Position.x + x, 0, localTransform.Position.z + z);
    }
}
