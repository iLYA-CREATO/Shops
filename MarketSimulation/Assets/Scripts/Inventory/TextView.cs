using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextView : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textKorzin;
    private void OnEnable()
    {
        AddItemSklad.changedTovarCorzine += TextCorzinView;
        OutlineLaptopSklad.BuyTovarCorzine += TextCorzinView;
    }

    private void OnDisable()
    {
        AddItemSklad.changedTovarCorzine -= TextCorzinView;
        OutlineLaptopSklad.BuyTovarCorzine -= TextCorzinView;
    }

    public void TextCorzinView(int amount)
    {
        textKorzin.text = "—ÛÏÏ‡: " + amount;
    }
}
