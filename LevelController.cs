using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] List<GameObject> plates = new List<GameObject>();
    [SerializeField] List<GameObject> rbWalls = new List<GameObject>();
    [SerializeField] List<GameObject> matPlatform = new List<GameObject>();
    [SerializeField] List<PhysicMaterial> mat = new List<PhysicMaterial>();

    //Material brake;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < matPlatform.Count; i++)
        {
            matPlatform[i].GetComponent<Collider>().sharedMaterial = mat[Random.Range(1, mat.Count)];
        }
        int randomPlatf = Random.Range(0, matPlatform.Count);
        matPlatform[randomPlatf].gameObject.GetComponent<Collider>().sharedMaterial = mat[0];
        //
        for (int i = 0; i < plates.Count; i += 4)
        {
            plates[Random.Range(i, i + 4)].GetComponent<Collider>().isTrigger = true;
        }

        for (int i = 0; i < rbWalls.Count; i += 5)
        {
            int x = Random.Range(i, i + 5);

            RigidbodyWall(x);
        }
    }

    public void RigidbodyWall(int count)
    {
        Rigidbody rb = rbWalls[count].gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        //rbWalls[count].GetComponent<MeshRenderer>().materials[0] = brake;
    }
}