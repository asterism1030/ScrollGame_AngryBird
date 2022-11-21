using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance = null;
    public static GameManager Instance { get{ return instance; } private set{ instance = value; }}

    public int Gold = 0;
    public int Heart = 3;

    [Header("--- Text ---")]
    public Text Score;
    public Text Life;

    [Header("--- GameObject ---")]
    public GameObject StartUI;
    public GameObject MapUI;
    public GameObject[] Texts;
    public GameObject RedBird;
    public GameObject[] Items;


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

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // function
    public void SetScoreText()
    {
        Score.text = string.Format("Score : {0:N0}", Gold);
    }

    public void SetLifeText()
    {
        Life.text = "Life : " + Heart.ToString();
    }

    public void OnStartBtnClicked()
    {
        StartCoroutine(ActiveUI());
    }

    IEnumerator ActiveUI()
    {
        yield return new WaitForSeconds(0.5f);

        StartUI.SetActive(false);
        MapUI.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        RedBird.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        
        for(int i = 0; i < Items.Length; i++) {
            Items[i].SetActive(true);
        }

        yield return new WaitForSeconds(0.3f);

        for(int i = 0; i < Texts.Length; i++) {
            Texts[i].SetActive(true);
        }

    }

}
