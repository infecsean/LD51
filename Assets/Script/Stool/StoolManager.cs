using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoolManager : MonoBehaviour
{
    public List<GameObject> stools;

    private List<Transform> availableSeats;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            stools.Add(gameObject.transform.GetChild(i).gameObject);
        }
        Debug.Log(GetAvailableSeats().Count);
    }

    void RemoveStool()
    {
        
    }

    public List<Transform> GetAvailableSeats()
    {
        availableSeats = new List<Transform>(0);

        foreach (GameObject seat in stools)
        {
            if (!seat.GetComponent<Stool>().isSeated)
            {
                availableSeats.Add(seat.transform);
            }
        }
        return availableSeats;
    }
}
