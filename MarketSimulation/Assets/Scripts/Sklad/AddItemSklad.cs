using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddItemSklad : MonoBehaviour
{
    #region  --- Переменные ---
    public List<ComponentKorzin> componentkorzin;

    public List<GameObject> korzina; // Просто буфер

    public GameObject prefabInst;

    public Transform spawnInst;

    public int amount;

    [SerializeField] private TextMeshProUGUI textAmount;

    [SerializeField, Tooltip("Места хранения данных")] private DataTovar dataTovar;
    //private Dictionary<string, int> infoTovar = new Dictionary<string,int>();
    // Хотел использовать но тут только 1 значения а мне нужно 2
    #endregion

    // Пока сделаем в Update
    private void Update()
    {
        textAmount.text = "Сумма: " + amount;

        if(componentkorzin.Count == 0)
        {
            amount = 0;
        }
    }
    public void AddItem(string name)
    {
        if (componentkorzin.Count == 0)
        {
            korzina.Add(Instantiate(prefabInst, spawnInst));
            TextContainer(name, korzina.Count-1);
            return;
        }
        if (componentkorzin.Count >= 1)
        {
            for (int i = 0; i < componentkorzin.Count; i++)
            {
                if (componentkorzin[i].typeItemKorzine == (TypeItem)Enum.Parse(typeof(TypeItem), name))
                {
                    // Просто прибавляем если уже есть такой предмет
                    componentkorzin[i].value += dataTovar.AddKorzineValue(componentkorzin[i].typeItemKorzine); // Прибавляем повторно 

                    componentkorzin[i].textValue.text = componentkorzin[i].value + " шт";
                    return;
                }
                if (i == componentkorzin.Count - 1 && componentkorzin[i].typeItemKorzine != (TypeItem)Enum.Parse(typeof(TypeItem), name))
                {
                    korzina.Add(Instantiate(prefabInst, spawnInst));
                    TextContainer(name, korzina.Count - 1);
                    break;
                }
            }
            return;
        }

        
    }

    private void TextContainer(string name, int id)
    {
        TextMeshProUGUI[] Text = korzina[id].GetComponentsInChildren<TextMeshProUGUI>();

        ComponentKorzin newComponentkorzin = new ComponentKorzin()
        {
            typeItemKorzine = (TypeItem)Enum.Parse(typeof(TypeItem), name),
            objectItemKorzine = korzina[id],
            textName = Text[0],
            textValue = Text[1],
        };
        // Получаем стоимость товара
        newComponentkorzin.priceOpt = dataTovar.SearchTovarPrice(Convert.ToString(newComponentkorzin.typeItemKorzine));

        // Получаем кол-во товара за клик
        newComponentkorzin.value = dataTovar.AddKorzineValue(newComponentkorzin.typeItemKorzine);

        if (componentkorzin.Count == 0)
        {
            componentkorzin.Add(newComponentkorzin);
            newComponentkorzin.nameItem = dataTovar.ResetNameItem(newComponentkorzin.typeItemKorzine.ToString());

            newComponentkorzin.textName.text = newComponentkorzin.nameItem;

            newComponentkorzin.textValue.text = newComponentkorzin.value + " шт";
        }
        if (componentkorzin.Count >= 1)
        {
            for (int i = 0; i < componentkorzin.Count; i++)
            {
                if (i == componentkorzin.Count - 1 && componentkorzin[i].typeItemKorzine != (TypeItem)Enum.Parse(typeof(TypeItem), name))
                {
                    componentkorzin.Add(newComponentkorzin);

                    // Получаем правельное название
                    newComponentkorzin.nameItem = dataTovar.ResetNameItem(newComponentkorzin.typeItemKorzine.ToString());

                    newComponentkorzin.textName.text = newComponentkorzin.nameItem;

                    newComponentkorzin.textValue.text = newComponentkorzin.value + " шт";
                    break;
                }
            }
        }
        amount = 0;
        for (int i = 0; i < componentkorzin.Count; i++)
        {
            amount += componentkorzin[i].priceOpt * componentkorzin[i].value;
            //Debug.Log(componentkorzin[i].priceOpt + " " + componentkorzin[i].value);
        }

    }

    // Сброс всех товаров в корзине
    public void ResetKorzin()
    {
        componentkorzin.Clear();
        for (int i = 0; i < korzina.Count; i++)
        {
            Destroy(korzina[i].gameObject);
        }
        korzina.Clear();
    }
}


[Serializable]
public class ComponentKorzin
{
    public TypeItem typeItemKorzine;
    public GameObject objectItemKorzine;

    public string nameItem;
    public int value;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textValue;

    public int priceOpt;
}
