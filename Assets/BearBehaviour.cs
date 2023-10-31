using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;
using System.Collections;

public class BearBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bearPrefab;
    [SerializeField] private int amountOfEntities;
    [SerializeField] private float speed;
    [SerializeField] private float radius;

    private TransformAccessArray _transformAccessArray;
    private Transform[] transforms;

    private MoveJob moveJob;
    private LogJob logJob;
    void Start()
    {
        transforms = new Transform[amountOfEntities];
        for(int i = 0; i < amountOfEntities; i++)
        {
            transforms[i] = Instantiate(bearPrefab, new Vector3(Random.Range(0,150),0, Random.Range(0, 150)), Quaternion.identity).transform;
        }

        _transformAccessArray = new TransformAccessArray(transforms);

        moveJob = new MoveJob()
        {
            _Speed = speed,
            _Radius = radius,
        };

        StartCoroutine(StartLogCount());
    }

    private void Update()
    {
        moveJob._Time = Time.time;
        var moveHandle = moveJob.Schedule(_transformAccessArray);
        moveHandle.Complete();
    }

    private void OnDestroy()
    {
        _transformAccessArray.Dispose();
    }

    private IEnumerator StartLogCount()
    {
        yield return new WaitForSeconds(5);
        logJob = new LogJob()
        {
            numberOfEntities = amountOfEntities
        };
        logJob.Schedule();
    }
}
