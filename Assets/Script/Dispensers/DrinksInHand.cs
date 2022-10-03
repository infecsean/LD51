using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinksInHand : MonoBehaviour
{
    
    public List<GameObject> drinksInHand;
    public GameObject objectParent;
    public int handSize;


    // Start is called before the first frame update
    void Start()
    {
        drinksInHand = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity);
            foreach (var hit in hits)
            {
                if (drinksInHand.Count > handSize)
                {
                    break;
                }
                //Debug.Log("hitting");
                if (hit.collider.CompareTag("Drinks"))
                {
                    PickUpDrinks(hit.collider.gameObject);
                    drinksInHand.Add(hit.collider.gameObject);
                }
                
            }
        }
        
    }

    void PickUpDrinks(GameObject drink)
    {
        Debug.Log("Picking up drinks");
        drink.transform.SetParent(this.transform);
        drink.transform.localPosition = new Vector3(0, 1, 0);
    }

    public List<GameObject> HasDrinks()
    {
        return drinksInHand;
    }

    private void OnDrawGizmos()
    {
        
    }

}
