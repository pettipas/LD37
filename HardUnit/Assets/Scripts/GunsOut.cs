using UnityEngine;
using System.Collections;

public class GunsOut : HeroController {

    public WeaponTorso torso;
    public Weapon weapon;


    public void Update() {
        if (torso.CurrentGun != null && Input.GetMouseButtonUp(0) && gameObject) {
            torso.CurrentGun.Fire();
            CameraShake.Instance.Shake();
        } else if (Hero.auto >= 1 && Input.GetMouseButton(0) && gameObject) {
            if (torso != null && torso.CurrentGun != null) torso.CurrentGun.Fire();
            CameraShake.Instance.Shake();
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