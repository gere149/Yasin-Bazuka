using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private Vector2 VelocidadMov;
    
    private Vector2 offset;

    private Material Material;

    private void Awake()
    {
        Material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = VelocidadMov * Time.deltaTime;
        Material.mainTextureOffset += offset;
    }
}
