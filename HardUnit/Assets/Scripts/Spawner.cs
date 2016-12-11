using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject prefab;
    public List<Transform> spawnPoints = new List<Transform>();

    public void Spawn() {
        Ready = false;
        timePassed = 0;
        spawnPoints.ForEach(x => {
           prefab.Duplicate(x.position);
        });
    }

    public float timer;
    float timePassed;

    public bool Ready {
        get;set;
    }

    public void Update() {
        if (timePassed >= timer) {
            Ready = true;
        }
        timePassed += Time.smoothDeltaTime;
    }

    public void OnDrawGizmos() {
        for (int i = 0; i < spawnPoints.Count;i++) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(spawnPoints[i].position, 1.0f);
        }
    }
}
