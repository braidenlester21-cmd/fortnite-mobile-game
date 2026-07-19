using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI gameTimeText;
    public TextMeshProUGUI speedText;
    public Button jumpButton;
    public Button crouchButton;

    public PlayerMovement playerMovement;
    private CharacterController controller;

    private void Start()
    {
        if (playerMovement)
            controller = playerMovement.GetComponent<CharacterController>();
        
        if (jumpButton) jumpButton.onClick.AddListener(() => playerMovement.JumpButton());
        if (crouchButton) crouchButton.onClick.AddListener(() => playerMovement.ToggleCrouchButton());
    }

    private void Update()
    {
        if (killCountText && GameManager.Instance)
            killCountText.text = $"Kills: {GameManager.Instance.killCount}";

        if (gameTimeText && GameManager.Instance)
            gameTimeText.text = $"Time: {GameManager.Instance.gameTime:F1}s";

        if (speedText && controller)
        {
            float speed = controller.velocity.magnitude;
            speedText.text = $"Speed: {speed:F1}";
        }
    }

    public void UpdateKillCount(int kills)
    {
        if (killCountText)
            killCountText.text = $"Kills: {kills}";
    }
}
