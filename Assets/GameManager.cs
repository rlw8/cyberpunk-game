using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public Dictionary<KeyCode, KeyCode> controls;

	// Use this for initialization
	void Start ()
    {
		if(Instance == null)
        {
            Instance = this;
        }
        controls = new Dictionary<UnityEngine.KeyCode, UnityEngine.KeyCode>();
        foreach(KeyCode kc in Enum.GetValues(typeof(KeyCode)))
        {
            controls[kc] = kc;
        }
    }

	public KeyCode KeyCode(KeyCode oldCode)
    {
        if (controls.ContainsKey(oldCode))
            return controls[oldCode];
        else
        {
            Debug.LogWarning("Inaccurate KeyCode used: " + oldCode);
            return UnityEngine.KeyCode.None;
        }
    }
	
        // Update is called once per frame
	void Update ()
    {
		
	}
}
