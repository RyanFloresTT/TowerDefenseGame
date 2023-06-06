using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GameOver : MonoBehaviour
{
    [SerializeField] HUB mainHub;
    [SerializeField] GameObject container;

    private Animator gameOverAnimator;
    private const string GAMEOVER_TRIGGER = "GameOver";

    private void Start()
    {
        mainHub.OnHubDestroyed += Handle_HubDestroyed;
        gameOverAnimator = GetComponent<Animator>();
        container.SetActive(false);
    }

    private void Handle_HubDestroyed()
    {
        PlayGameOverScreen();
    }

    private void PlayGameOverScreen()
    {
        container.SetActive(true);
        gameOverAnimator.SetTrigger(GAMEOVER_TRIGGER);
    }
}
