using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
