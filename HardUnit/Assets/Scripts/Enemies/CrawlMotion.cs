using UnityEngine;
using System.Collections;

public class CrawlMotion : MonoBehaviour {

    bool crawling;

    public void MoveNow() {
        crawling = true;
    }

    public void StopNow() {
        crawling = false;
    }

    public bool Move {
        get {
            return crawling;
        }
    }
}
