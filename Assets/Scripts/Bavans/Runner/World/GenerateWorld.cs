using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bavans.Runner.World.Platform;
using Bavans.Runner.Player;


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

       public static void RunDummy()
        {
            GameObject platform = Pool.singleton.GetRandomPlatform();
            if(platform == null)
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
                }

                /* else if (platform.tag == "platformTSection")
                 {
                     if (Random.Range(0, 2) == 0)
                     {
                         dummyTraveller.transform.Rotate(new Vector3(0, 90, 0));
                     }
                     else
                     {
                         dummyTraveller.transform.Rotate(new Vector3(0, -90, 0));
                     }

                     dummyTraveller.transform.Translate(Vector3.forward * -10);
                 }*/
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
            }

        }
    }
}
