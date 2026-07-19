using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isGameRunning = true;
    public int killCount = 0;
    public float gameTime = 0f;

    public PlayerMovement playerMovement;
    public UIManager uiManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (isGameRunning)
        {
            gameTime += Time.deltaTime;
        }
    }

    public void AddKill()
    {
        killCount++;
        if (uiManager) uiManager.UpdateKillCount(killCount);
    }
}
