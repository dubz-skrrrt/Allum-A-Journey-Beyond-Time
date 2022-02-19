using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed = 1;
    private void Awake()
    {
        SavePlayer();
    }
    private void Start()
    {

    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
    }

    public void SavePlayer()
    {
        SaveSystem.SaveGameState(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadGameState();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
