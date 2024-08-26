using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{
    public Item _item;

    public Image _image;

    public TextMeshProUGUI _textValue;

    public int indexItem;

    public void Start()
    {
        _image.sprite = _item._icon;
    }
    public void UpdateUI(int value, int index)
    {
        _textValue.text = value.ToString();
        indexItem = index;
    }
}
