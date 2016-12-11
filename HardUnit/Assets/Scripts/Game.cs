using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public static Game Instance;
    public int damage = 3;
    public ScreenWiper wiper;

    bool ended;

    public void Awake() {
        damage = 3;
        Instance = this;
    }

    public IEnumerator Start() {
        yield return StartCoroutine(wiper.WipeIn(32,1));
        yield break;
    }

    public void Update() {

        if (damage <= 0 && !ended) {
            ended = true;
            StartCoroutine(EndGame());
        }
    }

    public IEnumerator EndGame() {
        yield return StartCoroutine(wiper.WipeOut(1,32));
        SceneManager.LoadScene("main");
        yield break;
    }
}
