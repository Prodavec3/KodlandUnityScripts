using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    [SerializeField] Animator doorAnim;
    bool isOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isOpen)
            {
                doorAnim.SetTrigger("Close");
                isOpen = false;
            }
            else
            {
                doorAnim.SetTrigger("Open");
                isOpen = true;
            }
        }
    }
}