using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcMoved : MonoBehaviour
{
    [Header("C#")]
    [SerializeField] private PointMapMoved pointMapMoved;
    [Space(10)]
    public float waitTimeAtWaypoint = 2f; // ����� �������� �� �����
    [Space(10)]
    [SerializeField] private NavMeshAgent agent;
    private bool isPointBusy; // ���� ��� ����
    private int SavePoint; // ������ �������� ����� ������� �������� �������� 

    void Start()
    {
        int rnd = Random.Range(0, pointMapMoved.pointMap.Count);
        // ��������� �� ������ �� �����
        if (pointMapMoved.pointMap[rnd].pointBusy == false)
        {
            SavePoint = rnd;
            isPointBusy = true;
            pointMapMoved.pointMap[SavePoint].pointBusy = isPointBusy;

            agent.SetDestination(pointMapMoved.pointMap[rnd].pointTransform.position); // ��������� ������ ����
        }
        else 
        {
            // ���� �� ����� ������ �� �������� ���������
            rnd = Random.Range(0, pointMapMoved.pointMap.Count);

            SavePoint = rnd;
            isPointBusy = true;
            pointMapMoved.pointMap[SavePoint].pointBusy = isPointBusy;

            agent.SetDestination(pointMapMoved.pointMap[rnd].pointTransform.position); // ��������� ������ ����
            Debug.LogError("��������: ����� ���� ������ ���� ��� ������, ���������� �����");
        }
    }

    void Update()
    {
        // ���������, �������� �� �� ������� �����
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            isPointBusy = false;
            pointMapMoved.pointMap[SavePoint].pointBusy = isPointBusy;
            // ���� ��������� ����� �� ������� �����
            StartCoroutine(WaitAtWaypoint());
            
        }
    }

    private IEnumerator WaitAtWaypoint()
    {
        yield return new WaitForSeconds(waitTimeAtWaypoint);
        int rnd = Random.Range(0, pointMapMoved.pointMap.Count);
        // ��������� �� ������ �� �����
        if (pointMapMoved.pointMap[rnd].pointBusy == false)
        {
            // ��������� � ��������� �����
            isPointBusy = true;
            SavePoint = rnd;
            pointMapMoved.pointMap[SavePoint].pointBusy = isPointBusy;
            agent.SetDestination(pointMapMoved.pointMap[rnd].pointTransform.position); // ��������� ����� ����
        }
        else
        {
            // ���� �� ����� ������ �� �������� ���������
            rnd = Random.Range(0, pointMapMoved.pointMap.Count);

            // ��������� � ��������� �����
            isPointBusy = true;
            SavePoint = rnd;
            pointMapMoved.pointMap[SavePoint].pointBusy = isPointBusy;
            agent.SetDestination(pointMapMoved.pointMap[rnd].pointTransform.position); // ��������� ����� ����
            Debug.LogError("��������: ����� ���� ������ ���� ��� ������, ���������� �����");
        }

    }
}