using UnityEngine;
using System.Collections;

public class GunsOut : HeroController {

    public WeaponTorso torso;
    public Weapon weapon;

    public void Update() {
        if (torso.CurrentGun !=null && Input.GetMouseButtonUp(0)) {
            torso.CurrentGun.Fire();
        }
    }

    public void Pause() {
        torso.HideAll();
    }

    public void Resume() {
        torso.ShowTorso(weapon.ToString());
    }

    public void OnEnable() {
        weapon = Weapon.pistols;
        torso.ShowTorso(weapon.ToString());
    }

    public void OnDisable() {
        weapon = Weapon.none;
        torso.HideAll();
    }
}


public enum Weapon {
    none,
    pistols
}