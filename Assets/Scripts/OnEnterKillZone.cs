using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterKillZone : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        GameObject go = collision.gameObject;
        PlayerMove pm = go.GetComponent<PlayerMove>();
        if (pm == null) return;
        pm.Reset();
    }
}
