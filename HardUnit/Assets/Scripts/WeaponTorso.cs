using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponTorso : MonoBehaviour {

    public List<GameObject> torsos = new List<GameObject>();

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
