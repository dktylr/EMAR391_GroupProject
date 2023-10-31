using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    public Virus virusPrefab;
    public float trajectoryVarience = 15.0f;
    public float spawnDistance = 15.0f;
    public float spawnRate = 2.0f;
    public int spawnAmount = 1;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for(int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-trajectoryVarience, this.trajectoryVarience);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Virus virus = Instantiate(this.virusPrefab, spawnPoint, rotation);
            virus.size = Random.Range(virus.minSize, virus.maxSize);
            virus.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
