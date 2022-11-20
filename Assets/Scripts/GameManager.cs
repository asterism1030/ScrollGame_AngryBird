using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance = null;
    public static GameManager Instance { get{ return instance; } private set{ instance = value; }}

    public int Gold = 0;
    public int Heart = 0;

    void Awake()
    {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this) {
            Destroy(instance.gameObject);
        }
    }

    void Update()
    {
        
    }

    // function
    


}
