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
    public Text FinalScore;

    [Header("--- GameObject ---")]
    public GameObject StartUI;
    public GameObject EndUI;
    public GameObject RedBirdDeco;
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
        StartCoroutine(ActiveGame(true));
    }

    IEnumerator ActiveGame(bool isActive)
    {
        if(isActive == true) {
            while(RedBirdDeco.transform.position.x <= 10.0f) {
                RedBirdDeco.transform.Translate(Time.deltaTime * 25.0f, 0, 0);

                yield return null;
            }

            RedBirdDeco.transform.position = new Vector3(-8.6f, 1.42f, 0.0f);
            
            StartUI.SetActive(false);
            EndUI.SetActive(false);
        }

        RedBirdDeco.SetActive(!isActive);

        MapUI.SetActive(isActive);
        RedBird.SetActive(isActive);

        for(int i = 0; i < Items.Length; i++) {
            Items[i].SetActive(isActive);
        }

        for(int i = 0; i < Texts.Length; i++) {
            Texts[i].SetActive(isActive);
        }

        SetScoreText();
        SetLifeText();
    }

    public void GameOver()
    {
        StartCoroutine(ActiveGame(false));

        EndUI.SetActive(true);
        FinalScore.text = Score.text;
        Gold = 0;
        Heart = 3;
    }

    public void OnRestartClicked()
    {
        StartCoroutine(ActiveGame(true));
    }

}
