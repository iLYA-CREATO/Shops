using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AllRay : MonoBehaviour
{
    #region --- Переменные ---

    public GameObject objectRaycast;

    [SerializeField] private float distanceRay;

    [SerializeField] private TextMeshProUGUI textAction;
    [SerializeField] private TextMeshProUGUI textObject;

    #endregion

    public void Update()
    {
        objectRaycast = RayObject();

        // Всегда проверяем наводимся мы на нужный объект или нет
        if(objectRaycast == null)
        {
            ActivetedTextRaycast(false);
        }       
    }

    // Тут просто будем райкастить всё
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

    #region --- Работа с текстом ---
    public void InformationObject(string tAction, string tObject)
    {
        textAction.text = tAction;
        textObject.text = tObject;
    }

    public void ActivetedTextRaycast(bool isActive)
    {
       // Debug.Log("Вы убрали курсор с объекта");
        textAction.gameObject.SetActive(isActive);
        textObject.gameObject.SetActive(isActive);
    }
    #endregion
}
