using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorTag; //Kapımızın hangi renk olduğunu belirtiyoruz
    private Collider doorCollider;

    void Awake()
    {
        //Kapının kendi üzerindeki Collider bileşenini alıyoruz
        doorCollider = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball")) //Eğer çarpan nesnenin tagı "Ball ise"
        {
            CharacterController playerColor = collision.collider.GetComponent<CharacterController>(); //Oyuncudaki scripti çağırıyoruz

            if (playerColor != null)
            {
                if (playerColor.currentColorTag == doorTag)
                {
                    Debug.Log("Geçebilirsin.");
                    //Eğer oyuncunun tagı kapıdaki taga eşitse
                    doorCollider.isTrigger = true;
                }
                else
                {
                    Debug.Log("Geçemezsin.");
                    //Eğer oyuncunun tagı kapıdaki taga eşit değilse
                    doorCollider.isTrigger = false;
                }
            }
        }
    }

    //Karakter kapıdan uzaklaştığında kapıyı eski haline getiriyoruz
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            doorCollider.isTrigger = false;
        }
    }
}

