using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {
    public AudioSource hit;

    public MaterialFlasher matFLasher;
    float flashTimer = 0.1f;
    float timeFashed;
    public int hits;
    public Death death;

    public bool givesItem;

    public void OnEnable() {
        timeFashed = 0;
        matFLasher.Flash = true;
        hit.Play();
    }

    public void Update() {
     
        if (timeFashed >= flashTimer) {
            matFLasher.Flash = false;
          
            if (hits <= 0) {
                if (death != null) {
                    Game.Instance.score += 100;
                    death.givesItem = givesItem;
                    death.Duplicate(transform.position);
                    Destroy(gameObject);
                }
                return;
            }

            enabled = false;
        }
        timeFashed += Time.smoothDeltaTime;
    }
}
