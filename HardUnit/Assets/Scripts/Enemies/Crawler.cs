using UnityEngine;
using System.Collections;

public class Crawler : MonoBehaviour {


    public Animator animator;
    public CrawlMotion motion;

    void Awake() {
        transform.localEulerAngles = new Vector3(0,180,0);
    }

    void Update () {
        if (Hero.Instance != null) {
        }
        if (!animator.IsNamedStateActive("crawler_crawl")) {
            animator.Play("crawler_crawl", 0, 0);
        }

        if (motion.Move) {
            transform.position += transform.forward * 1.0f * Time.smoothDeltaTime;
        }
    }
}
