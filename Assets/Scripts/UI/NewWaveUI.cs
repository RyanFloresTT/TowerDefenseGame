using System.Collections;
using TMPro;
using UnityEngine;

public class NewWaveUI : MonoBehaviour
{
    [SerializeField] GameObject container;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] float shownTime;

    void Awake() {
        EnemySpawner.OnWaveStarted += Handle_NewWave;
        container.SetActive(false);
    }

    void Handle_NewWave(int wave) {
        StartCoroutine(ShowWaveUI(wave));
    }

    IEnumerator ShowWaveUI(int wave) {
        container.SetActive(true);
        waveText.text = $"Wave {wave}!";
        yield return new WaitForSeconds(shownTime);
        container.SetActive(false);
    }
}
