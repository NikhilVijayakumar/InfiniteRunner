using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bavans.Runner.World.Obstacle
{
    public class DestroyWall : MonoBehaviour
    {
        public GameObject[] brickList;
        List<Rigidbody> bricksRBList = new List<Rigidbody>();
        List<Vector3> bricksPostionList = new List<Vector3>();
        List<Quaternion> bricksRotationList = new List<Quaternion>();
        Collider col;
        void Awake()
        {
            col = GetComponent<Collider>();
            foreach(GameObject brick in brickList)
            {
                bricksRBList.Add(brick.GetComponent<Rigidbody>());
                bricksPostionList.Add(brick.transform.localPosition);
                bricksRotationList.Add(brick.transform.localRotation);
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Spell")
            {
                col.enabled = false;
                foreach (Rigidbody rb in bricksRBList)
                {
                    rb.isKinematic = false;
                }
            }
        }

        private void OnEnable()
        {
            col.enabled = true;
            for(int i = 0; i < brickList.Length; i++)
            {
                brickList[i].transform.localPosition = bricksPostionList[i];
                brickList[i].transform.localRotation = bricksRotationList[i];
                bricksRBList[i].isKinematic = true;
            }
        }


    }
}
