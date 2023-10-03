using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject container;

    Animator gameOverAnimator;
    const string GAMEOVER_TRIGGER = "GameOver";

    void Start() {
        HUB.OnHubDestroyed += Handle_HubDestroyed;
        gameOverAnimator = GetComponent<Animator>();
        container.SetActive(false);
    }

    void Handle_HubDestroyed() {
        PlayGameOverScreen();
    }

    void PlayGameOverScreen() {
        container.SetActive(true);
        gameOverAnimator.SetTrigger(GAMEOVER_TRIGGER);
    }
}
