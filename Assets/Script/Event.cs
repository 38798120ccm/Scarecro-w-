using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Event : MonoBehaviour
{
    abstract public bool CheckRequirement();
    abstract public void StartEvent();
    abstract public void DuringEvent();
    abstract public void EndEvent();
    [SerializeField] List<string> screentext_list;
    public int text_num = 0;
    public bool NoCamera;
    public Animator UI_Animator;
    public Animator S_Talk_Animator;
    public Text S_talk;
    public Text screentext;
    public WeatherManager weatherManager;
    public GameManager gameManager;
    public EventManager eventManager;
    public TimeManager timeManager;
    public int MonthCode;
    public GameObject house;
    public ParticleSystem explosion;
    public void SetInanimationFalse()
    {
        gameManager.Inanimation = false;
    }
    void SetEventStarted()
    {
        eventManager.events_started.Add(this);
        SetInanimationFalse();
    }
    public void EndStartAnimation()
    {
        SetInanimationFalse();
        SetEventStarted();
        screentext.text = " ";
    }
    public void EndEndAnimation()
    {
        SetInanimationFalse();
        screentext.text = " ";
        Destroy(this.gameObject);
    }
    void UpUI()
    {
        UI_Animator.Play("UIanim");
    }
    void DownUI()
    {   
        UI_Animator.Play("UIanim_exit");
    }
    void ScreenText(int type)
    {
        if(type == 0)
        {
            S_Talk_Animator.Play("Updialog");
            S_talk.text = screentext_list[text_num];
        }
        else
        {
            S_Talk_Animator.Play("Downdialog");
            screentext.text = screentext_list[text_num];
        }
        text_num++;
    }
    void S_TalkUp()
    {
        S_Talk_Animator.Play("Updialog");
    }
    void S_Talk(int num)
    {
        S_Talk_Animator.Play("Updialog");
        S_talk.GetComponent<Text>().text = screentext_list[num];
    }
    void EndS_Talk()
    {
        S_Talk_Animator.Play("Downdialog");
    }
    void DownTwoUI()
    {
        UI_Animator.Play("UIanim_exit");
        S_Talk_Animator.Play("Downdialog");
    }
}
