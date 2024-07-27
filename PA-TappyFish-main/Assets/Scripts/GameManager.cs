using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool gameStarted;
    public GameObject getReadyImg;
    public GameObject score;
    public static int gameScore;

    [SerializeField] private UnityEngine.UI.Button btnAboutMe;
    [SerializeField] private UnityEngine.UI.Button btnMusic;

    [SerializeField] private UnityEngine.UI.Slider slider;
    private bool sliderActive = false;

    AudioSource musicSound;

    Music music;

    private void Awake()
    {

        

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        gameOver = false;
    }

    void Start()
    {
        gameStarted = false;

        music = Music.Instance;
        musicSound = music.GetComponent<AudioSource>();
        slider.value = musicSound.volume;
    }

    public void OpenSlider()
    {
        if (sliderActive)
        {
            slider.gameObject.SetActive(false);
            sliderActive = false;
        }
        else
        {
            slider.gameObject.SetActive(true);
            sliderActive = true;
        }
    }

    public void ChangeSoundLevel()
    {
        musicSound.volume = slider.value;
    }

    public void GameOver()
    {
        gameOver = true;
        gameScore = score.GetComponent<Score>().GetScore();
        btnAboutMe.gameObject.SetActive(true);
        btnMusic.gameObject.SetActive(true);

        gameOverPanel.SetActive(true);
        score.SetActive(false);
    }

    public void restartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameHasStarted()
    {
        gameStarted= true;
        getReadyImg.SetActive(false);
    }
}
