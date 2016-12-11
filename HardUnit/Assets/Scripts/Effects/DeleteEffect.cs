using UnityEngine;
using System.Collections;

public class DeleteEffect : MonoBehaviour {

    public ParticleSystem ps;

    public IEnumerator Start() {
        while (ps.time != ps.duration) {
            yield return null;
        }
        Destroy(gameObject);
    }
}
