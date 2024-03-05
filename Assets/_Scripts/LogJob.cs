using Unity.Jobs;
using Unity.Mathematics;

public struct LogJob : IJob
{
    public int numberOfEntities;
    public void Execute()
    {
        Random random = new Random(1512);
        for (int i = 0; i < numberOfEntities; i++)
        {
            math.log(random.NextFloat(100));
        }
    }
}
