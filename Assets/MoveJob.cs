using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

public struct MoveJob : IJobParallelForTransform
{
    public float _Speed;
    public float _Radius;
    public float _Time;

    public void Execute(int index, TransformAccess transform)
    {
        TransformAccess startPos = transform;
        Update(transform, startPos);
    }

    private void Update(TransformAccess transform, TransformAccess startPos)
    {
        float angle = 0.0f;
        angle += _Speed * _Time;

        float x = math.cos(angle) * _Radius;
        float z = math.sin(angle) * _Radius;

        transform.position = new Vector3(startPos.position.x + x, 0, startPos.position.z + z);
    }
}
