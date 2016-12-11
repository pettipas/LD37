using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject prefab;
    public List<Transform> spawnPoints = new List<Transform>();
    public float nextDealy;

    public void OnEnable() {
        spawnPoints.ForEach(x => {
           prefab.Duplicate(x.position);
        });
    }

    public void Update() {
        enabled = false;
    }

    public void OnDrawGizmos() {
        for (int i = 0; i < spawnPoints.Count;i++) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(spawnPoints[i].position, 1.0f);
        }
    }
}
