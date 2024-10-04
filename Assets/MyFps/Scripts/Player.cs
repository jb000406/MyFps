using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class Player : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float moveSpeed = 5f;


        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        void Move()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 dir = new Vector3(x, 0, z);

            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        }
    }
}