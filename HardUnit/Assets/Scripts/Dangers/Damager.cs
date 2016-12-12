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
            if (collider[i].transform.name == "end") {
                Game.Instance.damage = 0;
            }

            if (collider[i].transform.name == "gates") {
                transform.GetComponent<Crawler>().crawlerspeed = 2.5f;
            }


            if (collider[i].transform.name == "halfway") {
                transform.GetComponent<Crawler>().crawlerspeed = 3.0f;
            }

            if (collider[i].transform.name == "mostal") {
                transform.GetComponent<Crawler>().crawlerspeed = 3.5f;
            }
        }
	}

    public void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
