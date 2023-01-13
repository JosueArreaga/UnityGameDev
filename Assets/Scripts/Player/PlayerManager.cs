using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool wonGame;
    public GameObject playerControls;
    public GameObject gameOverScreen;
    public GameObject GameWonScreen;
    public GameObject MobileControls;
    public static Vector2 lastCheckPointPos;
    public static int numberOfCoins = 0;
    public TextMeshProUGUI coinText;
    public GameObject[] playerPrefabs;
    GameObject player;
    public CinemachineStateDrivenCamera Vcam;
    int characterIndex = 0;

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity );
        Animator playerAnimator = player.GetComponent<Animator>();
        Vcam.m_Follow = player.transform;
        Vcam.m_AnimatedTarget = playerAnimator;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins",0); 
        isGameOver = false;
        wonGame = false;
        
    }

    void Update()
    {
        coinText.text = numberOfCoins.ToString();
        if(isGameOver)
        {
            playerControls.SetActive(false);
            gameOverScreen.SetActive(true);
        }
        if(wonGame)
        {
            MobileControls.SetActive(false);
            GameWonScreen.SetActive(true);
            Destroy(player);
        }


    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
