using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public float radius = 1.0F;
    public float power = 1.0F;
    public GameObject explosion;
    public GameObject smokePrefab;
    public GameObject sparkUp;

    IEnumerator Start () {
        sparkUp.Duplicate(transform.position);
        explosion.Duplicate(transform.position);
        yield return null;
        smokePrefab.Duplicate(transform.position);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && hit.name != "ground") {
                rb.AddForce(new Vector3(Random.Range(-0.5f,0.5f), power, Random.Range(-0.5f, 0.5f)), ForceMode.Impulse);
            }
        }
        Destroy(gameObject);
        yield break;
	}
}
