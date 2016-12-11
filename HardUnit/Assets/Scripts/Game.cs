using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public static Game Instance;
    public int damage = 3;
    public ScreenWiper wiper;
    public Death deathPrefab;

    bool ended;

    public void Awake() {
        damage = 3;
        Instance = this;
    }

    public IEnumerator Start() {
        yield return StartCoroutine(wiper.WipeIn(64,2));
        yield break;
    }

    public void Update() {

        if (damage <= 0 && !ended) {
            ended = true;
            StartCoroutine(EndGame());
        }
    }

    public IEnumerator EndGame() {
        Death death = deathPrefab.Duplicate(Hero.Instance.transform.position);
        Hero.Instance.gameObject.SetActive(false);
        yield return StartCoroutine(death.DieNow());
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(wiper.WipeOut(2,32));
        SceneManager.LoadScene("main");
        yield break;
    }
}
