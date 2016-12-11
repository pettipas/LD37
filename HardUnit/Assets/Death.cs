using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Death : MonoBehaviour {

    public Transform body;
    public Animator animatior;
    public List<GameObject> bits = new List<GameObject>();

	public IEnumerator DieNow () {
        animatior.Play("death_becomes_you", 0, 0);
        yield return null;
        while (animatior.IsNamedStateActive("death_becomes_you")) {
            yield return null;
        }
        body.transform.parent = null;
        DestroyImmediate(body.gameObject);
        bits.ForEach(x => {
            x.SetActive(true);
        });
        yield break;
	}
}
