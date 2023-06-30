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

    private void Awake()
    {
        roundDurationCount = roundDuration;
        preparationTimeCount = preparationTime;
        currentRound = 0;
    } //awake

    private void Update()
    {
        //if preparation time is over start round
        if(preparationTimeCount <= 0f)
        {
            //start round
            StartRound();
            roundDurationCount = roundDuration;
            preparationTimeCount = 100000f;
        }

        //if round time is over, start preparation time
        if(roundDurationCount <= 0f)
        {
            //start preparation time
            StartPreparationTime();
            preparationTimeCount = preparationTime;
            roundDurationCount = 100000f;
        }

        roundDurationCount -= Time.deltaTime;
        preparationTimeCount -= Time.deltaTime;

    } //update

    void StartRound()
    {
        currentRound += 1;

        if(currentRound > totalRounds)
        {
            Debug.Log("Game Over");
            return;
        }

        Debug.Log("Start Round");
        Debug.Log(currentRound);
    } //start round

    void StartPreparationTime()
    {
        Debug.Log("Prepare for next Round!");
    } //start preparation time


} //class
