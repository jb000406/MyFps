using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFps
{
    public enum EnemyState
    {
        E_Idle,     //대기
        E_Walk,     //걷기   - 적을 디텍팅하지 못한 경우
        E_Attack,   //스매시 공격
        E_Death,    //죽기
        E_Chase     //추격(걷기)    - 적을 디텍팅한 경우
    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        #region Variables
        private Transform thePlayer;
        private Animator animator;
        private NavMeshAgent agent;

        //적 현재 상태
        private EnemyState currentState;
        //적 이전 상태
        private EnemyState beforeState;

        //체력
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;

        private bool isDeath = false;

        //공격
        [SerializeField] private float attackRange = 1.5f;      //공격 가능 범위
        [SerializeField] private float attackDamage = 5f;       //공격 데미지

        //페트롤
        public Transform[] wayPoints;
        private int nowWayPoint = 0;

        private Vector3 startPosition;  //시작위치, 타겟을 잃었을때 돌아오는 지점

        //적 감지
        private bool isAiming = false;
        public bool IsAiming
        {
            get { return isAiming; }
            private set
            {
                isAiming = value;
            }
        }

        [SerializeField] private float detectDistance = 20f;
        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            //참조
            thePlayer = GameObject.Find("Player").transform;
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

            //초기화
            currentHealth = maxHealth;
            startPosition = transform.position;
            nowWayPoint = 0;

            if(wayPoints.Length > 0 )
            {
                SetState(EnemyState.E_Walk);
                GoNextPoint();
            }
            else
            {
                SetState(EnemyState.E_Idle);
            }
            



        }

        private void Update()
        {
            if (isDeath)
                return;

            //타겟 지정
            Vector3 dir = thePlayer.transform.position - transform.position;
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);

            if (distance <= attackRange)
            {
                SetState(EnemyState.E_Attack);
            }
            else if (detectDistance > 0)
            {
                if (IsAiming)
                {
                    SetState(EnemyState.E_Chase);
                }
            }

            switch (currentState)
            {
                case EnemyState.E_Idle:
                    break;
                case EnemyState.E_Walk:
                    //도착 판정
                    if(agent.remainingDistance < 0.2f)
                    {
                        GoNextPoint();
                    }
                    else
                    {
                        SetState(EnemyState.E_Idle);
                    }    
                    break;
                case EnemyState.E_Attack:
                    transform.LookAt(transform.position);
                    if (distance > attackRange)
                    {
                        SetState(EnemyState.E_Chase);
                    }
                    break;
                case EnemyState.E_Chase:
                    if (detectDistance > 0 && !IsAiming)
                    {
                        GoStartPostion();
                        return;
                    }

                    //플레이어 위치 업데이트
                    agent.SetDestination(thePlayer.position);
                    break;
            }
        }



        //적의 상태 변경
        public void SetState(EnemyState newState)
        {
            if (isDeath)
                return;

            //현재 상태 체크
            if (currentState == newState)
                return;

            //이전 상태 저장
            beforeState = currentState;
            //상태 변경
            currentState = newState;

            //상태 변경에 따른 구현 내용
            if (currentState == EnemyState.E_Chase)
            {
                animator.SetInteger("EnemyState", 1);   //에니메이션 걷기 동장
                animator.SetLayerWeight(1, 1f);
            }
            else
            {
                animator.SetInteger("EnemyState", (int)newState);
                animator.SetLayerWeight(1, 0f);
            }
            //Agent 초기화
            agent.ResetPath();
        }

        private void Attack()
        {
            Debug.Log("플레이어");
            IDamageable damageable = thePlayer.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }
        }


        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"Remaion Health : {currentHealth}");

            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        private void Die()
        {
            SetState(EnemyState.E_Death);

            isDeath = true;

            Debug.Log("Robot Death!!!");
            SetState(EnemyState.E_Death);

            //충돌체 제거
            transform.GetComponent<BoxCollider>().enabled = false;

            //킬
            Destroy(gameObject, 3f);
        }

        private void GoNextPoint()
        {
            nowWayPoint++;
            if(nowWayPoint >= wayPoints.Length)
            {
                nowWayPoint = 0;
            }
            agent.SetDestination(wayPoints[nowWayPoint].position);
        }

        //제자리로 돌아가기
        public void GoStartPostion()
        {
            if (isDeath)
                return;

            SetState(EnemyState.E_Walk);

            nowWayPoint = 0;
            agent.SetDestination(startPosition);
        }

        //적 감지 반경
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectDistance);
        }
    }
}