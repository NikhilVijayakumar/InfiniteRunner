using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bavans.Runner.World.Platform;
using Bavans.Runner.Player;
using UnityEngine.SceneManagement;

namespace Bavans.Runner.World
{
    public class GenerateWorld : MonoBehaviour
    {

      
        public static GameObject dummyTraveller;
        public static GameObject lastPlatform;       
        

        void Awake()
        {
            dummyTraveller = new GameObject("dummy");           
        }

        public void QuitGame()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

        public void GoToTutorial()
        {
            SceneManager.LoadScene("LearnToPLay", LoadSceneMode.Single);
        }

        public static void RunDummy()
        {
            GameObject platform = Pool.singleton.GetRandomPlatform();
            GameObject deathcube = Pool.singleton.deathcube;
            if (platform == null)
            {
                return;
            }
            if(lastPlatform !=null)
            {
                if (lastPlatform.tag == "platformTSection")
                {
                    dummyTraveller.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 20;
                }
                else
                {
                    dummyTraveller.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 10;
                }
                   

                if (lastPlatform.tag == "StairUp")
                {
                    dummyTraveller.transform.Translate(0, 5, 0);
                    //deathcube.transform.Translate(0, 5, 0);
                }

               
            }

            lastPlatform = platform;
            platform.SetActive(true);
            platform.transform.position = dummyTraveller.transform.position;
            platform.transform.rotation = dummyTraveller.transform.rotation;

            if (platform.tag == "StairDown")
            {
                dummyTraveller.transform.Translate(0, -5, 0);
                platform.transform.Rotate(new Vector3(0, 180, 0));
                platform.transform.position = dummyTraveller.transform.position;
               // deathcube.transform.Translate(0, -5, 0);
            }

           

        }
    }
}
