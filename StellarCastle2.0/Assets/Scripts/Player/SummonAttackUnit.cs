using UnityEngine;

public class SummonAttackUnit : MonoBehaviour
{
    public PlayerStats playerStats;

    [Header("Unit 1")]
    [SerializeField]
    private GameObject unit1;
    [SerializeField]
    private float unit1Cost;

    [Header("Unit 2")]
    [SerializeField]
    private GameObject unit2;
    [SerializeField]
    private float unit2Cost;

    [Header("Unit 3")]
    [SerializeField]
    private GameObject unit3;
    [SerializeField]
    private float unit3Cost;

    public string allyTag;

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Z))
        {
            SelectUnit1();
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            SelectUnit2();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            SelectUnit3();
        }

    } //update

    public void SelectUnit1()
    {
        //check if there is an army camp in the board
        if (CheckForArmyCamp())
        {
            //if an army camp is available, check resources
            if (playerStats.Money >= unit1Cost)
            {
                //if resources are available spawn 
                SpawnUnit1();
                //reduce resources
                playerStats.Money -= unit1Cost;
            }
            else
            {
                Debug.Log("no money");
            }
        }
        else
        {
            Debug.Log("No camp");
        }
    } //select unit 1

    public void SelectUnit2()
    {
        //check if there is an army camp in the board
        if (CheckForArmyCamp())
        {
            //if an army camp is available, check resources
            if (playerStats.Money >= unit2Cost)
            {
                //if resources are available spawn 
                SpawnUnit2();
                //reduce resources
                playerStats.Money -= unit2Cost;
            }
            else
            {
                Debug.Log("no money");
            }
        }
        else
        {
            Debug.Log("No camp");
        }
    } //select unit 2

    public void SelectUnit3()
    {
        //check if there is an army camp in the board
        if (CheckForArmyCamp())
        {
            //if an army camp is available, check resources
            if (playerStats.Money >= unit3Cost)
            {
                //if resources are available spawn 
                SpawnUnit3();
                //reduce resources
                playerStats.Money -= unit3Cost;
            }
            else
            {
                Debug.Log("no money");
            }
        }
        else
        {
            Debug.Log("No camp");
        }
    } //select unit 3

    bool CheckForArmyCamp()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag(allyTag);
        //initially set availablity to false
        bool campAvailable = false;

        foreach(GameObject building in buildings)
        {
            if(building.GetComponent<SpawnSoldier>() != null)
            {
                campAvailable = true;
            }
        }

        //if camp is found return true
        if(campAvailable == true)
        {
            return true;
        }
        else
        {
            return false;
        }

    } // check for army camp

    void SpawnUnit1()
    {
        Instantiate(unit1, transform.position, Quaternion.identity);
        
    } //spawn unit 1

    void SpawnUnit2()
    {
        Instantiate(unit2, transform.position, Quaternion.identity);
    } //spawn unit 2

    void SpawnUnit3()
    {
        Instantiate(unit3, transform.position, Quaternion.identity);
    } //spawn unit 3


} //class
