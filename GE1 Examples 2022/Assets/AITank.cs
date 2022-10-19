using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AITank : MonoBehaviour {

    public float radius = 10;
    public int numWaypoints = 6;
    public int current = 0;
    List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;
    GameObject sphere = null;

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            Gizmos.color = Color.green;
            float theta = Mathf.PI * 2.0f / (float)numWaypoints;
            for (int i = 0; i < numWaypoints; i++)
            {
                Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
                pos = transform.TransformPoint(pos);
                Gizmos.DrawWireSphere(pos, 1);
            }
        }
    }

    // Use this for initialization
    void Awake () 
    {
        float theta = Mathf.PI * 2.0f / (float)numWaypoints;
        for (int i = 0; i < numWaypoints; i++)
        {
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            pos = transform.TransformPoint(pos);
            waypoints.Add(pos);
        }
    }

    // Update is called once per frame
    void Update () {
        Vector3 AItankPos = transform.position;
        Vector3 toNextPosition = waypoints[current] - AItankPos;
        if (sphere == null)
        {
            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = toNextPosition;
        }
        Debug.Log(toNextPosition);
        float dist = toNextPosition.magnitude;
        if (dist < 1)
        {
            current = (current + 1) % waypoints.Count;
        }
        Vector3 direction = toNextPosition / dist;
        // transform.position = Vector3.Lerp(transform.position, waypoints[current], Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current], Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toNextPosition, Vector3.up), 180 * Time.deltaTime);
        Vector3 toPlayer = player.position - transform.position;
        float dot = Vector3.Dot(transform.forward, toPlayer);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
    }
    //GameManager.Log("Hello from th AI tank");
    
}
