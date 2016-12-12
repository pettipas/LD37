using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public float radius;
    public GameObject effect;

    public void Update() {
        Collider[] collider = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < collider.Length; i++) {
            Hero hero = collider[i].transform.GetComponent<Hero>();
            if (hero) {
                Game.Instance.score += 50;
                effect.Duplicate(transform.position);
                hero.ApplyBonus(name);
                Destroy(gameObject);
            }
        }
    }

    public void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
