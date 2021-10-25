using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Image))]
public class ColorButton : MonoBehaviour
{

    public Color color;

    [SerializeField]
    private Player player;
    [SerializeField]
    private TextMeshProUGUI textName;
    [SerializeField]
    private Image image;

    private void OnValidate()
    {
        image = GetComponent<Image>();
    }

    void Start()
    {
        image.color = color;   
    }

    public void OnClick()
    {
        player.ChangeColor(color);
        textName.color = color;
    }
}
