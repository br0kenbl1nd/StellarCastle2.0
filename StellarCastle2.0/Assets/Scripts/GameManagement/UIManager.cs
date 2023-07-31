using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerBase;

    public UnitStats baseUnitStats;

    public PlayerStats playerStats;

    public RoundManager roundManager;

    [Header("UI elements")]
    public GameObject currencyText;
    public GameObject timeText;
    public Image healthBar;


    private void Update()
    {
        //manage the currency text
        currencyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Gold: " + playerStats.Money.ToString("00");

        //manage the health image of the base
        if (playerBase != null)
        {
            if (healthBar != null)
            {
                healthBar.fillAmount = baseUnitStats.Health / baseUnitStats.StartHealth;
            }
        }

        if (roundManager.isRoundTime == true)
        {
            timeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Round Time:" + roundManager.RoundDurationCount.ToString("00");
        }

        if(roundManager.isPreparationTime == true)
        {
            timeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Preparation Time:" + roundManager.PreparationTimeCount.ToString("00");
        }

    } //update

}
