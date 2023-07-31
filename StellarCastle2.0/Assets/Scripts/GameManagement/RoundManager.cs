using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [Header("Round number")]
    [SerializeField]
    private int totalRounds;
    private int currentRound;

    [Header("Round Duration")]
    [SerializeField]
    private float roundDuration;
    private float roundDurationCount;
    public float RoundDurationCount
    {
        get { return roundDurationCount; }
    }

    [Header("Preparation Time")]
    [SerializeField]
    private float preparationTime;
    private float preparationTimeCount;
    public float PreparationTimeCount
    {
        get { return preparationTimeCount; }
    }

    public bool isPreparationTime;
    public bool isRoundTime;

    private void Awake()
    {
        roundDurationCount = roundDuration;
        preparationTimeCount = preparationTime;
        currentRound = 0;

        isPreparationTime = true;
        isRoundTime = false;

    } //awake

    private void Update()
    {
        //if preparation time is over start round
        if(preparationTimeCount <= 0f)
        {
            StartRound();
            preparationTimeCount = preparationTime;
            roundDurationCount = roundDuration;
        }

        if(roundDurationCount <= 0f)
        {
            StartPreparationTime();
            preparationTimeCount = preparationTime;
            roundDurationCount = roundDuration;
        }

        if(isRoundTime == true)
        {
            roundDurationCount -= Time.deltaTime;
        }
        if(isPreparationTime == true)
        {
            preparationTimeCount -= Time.deltaTime;
        }

    } //update

    void StartRound()
    {
        currentRound += 1;

        if(currentRound > totalRounds)
        {
            Debug.Log("Game Over");
            return;
        }

        //Disable attack and movement and spawning of new units
        //Disable attack on all units
        //Disable movement on all units
        //Disable spawning of units
        Debug.Log("Start Round");
        Debug.Log(currentRound);
        isRoundTime = true;
        isPreparationTime = false;
    } //start round

    void StartPreparationTime()
    {
        Debug.Log("Prepare for next Round!");
        isPreparationTime = true;
        isRoundTime = false;
    } //start preparation time


} //class
