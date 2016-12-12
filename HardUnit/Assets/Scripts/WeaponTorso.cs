using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponTorso : MonoBehaviour {

    public List<GameObject> torsos = new List<GameObject>();
    public Transform curser;
    public Transform hardPoint;
    Vector3 vel;

    public Gun CurrentGun {
        get;set;
    }

    public void Awake() {
        curser = GameObject.Find("curser").transform;
        hardPoint = transform.parent;
        transform.parent = null;
    }

    public void Update() {
        curser.transform.position = new Vector3(curser.transform.position.x,transform.position.y, curser.transform.position.z);
        transform.LookAt(curser);
        transform.position = Vector3.SmoothDamp(transform.position, hardPoint.position,ref vel, 0.01f);
    }

    public void ShowTorso(string wepName) {
        torsos.ForEach(x => {
            if (x == null) {
                return;
            }
            x.SetActive(false);
            if (x.name == wepName) {
                x.SetActive(true);
                CurrentGun = x.GetComponentInChildren<Gun>();
            }
        });
    }

    public void HideAll() {
        torsos.ForEach(x => {
            if(x!= null)
                x.SetActive(false);
        });
        CurrentGun = null;
    }
}
