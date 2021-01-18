using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bavans.Runner.World.Platform;

namespace Bavans.Runner.World
{
    public class GenerateWorld : MonoBehaviour
    {

      
        GameObject dummyTraveller;

        void Start()
        {
            dummyTraveller = new GameObject("dummy");
            for (int i = 0; i < 20; i++)
            {

                GameObject platform = Pool.singleton.GetRandomPlatform();
                platform.SetActive(true);

                platform.transform.position = dummyTraveller.transform.position;
                platform.transform.rotation = dummyTraveller.transform.rotation;

                if (platform.tag == "StairUp")
                {
                    dummyTraveller.transform.Translate(0, 5, 0);
                }
                else if (platform.tag == "StairDown")
                {
                    dummyTraveller.transform.Translate(0, -5, 0);
                    platform.transform.Rotate(new Vector3(0, 180, 0));
                    platform.transform.position = dummyTraveller.transform.position;
                }
                else if (platform.tag == "platformTSection")
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
                }
                dummyTraveller.transform.Translate(Vector3.forward * -10);

            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
