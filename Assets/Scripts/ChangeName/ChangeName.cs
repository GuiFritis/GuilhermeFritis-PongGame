using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeName : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textName;
    [SerializeField]
    private TMP_InputField inputName;
    [SerializeField]
    private GameObject changeNameMenu;
    [SerializeField]
    public Player player;

    private string playerName;

    public void ChangeNameAct()
    {
        playerName = inputName.text;
        textName.text = playerName;
        changeNameMenu.SetActive(false);
        player.setName(playerName);
    }
}
