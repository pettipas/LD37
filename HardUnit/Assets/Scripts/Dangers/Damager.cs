using UnityEngine;
using System.Collections;

public class Damager : MonoBehaviour {

    public float radius;

	public void Update () {
        Collider[] collider = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < collider.Length; i++) {
            Hero hero = collider[i].transform.GetComponent<Hero>();
            if (hero) {
                hero.ForceIntoTakeDamage(transform);
            }
        }
	}

    public void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
