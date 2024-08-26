using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigSklad : MonoBehaviour
{
    [SerializeField] private GameObject onTrigger;

    [SerializeField] private GameObject panelKorzina;

    [SerializeField] private bool isActivePanelKorzina;
    private void OnTriggerExit(Collider other)
    {
        // проверяем что мы вышли из объекта ч тегом ""
        if(other.name == onTrigger.name)
        {
            isActivePanelKorzina = !isActivePanelKorzina;
            panelKorzina.SetActive(isActivePanelKorzina);
        }
    }
}
