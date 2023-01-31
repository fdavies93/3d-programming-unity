using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterKillZone : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        GameObject go = collision.gameObject;
        PlayerMove pm = go.GetComponent<PlayerMove>();
        // don't attempt to do anything if it's not a player object
        if (pm == null) return;
        // reset the player's position to their start point
        pm.Reset();
    }
}
