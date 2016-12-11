using UnityEngine;
using System.Collections;

public class Pistols : Gun {

    public Transform lpOne;
    public Transform lpTwo;

    public Projectile projectilePrefab;

    public override void Fire() {
        Projectile p1= projectilePrefab.Duplicate(lpOne.transform.position);
        Projectile p2 = projectilePrefab.Duplicate(lpTwo.transform.position);
        p1.dir = lpOne.transform.forward;
        p2.dir = lpTwo.transform.forward;
    }
}
