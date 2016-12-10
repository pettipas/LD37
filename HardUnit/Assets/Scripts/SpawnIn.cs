﻿using UnityEngine;
using System.Collections;

public class SpawnIn : MonoBehaviour {

    public Hero heroPrefab;
    public Animator spawnEffect;

    public IEnumerator Start() {
        spawnEffect.Play("animate_in", 0, 0);
        yield return null;
        while (spawnEffect.IsNamedStateActive("animate_in")) {
            yield return null;
        }
        heroPrefab.Duplicate(transform.position);
        DestroyImmediate(gameObject);
        yield break;
    }
}
