using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pistols : Gun {

    public Transform lpOne;
    public Transform lpTwo;

    public List<Projectile> projectilePrefabs = new List<Projectile>();

    public override void Fire() {
        if (Hero.Instance.super >= projectilePrefabs.Count) {
            Hero.Instance.super = projectilePrefabs.Count - 1;
        }
        Projectile p1= projectilePrefabs[Hero.Instance.super].Duplicate(lpOne.transform.position);
        Projectile p2 = projectilePrefabs[Hero.Instance.super].Duplicate(lpTwo.transform.position);

        p1.dir = lpOne.transform.forward;
        p2.dir = lpTwo.transform.forward;
    }
}
