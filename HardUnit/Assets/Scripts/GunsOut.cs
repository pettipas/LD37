using UnityEngine;
using System.Collections;

public class GunsOut : HeroController {

    public WeaponTorso torso;

    public void OnEnable() {
        torso.ShowTorso("pistols");
    }

    public void OnDisable() {
        torso.HideAll();
    }
}
