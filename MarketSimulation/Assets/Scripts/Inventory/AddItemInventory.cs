using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class AddItemInventory : MonoBehaviour
{
    #region  --- ���������� ---
    [Tooltip("��������� ������")] public List<InventorySlot> SlotInventoryPlayer;
    [Tooltip("��������� ����� ��� �������� ���������")]public List<InventorySlot> SlotInventoryBoxing;

    [Tooltip("����� ������")] public int SlotPlayer; // ��� ���� ���������
    [Tooltip("����� �����")] public int SlotBoxing; // ��� ���� ���������

    public Transform playerInventoryPosition;

    public Item item;

    public GameObject prefabItemCell;


    // �� ��� ������ �������� ����� ������
    [Tooltip("���������� ������� ����� ���������� � ������ ���������")]
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

            // �������� ������ ������ ���������
            cell = instantiateItem.GetComponent<Cell>();

            selectItem = instantiateItem.GetComponent<SelectItem>();

            selectItem._item = item;
            selectItem.UpdateUI(SlotInventoryPlayer[0].Value, item._id);

            // ��������� ������ �������
            cell.Init(soundAudioSource, soundClipInventoryButton, canvas, contentPlayer, contentBoxing, gameObject.GetComponent<AddItemInventory>());

            return;
        }
        if (SlotInventoryPlayer.Count >= 1)
        {
            for (int i = 0; i < SlotInventoryPlayer.Count; i++)
            {
                if (SlotInventoryPlayer[i].typeItem == newItem.typeItem && SlotInventoryPlayer[i].stackable == true)
                {
                    //Debug.Log("����� ��� ���� ���������");
                    SlotInventoryPlayer[i].Value += count; // ��������� �������� ���������� ���-��
                    //Debug.Log(SlotInventoryPlayer[i].Value); // �������� ���-�� ������� ������������
                    selectItem.UpdateUI(SlotInventoryPlayer[i].Value, item._id);


                    // ��������� ������ �������
                    cell.Init(soundAudioSource, soundClipInventoryButton, canvas, contentPlayer, contentBoxing, gameObject.GetComponent<AddItemInventory>());
                    break;
                }
                if(i == SlotInventoryPlayer.Count-1 && SlotInventoryPlayer[i].typeItem != newItem.typeItem)
                {
                    SlotInventoryPlayer.Add(newItem);
                    instantiateItem = Instantiate(prefabItemCell, playerInventoryPosition);

                    // �������� ������ ������ ���������
                    cell = instantiateItem.GetComponent<Cell>();

                    selectItem = instantiateItem.GetComponent<SelectItem>();
                    selectItem.UpdateUI(SlotInventoryPlayer[i + 1].Value, item._id);
                    selectItem._item = item;

                    // ��������� ������ �������
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
