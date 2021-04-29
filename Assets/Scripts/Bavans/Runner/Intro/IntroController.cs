using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Bavans.Runner.Player;


namespace Bavans.Runner.Player
{
    public class IntroController : MonoBehaviour
    {
        
        public static GameObject player;  
        Vector3 startPostion;
        Animator animator;
        Rigidbody rb;      

        //magic
        public GameObject[] magicData;
        GameObject magic;
        public Transform magicStartPostion;
        Rigidbody mRb;
       




        void Start()
        {

            rb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            player = this.gameObject;
            startPostion = player.transform.position;
            PlayerController.isDead = true;

        }







           /* private void OnCollisionEnter(Collision collision)
        {
          

            if (collision.gameObject.tag == "Spell")
            {
                IsMagic();
            }
            else if(collision.gameObject.tag == "StairUp")
            {
               IsJumping();
            }
            else if ( collision.gameObject.tag == "platformTSection")
            {
                RotateRight(collision.gameObject);
            }
            else if (collision.gameObject.tag == "StairDown")
            {
                MoveRight();

            }
            else if (collision.gameObject.tag == "Shootable")
            {

                RotateRight(collision.gameObject);
            }

        }*/

        void CastMagic()
        {
            GetMagic();
            magic.transform.position = magicStartPostion.position;
            magic.SetActive(true);
            mRb.AddForce(this.transform.forward * 4000);
            Invoke("KillMagic", 1);
        }
        void KillMagic()
        {
            magic.SetActive(false);
        }

        void GetMagic()
        {
            int index = Random.Range(0, magicData.Length);
            print("index:" + index);
            magic = magicData[index];
            mRb = magic.GetComponent<Rigidbody>();
        }


        private void RotateLeft()
        {
            this.transform.Rotate(Vector3.up * -90f);
            //this.transform.position = new Vector3(startPostion.x, this.transform.position.y, startPostion.z);           
        }
        private void RotateRight()
        {
            this.transform.Rotate(Vector3.up * 90f);            
        }

        private void MoveLeft()
        {
            this.transform.Translate(-0.25f, 0, 0);

        }
        private void MoveRight()
        {
            this.transform.Translate(0.25f, 0, 0);

        }

        private void IsMagic()
        {            
            animator.SetBool("isMagic", true);

        }

        private void IsJumping()
        {
            animator.SetBool("isJumping", true);           
            rb.AddForce(Vector3.up * 250);
            Invoke("JumpCompleted", 2);

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


