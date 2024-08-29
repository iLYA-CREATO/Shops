using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class npcMoved : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorController moveSityAnimator;
    [SerializeField] private AnimatorController idleAnimator;
    [Header("C#")]
    [SerializeField] private PointMapMoved pointMapMoved;
    [Space(10)]
    public float waitTimeAtWaypoint = 2f; // ����� �������� �� �����
    [Space(10)]
    [SerializeField] private NavMeshAgent agent;
    private bool isPointBusy; // ���� ��� ����
    private int SavePoint; // ������ �������� ����� ������� �������� �������� 


    public bool isWalkSity = true;
    public bool isWalkToLavka = false;

    void Start()
    {
        
        if(isWalkSity == true)
        {
            animator.runtimeAnimatorController = moveSityAnimator;
            MoveSity();
        }
    }

    public void MoveSity()
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
        if (isWalkSity == true)
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

        if (isWalkToLavka == true)
        {
            // ���������, �������� �� �� ������� �����
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                animator.runtimeAnimatorController = idleAnimator;
            }
        }

    }

    public void MoveToLavka(Transform toMove)
    {
        agent.SetDestination(toMove.transform.position);
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