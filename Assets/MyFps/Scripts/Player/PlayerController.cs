using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //플레이어 상태
    public enum PlayerState
    {
        P_Idle,
        P_Walk,
        P_Attack,
        P_Death
    }
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "GameOver";

        Animator animator;

        //플레이어 현재 상태
        private PlayerState currentState;
        //플레이어 이전 상태
        private PlayerState beforeState;

        private bool isDeath = false;

        [SerializeField] private float maxHealth = 20f;
        private float currentHealth;

        //데미지 효과
        public GameObject damageFlash;      //데미지 플래쉬 효과
        public AudioSource hurt01;          //데미지 사운드1
        public AudioSource hurt02;          //데미지 사운드2
        public AudioSource hurt03;          //데미지 사운드3

        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            //참조
            animator = GetComponent<Animator>();

            //초기화
            isDeath = false;
            currentHealth = maxHealth;
        }

        // Update is called once per frame
        private void Update()
        {
            if (isDeath) return;

            switch (currentState)
            {
                case PlayerState.P_Idle:
                    break;
                case PlayerState.P_Walk:
                    break;
                case PlayerState.P_Attack:
                    break;
                case PlayerState.P_Death:
                    break;
            }
        }

        public void SetState(PlayerState newState)
        {
            //현재 상태 체크
            if (currentState == newState)
                return;

            //이전 상태 저장
            beforeState = currentState;
            //상태 변경
            currentState = newState;

            //상태 변경에 따른 구현 내용
            //animator.SetInteger("PlayerState", (int)newState);
        }


        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"Remaion Health : {currentHealth}");

            //데미지 효과
            StartCoroutine(DamageEffect());

            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        private void Die()
        {
            isDeath = true;
            fader.FadeTo(loadToScene);
            
        }

        IEnumerator DamageEffect()
        {
            damageFlash.SetActive(true);

            int randNumber = Random.Range(1, 4);
            if(randNumber == 1)
            {
                hurt01.Play();
            }
            else if(randNumber == 2)
            {
                hurt02.Play();
            }
            else
            {
                hurt03.Play();
            }

            yield return new WaitForSeconds(1f);

            damageFlash.SetActive(false);
        }
    }
}