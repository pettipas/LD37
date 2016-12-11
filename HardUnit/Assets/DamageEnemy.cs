using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {

    public MaterialFlasher matFLasher;
    public float flashTimer = 0.5f;
    float timeFashed;

    public void OnEnable() {
        timeFashed = 0;
        matFLasher.Flash = true;
    }

    public void Update() {
        if (timeFashed <= flashTimer) {
            matFLasher.Flash = false;
            enabled = false;
        }
        timeFashed += Time.smoothDeltaTime;
    }
}
