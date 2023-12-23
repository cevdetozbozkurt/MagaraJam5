using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Slider slider;

    [SerializeField] private AudioMixer audioMixer;

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;

        OnGameStateChanged(GameStateManager.Instance.CurrentGameState);
    }

    private void Start()
    {
        float value;
        audioMixer.GetFloat("volume", out value);
        slider.value = value;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.Paused:
                Time.timeScale = 0;

                Cursor.visible = !Cursor.visible;
                pauseMenu.SetActive(true);
                break;
            case GameState.Gameplay:
                Time.timeScale = 1;
                
                Cursor.visible = !Cursor.visible;
                pauseMenu.SetActive(false);
                break;
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameState currentGameState = GameStateManager.Instance.CurrentGameState;
            GameState newGameState = currentGameState == GameState.Gameplay
                ? GameState.Paused
                : GameState.Gameplay;
 
            GameStateManager.Instance.SetState(newGameState);
        }
    }
    
    public void Resume()
    {
        GameStateManager.Instance.SetState(GameState.Gameplay);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        Debug.Log("Quited");
#endif
        Application.Quit();
    }
}