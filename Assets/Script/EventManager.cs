using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager Instance;

    void Awake()
    {
        Instance = this;
    }
}
