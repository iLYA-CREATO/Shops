using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class AddItemInventory : MonoBehaviour
{
    #region  --- Переменные ---
    [Tooltip("Инвентарь игрока")] public List<InventorySlot> SlotInventoryPlayer;
    [Tooltip("Инвентарь ящика для хранения продукции")]public List<InventorySlot> SlotInventoryBoxing;

    [Tooltip("Слоты игрока")] public int SlotPlayer; // Сам слот инвенторя
    [Tooltip("Слоты ящика")] public int SlotBoxing; // Сам слот инвенторя

    public Transform playerInventoryPosition;

    public Item item;

    public GameObject prefabItemCell;


    // Всё что сможем передать нашей клетке
    [Tooltip("Компоненты которые будем передовать в клетку инвенторя")]
    [SerializeField] private Transform canvas;
    [SerializeField] private Transform contentPlayer;
    [SerializeField] private Transform contentBoxing;
    [SerializeField] private AudioSource soundAudioSource;
    [SerializeField] private AudioClip soundClipInventoryButton;
    #endregion
    public void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            AddNevItem(item, 1);
        }
    }
    GameObject instantiateItem;
    SelectItem selectItem;
    Cell cell;
    public void AddNevItem(Item item, int count)
    {
        InventorySlot newItem = new InventorySlot()
        {
            ID = item._id,
            isOccupied = true,
            Name = item._name,
            Icon = item._icon,
            typeItem = item._typeItem,
            stackable = item._stackable,
            Value = count,
    };

        if (SlotInventoryPlayer.Count == 0 || newItem.stackable != true)
        {
            SlotInventoryPlayer.Add(newItem);
            instantiateItem = Instantiate(prefabItemCell, playerInventoryPosition);

            // Получаем скрипт клетки инвенторя
            cell = instantiateItem.GetComponent<Cell>();

            selectItem = instantiateItem.GetComponent<SelectItem>();

            selectItem._item = item;
            selectItem.UpdateUI(SlotInventoryPlayer[0].Value, item._id);

            // Заполняем ячейку данными
            cell.Init(soundAudioSource, soundClipInventoryButton, canvas, contentPlayer, contentBoxing, gameObject.GetComponent<AddItemInventory>());

            return;
        }
        if (SlotInventoryPlayer.Count >= 1)
        {
            for (int i = 0; i < SlotInventoryPlayer.Count; i++)
            {
                if (SlotInventoryPlayer[i].typeItem == newItem.typeItem && SlotInventoryPlayer[i].stackable == true)
                {
                    //Debug.Log("Такой уже есть прибавляю");
                    SlotInventoryPlayer[i].Value += count; // Приболяем согласно купленному кол-во
                    //Debug.Log(SlotInventoryPlayer[i].Value); // Проверка кол-во покупки прибовляется
                    selectItem.UpdateUI(SlotInventoryPlayer[i].Value, item._id);


                    // Заполняем ячейку данными
                    cell.Init(soundAudioSource, soundClipInventoryButton, canvas, contentPlayer, contentBoxing, gameObject.GetComponent<AddItemInventory>());
                    break;
                }
                if(i == SlotInventoryPlayer.Count-1 && SlotInventoryPlayer[i].typeItem != newItem.typeItem)
                {
                    SlotInventoryPlayer.Add(newItem);
                    instantiateItem = Instantiate(prefabItemCell, playerInventoryPosition);

                    // Получаем скрипт клетки инвенторя
                    cell = instantiateItem.GetComponent<Cell>();

                    selectItem = instantiateItem.GetComponent<SelectItem>();
                    selectItem.UpdateUI(SlotInventoryPlayer[i + 1].Value, item._id);
                    selectItem._item = item;

                    // Заполняем ячейку данными
                    cell.Init(soundAudioSource, soundClipInventoryButton, canvas, contentPlayer, contentBoxing, gameObject.GetComponent<AddItemInventory>());
                    break;
                }
            }
        }
    }
}

[Serializable]
public class InventorySlot
{
    public bool isOccupied;
    public bool stackable;

    public int ID;
    public int Value;

    public string Name;
    public Sprite Icon;

    public TypeItem typeItem;
}
