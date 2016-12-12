using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject prefab;

    public List<Transform> spawnPoints = new List<Transform>();
    public List<Color> colors = new List<Color>();
    public Color rareOne;

    public void Awake() {
        timePassed = timer;
    }

    public void Spawn() {
        Ready = false;
        timePassed = 0;
        spawnPoints.ForEach(x => {
            int choice;
            GameObject instance = null;

            if (Random.value < 0.9f) {
                prefab.GetComponent<MaterialFlasher>().dye = colors.GetRandomElement(out choice);
                instance = prefab.Duplicate(x.position);
            } else {
                choice = 4;
               
                prefab.GetComponent<MaterialFlasher>().dye = rareOne;
                instance = prefab.Duplicate(x.position);
                instance.GetComponent<DamageEnemy>().givesItem = true;
            }
         
            DamageEnemy de = instance.GetComponent<DamageEnemy>();

            if (choice == 0) {
                de.hits = 5;
            }
            else if (choice == 1) {
                de.hits = 8;
            }
            else if (choice == 3) {
                de.hits = 15;
            }
            else {
                de.hits = 20;
            }
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
