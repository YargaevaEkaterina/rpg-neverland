using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject teleportTarget;
    private bool _insideCollider;

    void Update()
    {
        if (_insideCollider == true)
        {
            if (Input.GetKey(KeyCode.E))
                {
                    ToTeleport();
                }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _insideCollider = true;
    }

    void ToTeleport()
    {
        player.transform.position = new Vector3(teleportTarget.transform.position.x, teleportTarget.transform.position.y, teleportTarget.transform.position.z);
    }

}
