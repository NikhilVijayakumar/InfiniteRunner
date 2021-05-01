using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bavans.Runner.World.Platform;
namespace Bavans.Runner.World.Obstacle
{
    public class WallMaterial : MonoBehaviour
    {
        public GameObject[] brickList;
        public List<Material> materialDark;
        public List<Material> materialLight;
        // Start is called before the first frame update
        void Awake()
        {
            int index = 0;
            if (Pool.singleton.GetTheme())
            {
                index = Random.Range(0, materialDark.Count);
            }               
            else
            {
                index = Random.Range(0, materialLight.Count);
            }
          

            foreach (GameObject brick in brickList)
            {
                if (Pool.singleton.GetTheme())
                {                    
                    brick.GetComponentInChildren<Renderer>().material = materialDark[index];
                }
                else
                {                   
                    brick.GetComponentInChildren<Renderer>().material = materialLight[index];
                }
            }

        }
    }
}

