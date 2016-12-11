using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {

    public MaterialFlasher matFLasher;
    public float flashTimer = 0.5f;
    float timeFashed;
    public int hits;
    public Death death;

    public void OnEnable() {
        timeFashed = 0;
        matFLasher.Flash = true;
    }

    public void Update() {
        if (timeFashed >= flashTimer) {
            matFLasher.Flash = false;

            if (hits <= 0) {
                if(death != null)
                    death.Duplicate(transform.position);
                Destroy(gameObject);
                return;
            }

            enabled = false;
        }
        timeFashed += Time.smoothDeltaTime;
    }
}
