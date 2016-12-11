using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponTorso : MonoBehaviour {

    public List<GameObject> torsos = new List<GameObject>();

    public Transform curser;

    public void Awake() {
        curser = GameObject.Find("curser").transform;
    }

    public void Update() {
        transform.LookAt(curser);
    }

    public void ShowTorso(string wepName) {
        torsos.ForEach(x => {
            x.SetActive(false);
            if (x.name == wepName) {
                x.SetActive(true);
            }
        });
    }

    public void HideAll() {
        torsos.ForEach(x => {
           x.SetActive(false);
        });
    }
}
