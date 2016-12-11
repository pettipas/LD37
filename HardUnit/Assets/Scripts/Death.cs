using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Death : MonoBehaviour {

    public Transform body;
    public Animator animatior;
    public List<GameObject> bits = new List<GameObject>();
    public string deathani;
    public bool onawake;

    public IEnumerator Start() {
        if (onawake) {
            yield return StartCoroutine(DieNow());
        }
        else {
            yield break;
        }
    }

	public IEnumerator DieNow () {
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
        Destroy(gameObject);
        yield break;
	}
}
