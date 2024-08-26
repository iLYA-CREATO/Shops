using UnityEngine;

public enum TypeItem
{
    None,
    Apple,
    Banana,
    Pumpkin,
    Watermelon,
    Carrot,
    Cherries,
    ChilliPepper,
    Cucumber,
    KoreanCabbage,
    Lemon,
    Orange,
    Tomato
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public int _id;
    [Space]
    public int _priceOpt;
    [Space]
    public string _name;
    [Space]
    public Sprite _icon;
    [Space]
    public TypeItem _typeItem;
    [Space]
    public bool _stackable;
}
