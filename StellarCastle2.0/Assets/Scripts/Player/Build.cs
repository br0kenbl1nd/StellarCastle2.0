using UnityEngine;

public class Build : MonoBehaviour
{
    public PlayerStats playerStats;

    [Header("Required habitat for the player")]
    [SerializeField]
    private string RQDHabitat;

    public GameObject toolTip;

    //Variables for the different buildings that this particular character can build
    #region Building Variables
    [SerializeField]
    private Buildings building1;

    [SerializeField]
    private Buildings building2;

    [SerializeField]
    private Buildings building3;

    [SerializeField]
    private Buildings building4;

    [SerializeField]
    private Buildings building5;

    [SerializeField]
    private Buildings armyCamp;
    #endregion

    //Update is used here to build based on key stroke. Number keys are used to 
    //build different buildings.
    #region Update
    private void Update()
    {
        //input key 1 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BuildBuilding1();
        }

        //input key 2 
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BuildBuilding2();
        }

        //input key 3 
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            BuildBuilding3();
        }

        //input key 4 
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            BuildBuilding4();
        }

        //input key 5 
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            BuildBuilding5();
        }

        //input key 6
        if(Input.GetKeyDown(KeyCode.Q))
        {
            BuildArmyCamp();
        }

    } //update
    #endregion

    //Contains all the functions to build the five type of buildings and one army camp
    #region Build Different Buildings

    public void BuildBuilding1()
    {
        if (building1 != null)
        {
            BuildBuilding(building1, building1.cost);
        }
    }

    public void BuildBuilding2()
    {
        if (building2 != null)
        {
            BuildBuilding(building2, building2.cost);
        }
    }

    public void BuildBuilding3()
    {
        if (building3 != null)
        {
            BuildBuilding(building3, building3.cost);
        }
    }

    public void BuildBuilding4()
    {
        if (building4 != null)
        {
            BuildBuilding(building4, building4.cost);
        }
    }

    public void BuildBuilding5()
    {
        if (building5 != null)
        {
            BuildBuilding(building5, building5.cost);
        }
    }

    public void BuildArmyCamp()
    {
        if(armyCamp != null)
        {
            BuildBuilding(armyCamp, armyCamp.cost);
        }
    }

    #endregion

    //This function checks for habitat, availability of the node, 
    //money and biulds the build, deducts the cost from the player stats
    #region Build
    public void BuildBuilding(Buildings _building, float _cost)
    {
        if (_building != null)
        {
            //check if the node has the correct habitat
            if (playerStats.CurrentNode.habitat.CurrentHabitat != null)
            {
                if (playerStats.CurrentNode.habitat.CurrentHabitat.name == _building.requiredHabitatName)
                {
                    //check if there is a building on the node already
                    if (playerStats.CurrentNode.CurrentBuilding == null)
                    {
                        //if node is free, check for money
                        if (_cost <= playerStats.Money)
                        {
                            //if we have money build
                            playerStats.CurrentNode.BuildBuildingOnNode(_building.buildingPrefab);
                            playerStats.Money -= _cost;
                        }
                        else
                        {
                            if (toolTip != null)
                            {
                                //if we dont have money, print no money
                                toolTip.GetComponent<TMPro.TextMeshProUGUI>().text = "Not enough gold";
                                Invoke("ExpireText", 0.5f);
                            }
                        }


                    }
                    else
                    {
                        if (toolTip != null)
                        {
                            //if node is full, print node is full
                            toolTip.GetComponent<TMPro.TextMeshProUGUI>().text = "Cant build here!";
                            Invoke("ExpireText", 0.5f);
                        }
                    }
                }
                else
                {
                    if (toolTip != null)
                    {
                        toolTip.GetComponent<TMPro.TextMeshProUGUI>().text = "Wrong habitat!";
                        Invoke("ExpireText", 0.5f);
                    }
                }
            }
            else
            {
                if (toolTip != null)
                {
                    toolTip.GetComponent<TMPro.TextMeshProUGUI>().text = "Wrong habitat!";
                    Invoke("ExpireText", 0.5f);
                }
            }

        }
        else
        {
            if(toolTip != null)
            {
                toolTip.GetComponent<TMPro.TextMeshProUGUI>().text = "No building selected";
                Invoke("ExpireText", 0.5f);
            }
        }

    } //build meteor shooter
    #endregion

    void ExpireText()
    {
        toolTip.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }


} //class
