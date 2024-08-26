using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AllRay : MonoBehaviour
{
    #region --- ���������� ---

    public GameObject objectRaycast;

    [SerializeField] private float distanceRay;

    [SerializeField] private TextMeshProUGUI textAction;
    [SerializeField] private TextMeshProUGUI textObject;

    #endregion

    public void Update()
    {
        objectRaycast = RayObject();

        // ������ ��������� ��������� �� �� ������ ������ ��� ���
        if(objectRaycast == null)
        {
            ActivetedTextRaycast(false);
        }       
    }

    // ��� ������ ����� ���������� ��
    public GameObject RayObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanceRay))
        {
            if(hit.collider.gameObject != null && hit.collider.gameObject.tag != "Untagged")
            {
                ActivetedTextRaycast(true);
                return hit.collider.gameObject;
            }      
        }
        return null;
    }

    #region --- ������ � ������� ---
    public void InformationObject(string tAction, string tObject)
    {
        textAction.text = tAction;
        textObject.text = tObject;
    }

    public void ActivetedTextRaycast(bool isActive)
    {
       // Debug.Log("�� ������ ������ � �������");
        textAction.gameObject.SetActive(isActive);
        textObject.gameObject.SetActive(isActive);
    }
    #endregion
}
