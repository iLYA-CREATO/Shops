using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcMoved : MonoBehaviour
{
    [Header("C#")]
    [SerializeField] private PointMapMoved pointMapMoved;
    [Space(10)]
    public float waitTimeAtWaypoint = 2f; // Время ожидания на метке
    [Space(10)]
    [SerializeField] private NavMeshAgent agent;
    private bool isPointBusy; // тоже для себя
    private int SavePoint; // Просто сохраняю точку которую случайно сгенерил 

    void Start()
    {
        int rnd = Random.Range(0, pointMapMoved.pointMap.Count);
        // Проверяем не занята ли точка
        if (pointMapMoved.pointMap[rnd].pointBusy == false)
        {
            SavePoint = rnd;
            isPointBusy = true;
            pointMapMoved.pointMap[SavePoint].pointBusy = isPointBusy;

            agent.SetDestination(pointMapMoved.pointMap[rnd].pointTransform.position); // Установка первой цели
        }
        else 
        {
            // если та точка занята то выбираем следующую
            rnd = Random.Range(0, pointMapMoved.pointMap.Count);

            SavePoint = rnd;
            isPointBusy = true;
            pointMapMoved.pointMap[SavePoint].pointBusy = isPointBusy;

            agent.SetDestination(pointMapMoved.pointMap[rnd].pointTransform.position); // Установка первой цели
            Debug.LogError("Проверка: Точка куда должен идти бот занята, генерируем новую");
        }
    }

    void Update()
    {
        // Проверяем, достигли ли мы текущей метки
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            isPointBusy = false;
            pointMapMoved.pointMap[SavePoint].pointBusy = isPointBusy;
            // Ждем некоторое время на текущей метке
            StartCoroutine(WaitAtWaypoint());
            
        }
    }

    private IEnumerator WaitAtWaypoint()
    {
        yield return new WaitForSeconds(waitTimeAtWaypoint);
        int rnd = Random.Range(0, pointMapMoved.pointMap.Count);
        // Проверяем не занята ли точка
        if (pointMapMoved.pointMap[rnd].pointBusy == false)
        {
            // Переходим к следующей метке
            isPointBusy = true;
            SavePoint = rnd;
            pointMapMoved.pointMap[SavePoint].pointBusy = isPointBusy;
            agent.SetDestination(pointMapMoved.pointMap[rnd].pointTransform.position); // Установка новой цели
        }
        else
        {
            // если та точка занята то выбираем следующую
            rnd = Random.Range(0, pointMapMoved.pointMap.Count);

            // Переходим к следующей метке
            isPointBusy = true;
            SavePoint = rnd;
            pointMapMoved.pointMap[SavePoint].pointBusy = isPointBusy;
            agent.SetDestination(pointMapMoved.pointMap[rnd].pointTransform.position); // Установка новой цели
            Debug.LogError("Проверка: Точка куда должен идти бот занята, генерируем новую");
        }

    }
}