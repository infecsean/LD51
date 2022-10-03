using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CustomerStateManager : MonoBehaviour
{
    public CustomerObject customerObject;
    public GameObject exitTarget;
    public GameObject stoolManager;
    //public TMPro.TextMeshProUGUI timeLeftIndicator;
    public GameObject button;
    public Canvas buttonsCanvas;

    private List<Sprite> drinkPoolSprite;

    [HideInInspector]
    public List<GameObject> drinkPool;

    [HideInInspector]
    public Sprite buttonSprite;

    [HideInInspector]
    public bool leave = false;

    [ReadOnly]
    public string currentstate;


    public CustomerBaseState currentState;
    public CustomerWalking Walking = new CustomerWalking();
    public CustomerWalking Leaving = new CustomerWalking();
    public CustomerSeated Seated = new CustomerSeated();
    public CustomerOrdering Ordering = new CustomerOrdering();
    public CustomerEating Eating = new CustomerEating();
    public CustomerPaying Paying = new CustomerPaying();

    private void Start()
    {
        //puts all the possible object sprites inside a list so we can use it for displaying orders later
        drinkPoolSprite = new List<Sprite>();
        drinkPool = new List<GameObject>();
        button = Instantiate(button, buttonsCanvas.transform.position, Quaternion.identity, buttonsCanvas.transform);
        foreach (GameObject gameObject in customerObject.orderPool)
        {
            drinkPoolSprite.Add(gameObject.GetComponent<SpriteRenderer>().sprite);
        }

        foreach (GameObject gameObject in customerObject.orderPool)
        {
            drinkPool.Add(gameObject);
            Debug.Log("adding drink from pool");
        }

        button.SetActive(false);
        buttonSprite = button.transform.GetChild(1).GetComponent<Image>().sprite;
        Debug.Log(drinkPool[0].GetComponent<SpriteRenderer>().sprite.name);
        



        currentState = Walking;

        currentState.EnterState(this);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }



    private void Update()
    {
        button.transform.position = this.transform.position + new Vector3(0, 2, 0);
        currentState.UpdateState(this);
        //timeLeftIndicator.text = timeRemaining.ToString();
        currentstate = currentState.ToString();
    }

    public void SwitchState(CustomerBaseState state, float secondsToWait)
    {
        WaitForSeconds wait = new WaitForSeconds(secondsToWait);

        StartCoroutine(WaitForSomething());
        IEnumerator WaitForSomething()
        {
            yield return wait;

            currentState = state;
            state.EnterState(this);
        }

        
    }

    public void GoDestroy()
    {
        Destroy(gameObject, .5f);
    }


}
