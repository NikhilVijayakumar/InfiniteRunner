using UnityEngine;
using Bavans.Runner.World;
using TMPro;


namespace Bavans.Runner.Player
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
      

        public static GameObject player;
        public static GameObject currentPlatform;
        public static bool isDead = false;
        bool canTurn = false;
        bool isJumping = false;
        Vector3 startPostion;
        Animator animator;
        Rigidbody rb;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI highScoreText;

        //magic
        public GameObject magic;
        public Transform magicStartPostion;
        Rigidbody mRb;
        int score = 0;


        void Start()
        {
            rb = GetComponent<Rigidbody>();
            mRb = magic.GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            player = this.gameObject;
            startPostion = player.transform.position;
            GenerateWorld.RunDummy();
            if (GenerateWorld.lastPlatform.tag != "platformTSection")
            {
                GenerateWorld.RunDummy();
            }
            if (PlayerPrefs.HasKey("highScore"))
            {
                int hs = PlayerPrefs.GetInt("highScore");
                highScoreText.text = "Highest score : " + hs;
            }
            else
            {
                highScoreText.text = "Highest score : 0";
            }
            updateScore(score);

         }

        // Update is called once per frame
        void Update()
        {
            if(isDead)
            {
                return;
            }

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
            if (isDead)
            {
                return;
            }

            if(collision.gameObject.tag == "Fire" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "DeathCube")
            {
                animator.SetTrigger("isDead");
                isDead = true;

                PlayerPrefs.SetInt("lastScore", score);
                if (PlayerPrefs.HasKey("highScore"))
                {
                    int hs = PlayerPrefs.GetInt("highScore");
                    if(hs < score)
                    {
                        PlayerPrefs.SetInt("highScore", score);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("highScore", score);
                }

            }
            else
            {
                currentPlatform = collision.gameObject;
            }           
        }

        void CastMagic()
        {
            magic.transform.position = magicStartPostion.position;
            magic.SetActive(true);
            mRb.AddForce(this.transform.forward * 4000);
            Invoke("KillMagic", 1);
        }
        void KillMagic()
        {
            magic.SetActive(false);
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
            if (Input.GetKeyDown(KeyCode.M) && !isDead)
            {
                animator.SetBool("isMagic", true);
            }

        }

        private void IsJumping()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isDead && !isJumping)
            {
                
                animator.SetBool("isJumping", true);
                isJumping = true;
                rb.AddForce(Vector3.up * 250);
                Invoke("JumpCompleted", 2);
            }
           
        }

        private void JumpCompleted()
        {
            animator.SetBool("isJumping", false);
            isJumping = false;
        }

        private void MagicCompleted()
        {
            animator.SetBool("isMagic", false);
        } 
        
        public void updateScore(int coin)
        {
            score += coin;
            scoreText.text = "Score: "+score;
        }
    }
}

