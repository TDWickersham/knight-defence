using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreholder : MonoBehaviour {

    // Use this for initialization
    public int score;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
