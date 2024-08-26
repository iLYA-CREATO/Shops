using UnityEngine;

public class RayBoxing : MonoBehaviour
{
    #region --- Переменные ---
    [SerializeField, Tooltip("Тег объекта на который будем наводится")] private string NameRayCastObject;
    
    [SerializeField, Tooltip("h")] private GameObject PanelInterface;
    [SerializeField, Tooltip("h")] private GameObject BoxingInterface;

    [SerializeField, Tooltip("h")] private KeyCode KeyOpenInterface;
    
    
    [SerializeField, Tooltip("AllRaycast")] private AllRay allRay;

    [SerializeField, Tooltip("textAction - это дейстиве которое можно будет совершить при" +
        " нажати на объект, textAction - " +
        "это имя обьекта на которое будем наводится")] 
    private string textAction, textObject;

    #endregion

    private void Update()
    {
        if (allRay.objectRaycast != null && allRay.objectRaycast.tag == NameRayCastObject)
        {
            allRay.InformationObject(textAction, textObject);

            if (Input.GetKeyDown(KeyOpenInterface))
            {
                PanelInterface.SetActive(true);
                BoxingInterface.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}