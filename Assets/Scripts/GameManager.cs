using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        Initialize();
    }

    [SerializeField] private GameObject _menuPanel, _resultPanel;
    [SerializeField] private Text _resultText;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _lock;
    public bool isUnlocked = false;
    public bool isWin = false;
    public bool isDead = false;

    public void GetPlayer(Player player) => _player = player;

    private void Update()
    {
        _player.UpdatePlayerMovements();
        ManageLock();
        OnGameWin();
        OnGameOver();
    }

    private void Initialize()
    {
        Time.timeScale = 1.0f;
        _menuPanel.SetActive(false);
        _resultPanel.SetActive(false);
    }

    #region Logic-Management
    /*----------Logic-Management----------*/

    private void ManageLock()
    {
        if (!isUnlocked)
        {
            _lock.SetActive(true);
        }
        else if (isUnlocked)
        {
            _lock.SetActive(false);
        }
    }

    public void OnGameWin()
    {
        if (isWin)
            GameWin();
    }

    public void OnGameOver()
    {
        if (isDead)
            GameOver();
    }
    #endregion

    #region UI-Management
    /*----------UI-Management----------*/

    public void PauseGame()
    {
        Time.timeScale = 0;
        _player.gameObject.SetActive(false);
        _menuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        _player.gameObject.SetActive(true);
        _menuPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void GameWin()
    {
        Time.timeScale = 0;
        _player.gameObject.SetActive(false);
        _resultText.text = "Game Win!";
        _resultText.color = Color.green;
        _resultPanel.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _player.gameObject.SetActive(false);
        _resultText.text = "Game Over!";
        _resultText.color = Color.red;
        _resultPanel.SetActive(true);
    }
    #endregion

    #region Scene_Mnagement
    /*----------Scene-Management----------*/

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
