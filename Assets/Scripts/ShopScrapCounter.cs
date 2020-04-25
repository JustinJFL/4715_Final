using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScrapCounter : MonoBehaviour

{

    private GameObject gameController;
    private GameObject CurrentPoints;
    private TextMeshProUGUI CurrentPointsText;
    private GameObject TotalPoints;
    private TextMeshProUGUI TotalPointsText;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        GameObject CurrentPoints = this.gameObject.transform.GetChild(2).gameObject;
        CurrentPointsText = CurrentPoints.GetComponent<TextMeshProUGUI>();
        CurrentPointsText.SetText("00000");
        CurrentPointsText.ForceMeshUpdate(true);

        GameObject TotalPoints = this.gameObject.transform.GetChild(3).gameObject;
        TotalPointsText = TotalPoints.GetComponent<TextMeshProUGUI>();
        TotalPointsText.SetText(gameController.GetComponent<SCR_GameManager>().actualTotalPoints.ToString());
        TotalPointsText.ForceMeshUpdate(true);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPointsText.SetText(gameController.GetComponent<SCR_GameManager>().totalPoints.ToString());
        //
    }
}
