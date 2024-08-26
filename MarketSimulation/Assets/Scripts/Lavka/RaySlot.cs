using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaySlot : MonoBehaviour
{
    #region  --- ���������� ---
    // ���� ������ ��� �������� ���������� ������
    [SerializeField] private string textAction, textObject;

    [SerializeField, Tooltip("��� ������� �� ������� ����� ���������")] private string TagRayCastObject;

    public SlotLavka slotLavka;
    [SerializeField, Header("������ ���������� ������ ����")] private AllRay allRay;

    public GameObject[] SlotInterfacePanel;
    public GameObject inventoryInterface;
    #endregion

    private void Update()
    {
       if(allRay.objectRaycast != null && allRay.objectRaycast.tag == TagRayCastObject)
        {
            allRay.InformationObject(textAction, textObject);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("�������� ������");
                slotLavka = allRay.objectRaycast.GetComponent<SlotLavka>();
                inventoryInterface.SetActive(true);
                SlotInterfacePanel[slotLavka.idSlot - 1].SetActive(true); // -1 ��� ��� ������� id � 1

                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
