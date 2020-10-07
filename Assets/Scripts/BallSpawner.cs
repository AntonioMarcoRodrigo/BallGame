using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BallSpawner : MonoBehaviour
{
    Vector3[] spawnCorners = new Vector3[2];
    Quaternion[] spawnRotations = new Quaternion[2];
    ObjectPooling objectPooler;
    bool spawned = false;

    public int timeBetweenBalls;

    void Start()
    {
        objectPooler = ObjectPooling.Instance;
        for (int i = 0; i < spawnCorners.Length; i++)
        {
            spawnCorners[i] = transform.GetChild(i).position;
            spawnRotations[i] = transform.GetChild(i).rotation;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeBetweenBalls);
        Spawn();
    }

    void Update()
    {
        if (spawned == false)
        {
            Spawn();
            spawned = true;
        }
    }

    void Spawn()
    {
        int randomCorner = Random.Range(0, 2);
        objectPooler.SpawnFromPool("Ball", spawnCorners[randomCorner], spawnRotations[randomCorner]);
        StartCoroutine(Wait());
    }
}
