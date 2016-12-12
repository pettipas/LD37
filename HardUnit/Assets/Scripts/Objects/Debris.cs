using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour {

    public Animator debrisAnimator;
    public bool slow;
    public void Awake() {
        if (debrisAnimator == null) {
            debrisAnimator = GetComponent<Animator>();
        }
        if (slow) {
            debrisAnimator.speed = 0.5f;
        }
    }

    public IEnumerator Start() {
        if (debrisAnimator == null) {
            debrisAnimator = GetComponent<Animator>();
        }
        yield return null;
        while (debrisAnimator.IsNamedStateActive("fadeoutdebris")) {
            yield return null;
        }
        Destroy(this.gameObject);
        yield break;
    }
}
