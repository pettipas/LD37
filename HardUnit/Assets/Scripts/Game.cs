using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public static Game Instance;
    public int damage = 3;
    public ScreenWiper wiper;
    public Death deathPrefab;
    public List<Spawner> spawner = new List<Spawner>();
    bool ended;

    public void Awake() {
        damage = 1;
        Instance = this;
    }

    public IEnumerator Start() {
        yield return StartCoroutine(wiper.WipeIn(32,1));
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnTHings());
        yield break;
    }

    public void Update() {

        if (damage <= 0 && !ended) {
            ended = true;
            StartCoroutine(EndGame());
        }
    }

    public IEnumerator SpawnTHings() {

        while (!ended) {
            spawner.ForEach(x => {
                if (x.Ready) {
                    x.Spawn();
                }
            });
            yield return null;
        }
        yield break;
    }

    public IEnumerator EndGame() {
        Death death = deathPrefab.Duplicate(Hero.Instance.transform.position);
        Hero.Instance.gameObject.SetActive(false);
        yield return StartCoroutine(death.DieNow());
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(wiper.WipeOut(1,32));
        SceneManager.LoadScene("main");
        yield break;
    }
}
