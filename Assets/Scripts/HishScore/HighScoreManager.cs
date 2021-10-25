using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{

    public static HighScoreManager Instance;

    private string keyToSave = "HighScoreKey";

    public TextMeshProUGUI uiHighScoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        uiHighScoreText.text = PlayerPrefs.GetString(keyToSave, "Sem Registros");
    }

    public void SaveWinner(Player winner)
    {
        if(winner.playerName == "")
        {
            return;
        }
        PlayerPrefs.SetString(keyToSave, winner.playerName + " _ " + winner.score);
        UpdateHighScore();
    }


}
