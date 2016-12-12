using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class tartS : MonoBehaviour {
	public IEnumerator Start () {
        while (!Input.anyKeyDown) {
            yield return null;
        }
        SceneManager.LoadScene("main");
	}
}
