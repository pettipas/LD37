using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour {

    public Animator debrisAnimator;

    public IEnumerator Start() {
        yield return null;
        while (debrisAnimator.IsNamedStateActive("fadeoutdebris")) {
            yield return null;
        }
        Destroy(this.gameObject);
        yield break;
    }
}
