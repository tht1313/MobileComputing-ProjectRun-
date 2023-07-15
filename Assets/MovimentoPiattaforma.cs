using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPiattaforma : MonoBehaviour
{
    [SerializeField] private GameObject[] Waypoints;

    private int WaypointCorrente = 0;

    [SerializeField]private float Velocitàpiattaforma = 2f;
    private void Update()
    {
        if(Vector2.Distance(Waypoints[WaypointCorrente].transform.position , transform.position) < .1f){

        WaypointCorrente++;
        if(WaypointCorrente >= Waypoints.Length){
            WaypointCorrente = 0;
        }

        }

        transform.position = Vector2.MoveTowards(transform.position , Waypoints[WaypointCorrente].transform.position , Time.deltaTime * Velocitàpiattaforma);

    }
}
