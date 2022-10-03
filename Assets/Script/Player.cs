using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IUpgradeCustomer
{
    public Transform player;
    public int holdCount;
    public float walkSpeed;
    public float salary;
    public int health;
    public bool canWalk;

    public List<GameObject> drinksInHand;
    public GameObject objectParent;
    public GameObject counterArea;

    public float money;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        drinksInHand = new List<GameObject>();
        walkSpeed /= 100;
        holdCount = 1;
        salary = 1;
        health = 90;
        money = 3;
        canWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canWalk)
        {
            return;
        }
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical"))));
        animator.SetInteger("XDirection", (int)Input.GetAxisRaw("Horizontal"));

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetInteger("YDirection", (int)Input.GetAxisRaw("Vertical"));
        } 
        else
        {
            animator.SetInteger("YDirection", 0);
        }

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            player.position += new Vector3(Input.GetAxisRaw("Horizontal") * walkSpeed, 0f, 0f);
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            player.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * walkSpeed, 0f);
        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity);
            Vector2 mouseScreenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            foreach (var hit in hits)
            {

                Debug.Log(hit.collider.tag);
                Debug.Log(holdCount >= drinksInHand.Count);
                Debug.Log(drinksInHand.Count);
                Debug.Log(holdCount);
                if (hit.collider.CompareTag("Drinks") && holdCount >= drinksInHand.Count && !hit.collider.CompareTag("Button"))
                {
                    PickUpDrinks(hit.collider.gameObject);
                    drinksInHand.Add(hit.collider.gameObject);
                    break;
                }
                else if (hit.collider.CompareTag("Floor") && drinksInHand.Count > 0 && drinksInHand.Count >= holdCount && !hit.collider.CompareTag("Button"))
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

    public void BoughtItem(Upgrade.UpgradeType upgradeType)
    {
        float cost = Upgrade.GetCost(upgradeType);
        if (cost > money)
        {
            Debug.Log("Failed To Purchase (Cost > Money) " + upgradeType);
            return;
        }

        Debug.Log("Bought Item: " + upgradeType);

        switch (upgradeType)
        {
            case Upgrade.UpgradeType.IncreaseRunSpeed:
                walkSpeed += 0.0025f;
                money -= cost;
                return;
            case Upgrade.UpgradeType.IncreaseHoldAmount:
                holdCount += 1;
                money -= cost;
                return;
            case Upgrade.UpgradeType.IncreaseSalary:
                salary += 0.2f;
                money -= cost;
                return;
            case Upgrade.UpgradeType.HealthPotion:
                if (health >= 90 || health < 0)
                {
                    return;
                }
                health += 10;
                money -= cost;
                return;
            default:
                return;
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
}
