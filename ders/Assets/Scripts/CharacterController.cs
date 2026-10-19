using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum ColorType  //Burada topumuzun alacağı renkler var
{
    Orange,
    Blue,
    Yellow,
    Pink
}
public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; //Karakterimizin hızı

    private Renderer characterRenderer; //Karakterimizin render componenti
    [HideInInspector] public string currentColorTag; //Kapı doğrulaması için eklediğim kontrol

    void Awake()
    {
        characterRenderer = GetComponent<Renderer>();
        currentColorTag = "";
        //Render componentini tanıtıyorum ve oyun başlangıcındaki renk tagımı boşluk bırakıyorum
    }
    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); //X eksenindeki haraket
        float moveZ = Input.GetAxisRaw("Vertical"); //Z eksenindeki haraket

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized; //Y ekseninde bişey yapmadığımız için 0 verdim

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

    }

    private void OnTriggerEnter(Collider other)
    {
        //Kolonları taglarına göre buluyor
        switch (other.tag)
        {
            case "Blue":
            case "Yellow":
            case "Orange":
            case "Pink":

                currentColorTag = other.tag; //İçine girdiğimiz kolon hangi renkse o tagı almamızı sağlıyor
                Renderer columnRenderer = other.GetComponent<Renderer>();
                if (columnRenderer != null)
                {
                    characterRenderer.material.color = columnRenderer.material.color; //Renk değerini alıyoruz
                }
                break;

            default:
                //Eğer aradığımız değer bu yapıda yoksa çık
                break;
        }
    }

}
