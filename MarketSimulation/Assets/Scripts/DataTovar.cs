using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTovar : MonoBehaviour
{
    public Item[] _item;
    int price;
    public int SearchTovarPrice(string keyName)
    {
        for(int i = 0; i <_item.Length; i++)
        {
            if(keyName == _item[i].name)
            {
                price = _item[i]._priceOpt;
            }
        }
        return price;
    }

    // Метод возвращет количество которое игрок может добавить в карзину за 1 клик
    public int AddKorzineValue(TypeItem typeItem)
    {
        int returnValue = 0;
        switch (typeItem)
        {
            case TypeItem.Apple: returnValue = 5; break;
            case TypeItem.Banana: returnValue = 10; break;
            case TypeItem.Pumpkin: returnValue = 2; break;
            case TypeItem.Watermelon: returnValue = 2; break;
            case TypeItem.Carrot: returnValue = 10; break;
            case TypeItem.Cherries: returnValue = 100; break;
            case TypeItem.ChilliPepper: returnValue = 20; break;
            case TypeItem.Cucumber: returnValue = 25; break;
            case TypeItem.KoreanCabbage: returnValue = 4; break;
            case TypeItem.Lemon: returnValue = 20; break;
            case TypeItem.Orange: returnValue = 30; break;
            case TypeItem.Tomato: returnValue = 10; break;
            default: returnValue = -10; break;
        }
        return returnValue;
    }

    public string ResetNameItem(string name)
    {
        switch (name)
        {
            case "Apple": name = "Яблоко"; break;
            case "Banana": name = "Банан"; break;
            case "Pumpkin": name = "Тыква"; break;
            case "Watermelon": name = "Арбуз"; break;
            case "Carrot": name = "Морковь"; break;
            case "Cherries": name = "Вишня"; break;
            case "ChilliPepper": name = "Перец чили"; break;
            case "Cucumber": name = "Огурец"; break;
            case "KoreanCabbage": name = "Корейская капуста"; break;
            case "Lemon": name = "Лемон"; break;
            case "Orange": name = "Апельсин"; break;
            case "Tomato": name = "Помидор"; break;
            default: name = "-Error-"; break;
        }
        return name;
    }
}
