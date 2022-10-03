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
            Vector2 mouseScreenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            
            foreach (var hit in hits)
            {
                
                Debug.Log(hit.collider.CompareTag("Drinks"));
                Debug.Log(handSize >= drinksInHand.Count);
                Debug.Log(drinksInHand.Count);
                Debug.Log(handSize);
                if (hit.collider.CompareTag("Drinks") && handSize >= drinksInHand.Count)
                {
                    PickUpDrinks(hit.collider.gameObject);
                    drinksInHand.Add(hit.collider.gameObject);
                    break;
                }
                else if (hit.collider.CompareTag("Floor") && drinksInHand.Count > 0 && drinksInHand.Count == handSize)
                {
                    PutDownDrink(drinksInHand[0], mouseWorldPos);
                    drinksInHand.Remove(drinksInHand[0]);
                    break;
                }
                else
                {
                    break;
                }

            }
        }
        
    }

    void PickUpDrinks(GameObject drink)
    {
        //Debug.Log("Picking up drinks");
        drink.transform.SetParent(this.transform);
        drink.transform.localPosition = new Vector3(0, 1, 0);
    }
    void PutDownDrink(GameObject drink, Vector3 position)
    {
        //Debug.Log("putting down drinks");
        drink.transform.SetParent(objectParent.transform);
        drink.transform.position = position;
    }

    public List<GameObject> HasDrinks()
    {
        return drinksInHand;
    }

    private void OnDrawGizmos()
    {
        
    }

}
