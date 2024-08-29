using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientGame : MonoBehaviour
{
    public DataClients dataClients;

    public bool isOpen;

    private void OnEnable()
    {
        OppenerLavka._isOpenLavka += GetDate;
    }

    private void OnDisable()
    {
        OppenerLavka._isOpenLavka -= GetDate;
    }

    private void GetDate(bool open)
    {
        isOpen = open;

        if (isOpen == true && dataClients.queueLavka < dataClients.maxQueueLavka)
        {
            for (int i = 0; i < dataClients.npcMoved.Count; i++)
            {
                for (int j = 0; j < dataClients.points.Count; j++)
                {
                    for (int g = 0; g < dataClients.isActivePoints.Count; g++)
                    {
                        if (dataClients.isActivePoints[g] == false)
                        {
                            dataClients.isActivePoints[g] = true;
                            dataClients.npcMoved[g].isWalkSity = false;
                            dataClients.npcMoved[g].isWalkToLavka = true;

                            dataClients.npcMoved[g].MoveToLavka(dataClients.points[j]);
                            dataClients.queueLavka++;
                            Debug.Log(dataClients.npcMoved[g].name);
                            break;
                        }
                    }
                }
            }
        }   
    }
}

[Serializable]
public class DataClients
{
    public List<Transform> points;
    public List<bool> isActivePoints;
    public List<npcMoved> npcMoved;

    public int queueLavka;
    public int maxQueueLavka;
}
