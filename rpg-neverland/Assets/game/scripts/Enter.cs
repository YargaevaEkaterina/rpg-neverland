using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public GameObject player;
    public GameObject teleportTarget;
    public GameObject inside;
    public GameObject outside;

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
             if (Input.GetKey(KeyCode.E))
                {
                    ToTeleport();
                    outside.SetActive(false);
                    inside.SetActive(true);
                }
    }

    void ToTeleport()
    {
        player.transform.position = new Vector3(teleportTarget.transform.position.x, teleportTarget.transform.position.y, teleportTarget.transform.position.z);
    }

}
