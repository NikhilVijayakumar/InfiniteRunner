using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bavans.Runner.Player
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        Animator animator;
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            IsJumping();
            IsMagic();
            MoveLeft();
            MoveRight();
            RotateLeft();
            RotateRight();

        }


        private void RotateLeft()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.transform.Rotate(Vector3.up * -90f);
            }

        }
        private void RotateRight()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.transform.Rotate(Vector3.up * 90f);
            }

        }

        private void MoveLeft()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.transform.Translate(-0.1f, 0, 0);
            }

        }
        private void MoveRight()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                this.transform.Translate(0.1f, 0, 0);
            }

        }

        private void IsMagic()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                animator.SetBool("isMagic", true);
            }

        }

        private void IsJumping()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("isJumping", true);
            }
           
        }

        private void JumpCompleted()
        {
            animator.SetBool("isJumping", false);
        }

        private void MagicCompleted()
        {
            animator.SetBool("isMagic", false);
        }
    }
}

