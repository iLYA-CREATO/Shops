using TMPro;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    #region  --- Переменные ---
    [SerializeField] private string tAction, tObject;
    [SerializeField] private Day day;
    [SerializeField] private TimeDay timeDay;
    [SerializeField, Header("Откуда происходит выпуск луча")] private AllRay allRay;
    [SerializeField] private string TagRayCastObject;
    #endregion
    public void Update()
    {
        StartRayCast();
    }

    private void StartRayCast()
    {
        if (allRay.objectRaycast != null && allRay.objectRaycast.tag == TagRayCastObject)
        {
            allRay.InformationObject(tAction, tObject);
            if (timeDay.hours > 20)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    day.day++;
                    timeDay.hours = 8;
                    timeDay.minutes = 0;
                }
                else
                {
                    Debug.Log("Ещё рано спать");
                }
            }
            
        }
    }
}
