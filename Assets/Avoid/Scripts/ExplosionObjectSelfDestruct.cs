using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObjectSelfDestruct : MonoBehaviour {

    private GameObject levelChanger;  

    // Use this for initialization
    void Start () {
        levelChanger = GameObject.Find("LevelChanger");

        Destroy(this.gameObject, 0.8f);
	}

    private void LoadMainMenu()
    {
        levelChanger.gameObject.GetComponent<LevelChanger>().FadeToLevel(0);
    }
}
