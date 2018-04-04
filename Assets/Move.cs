using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    GameObject light;
    Vector3 v;
    float go = 2f;

	// Use this for initialization
	void Start ()
    {
        light = this.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (light.transform.position.x < -370)
        {
            go *= -1;
        }
        if (light.transform.position.x > -350)
        {
            go *= -1;
        }

        v.x = go * Time.deltaTime;
        light.transform.position += v;
        //-370 -350	
    }
}
