using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bavans.Runner.Utils;
namespace Bavans.Runner.World.Platform
{
    public class Pool : MonoBehaviour
    {
        public static Pool singleton;
        public List<PoolItem> itemList;
        private List<GameObject> pooledItemList;
        public List<Material> materialDark;
        public List<Material> materialLight;
        private bool theme;
        public  GameObject deathcube;
        private Material material;
       
        // Start is called before the first frame update

        private void Awake()
        {
            int index = Random.Range(0, 100);
            theme = index % 5 == 0;           
            singleton = this;
            pooledItemList = new List<GameObject>();
            foreach(PoolItem item in itemList)
            {
                for(int i = 0; i < item.amount; i++)
                {
                    GameObject obj = Instantiate(item.prefab);
                    obj.SetActive(false);
                    pooledItemList.Add(obj);
                }
            }
        }

        public GameObject GetRandomPlatform()
        {
            RunnerUtils.Shuffle(pooledItemList);
            for (int i = 0; i < pooledItemList.Count; i++)
            {
                if (!pooledItemList[i].activeInHierarchy)
                {
                    pooledItemList[i].GetComponentInChildren<Renderer>().material = material;
                    return pooledItemList[i];
                }
            }
            foreach (PoolItem item in itemList)
            {
                if (item.expandable)
                {
                    GameObject obj = Instantiate(item.prefab);
                    obj.SetActive(false);
                    obj.GetComponentInChildren<Renderer>().material = material;
                    pooledItemList.Add(obj);
                    return obj;
                }
            }
            return null;
        }

       

        public bool GetTheme()
        {
            return theme;
        }

        public Material GetMaterial()
        {
            if (theme)
            {
                int index = Random.Range(0, materialDark.Count);
                return materialDark[index];
            }
            else
            {
                int index = Random.Range(0, materialLight.Count);
                return materialLight[index];
            }
        }

        public void UpdateMaterial(Material data)
        {
            material = data; 
        }

        public void UpdateMaterial()
        {
            material = GetMaterial();
        }


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
