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

    // ����� ��������� ���������� ������� ����� ����� �������� � ������� �� 1 ����
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
            case "Apple": name = "������"; break;
            case "Banana": name = "�����"; break;
            case "Pumpkin": name = "�����"; break;
            case "Watermelon": name = "�����"; break;
            case "Carrot": name = "�������"; break;
            case "Cherries": name = "�����"; break;
            case "ChilliPepper": name = "����� ����"; break;
            case "Cucumber": name = "������"; break;
            case "KoreanCabbage": name = "��������� �������"; break;
            case "Lemon": name = "�����"; break;
            case "Orange": name = "��������"; break;
            case "Tomato": name = "�������"; break;
            default: name = "-Error-"; break;
        }
        return name;
    }
}
