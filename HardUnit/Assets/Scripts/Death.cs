﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Death : MonoBehaviour {
    public AudioSource cry;
    public AudioSource explosion;
    public Transform body;
    public Animator animatior;
    public List<GameObject> bits = new List<GameObject>();
    public string deathani;
    public bool onawake;
    public List<GameObject> bonus = new List<GameObject>();
    public bool givesItem;


    public IEnumerator Start() {
        if (onawake) {
            yield return StartCoroutine(DieNow());
        }
        else {
            yield break;
        }
    }

	public IEnumerator DieNow () {

        if (cry != null) {
            cry.Play();
        }
        if (explosion != null) {
            explosion.Play();
        }

        animatior.Play(deathani, 0, 0);
        yield return null;
        while (animatior.IsNamedStateActive(deathani)) {
            yield return null;
        }
        body.transform.parent = null;
        DestroyImmediate(body.gameObject);
        for (int i = 0; i < bits.Count;i++ ) {
            bits[i].transform.parent = null;
            bits[i].SetActive(true);
        }
        if (givesItem) {
            GameObject frab = bonus.GetRandomElement();
            GameObject g = frab.Duplicate(transform.position);
            g.name = frab.name;
            Time.timeScale += 0.1f;
        }

        Destroy(gameObject);
        yield break;
	}
}
