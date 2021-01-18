using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bavans.Runner.World;

namespace Bavans.Runner.Player
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        Animator animator;

        public static GameObject player;
        public static GameObject currentPlatform;
        bool canTurn = false;
        Vector3 startPostion;

        void Start()
        {
            animator = GetComponent<Animator>();
            player = this.gameObject;
            startPostion = player.transform.position;
            GenerateWorld.RunDummy();
            if (GenerateWorld.lastPlatform.tag != "platformTSection")
            {
                GenerateWorld.RunDummy();
            }

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

        private void OnTriggerEnter(Collider other)
        {
            if(other is BoxCollider && GenerateWorld.lastPlatform.tag != "platformTSection")
            {
                GenerateWorld.RunDummy();
                if (GenerateWorld.lastPlatform.tag != "platformTSection")
                {
                    GenerateWorld.RunDummy();
                }
            }
            
            if(other is SphereCollider)
            {
                canTurn = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other is SphereCollider)
            {
                canTurn = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            currentPlatform = collision.gameObject;
        }


        private void RotateLeft()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
            {
                this.transform.Rotate(Vector3.up * -90f);
                GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
                GenerateWorld.RunDummy();
                if(GenerateWorld.lastPlatform.tag != "platformTSection")
                {
                    GenerateWorld.RunDummy();
                }
                this.transform.position = new Vector3(startPostion.x, this.transform.position.y, startPostion.z);
                canTurn = false;
            }

        }
        private void RotateRight()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
            {
                this.transform.Rotate(Vector3.up * 90f);
                GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
                GenerateWorld.RunDummy();
                if (GenerateWorld.lastPlatform.tag != "platformTSection")
                {
                    GenerateWorld.RunDummy();
                }

                this.transform.position = new Vector3(startPostion.x, this.transform.position.y, startPostion.z);
                canTurn = false;
            }

        }

        private void MoveLeft()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.transform.Translate(-0.25f, 0, 0);
            }

        }
        private void MoveRight()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                this.transform.Translate(0.25f, 0, 0);
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

