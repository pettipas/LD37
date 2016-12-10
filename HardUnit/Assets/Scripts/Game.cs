using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public static Game Instance;

    public int damage = 3;

    public void Awake() {
        damage = 3;
        Instance = this;
    }

    public void Update() {

        if (damage <= 0) {
            SceneManager.LoadScene("main");
        }
    }
}
