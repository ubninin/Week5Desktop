using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text talkText;
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject scanObject;
    public GameObject talkPanel;
    public Image portraitImg;
    
    public bool isAction;
    public int talkIndex;
    public void Action(GameObject scanObj)
    {

        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);
            //talkText.text = "이것의 이름은 " + scanObject.name + "이라고 한다.";
        
        talkPanel.SetActive(isAction);
    }
    void Talk(int id, bool isNpc)
    {
        //set talk data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }
        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0];
            portraitImg.sprite= talkManager.GetPortrait(id,int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }
        isAction = true;
        talkIndex++;

    }
}
