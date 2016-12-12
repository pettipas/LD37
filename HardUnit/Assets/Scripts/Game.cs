using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public Text scoreText;
    public Text gameOver;
    public Text hearts;


    public int score;
    public static Game Instance;
    public int damage = 3;
    public ScreenWiper wiper;
    public Death deathPrefab;
    public List<Spawner> spawner = new List<Spawner>();
    bool ended;

    string oneHeart = "<3";
    string twoHearts = "<3<3";
    string threeHearts = "<3<3<3";

    public void Awake() {
        Time.timeScale = 1;
        damage = 3;
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
        hearts.text = GetHearts();
        scoreText.text = score.ToString("D8");
    }

    string GetHearts() {

        if (damage == 1) {
            return oneHeart;
        }

        if (damage == 2) {
            return twoHearts;
        }

        return threeHearts;
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
        gameOver.enabled = true;
        while (!Input.anyKey) {
            yield return null;
        }
        SceneManager.LoadScene("main");
        yield break;
    }
}
