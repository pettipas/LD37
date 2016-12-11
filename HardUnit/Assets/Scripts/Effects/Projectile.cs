using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed;
    float distance = 20;
    float _distance;
    public Vector3 dir;

    public void Update() {
        transform.Translate(dir.normalized * speed * Time.smoothDeltaTime);
        _distance += speed * Time.smoothDeltaTime;
        if (_distance > distance) {
            Destroy(gameObject);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir.normalized, out hit, 0.5f)) {
            if (hit.transform.name != "hardunit") {
                DamageEnemy d = hit.transform.GetComponent<DamageEnemy>();
                if (d != null) {
                    d.hits--;
                    d.SafeEnable();
                }
                Destroy(gameObject);
            }
        }
    }
}
