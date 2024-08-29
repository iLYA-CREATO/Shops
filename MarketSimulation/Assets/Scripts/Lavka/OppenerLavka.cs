using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppenerLavka : MonoBehaviour
{
    public static event Action<bool> _isOpenLavka;

    [SerializeField] private AllRay allRay;

    private string textAction;
    [SerializeField] private string textObject;
    [SerializeField, Tooltip("Тег объекта на который будем наводится")] private string TagRayCastObject;

    [SerializeField] private Material[] MaterialOppener;
    
    [SerializeField] private GameObject viveska;


    public bool isOpenLavka;
    public void Update()
    {
        ActionLavka();
        if (allRay.objectRaycast != null && allRay.objectRaycast.tag == TagRayCastObject)
        {
            allRay.InformationObject(textAction, textObject);
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpenLavka = !isOpenLavka;
            }
        }
    }


    private void ActionLavka()
    {
        if (isOpenLavka)
        {
            textAction = "Закрыть";
            viveska.GetComponent<Renderer>().material = MaterialOppener[0];
        }
        else
        {
            textAction = "Открыть";
            viveska.GetComponent<Renderer>().material = MaterialOppener[1];
        }
        _isOpenLavka?.Invoke(isOpenLavka);
    }
}
