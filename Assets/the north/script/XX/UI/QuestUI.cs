using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : Singletem<QuestUI> {
	[SerializeField]
	UILabel lb;
	[SerializeField]
	GameObject WeponShopUI;
	[SerializeField]
	GameObject DrugShopUI;
	[SerializeField]
	GameObject OKBtn;
	[SerializeField]
	GameObject BackBtn;
	[SerializeField]
	GameObject NextBtn;
	[SerializeField]
	TweenPosition tp;

	bool isShow;
	int id;

	struct Quest
	{
		public int id;
		public int count;
		public string txt{get{return QuestTxt.UpdateQuest (id, count);}}
	}
	Quest[] questArray=new Quest[3];

	public void ShowAcceptUI(string txt,int id){
		lb.text = txt;
		this.id = id;
		SwitchAUI ();
		TransformState ();
	}
	public void UpdateQuestUI(string txt){
		lb.text = txt;
		SwitchQUI();
	}
	public void TransformState(){
		if (isShow) {
			HideQusetUI ();
			isShow = false;
		} else {
			ShowQuestUI ();
			isShow = true;
		}
	}
	public void OnAcceptBtnClick(){
		Quest quest;
		quest.id = id;
		quest.count = 0;
		lb.text = quest.txt;
		AcceptQuest (id,quest);
		SwitchQUI ();
	}
	public void OnCancelBtnClick(){
		TransformState ();
	}
	public void OnOKBtnClick(){
		TransformState ();
	}
	public void OnBackBtnClick(){
		if (id > 1) {
			id--;
			TransformQuest (id);
		}
	}
	public void OnNextBtnClick(){
		if (id < questArray.Length) {
			id++;
			TransformQuest (id);
		}
	}
	public void PromoteQuest(int id){
		if (questArray[id].id!=0) {
			questArray[id].count++;
			if (this.id == id) {
				lb.text = questArray[id].txt;
			}
		}
	}


	void TransformQuest(int id){
		Quest quest=questArray[id];
		if (quest.id!=0) {
			id = quest.id;
			lb.text = quest.txt;
		}
	}
	void AcceptQuest(int id,Quest txt){
		Quest quest;
		quest.id = id;
		quest.count = 0;
		questArray [id] = quest;
		switch (id) {
		case 1:
			Bar_Npc.isTasking = true;
			break;
		case 2:
			IBCheckPoint.isTaked = true;
			break;
		}
	}
	public void ShowQuestUI(){
		tp.PlayForward ();
	}
    public void ShowWeaponUI() {
        tp.PlayForward();
        WeponShopUI.SetActive(true);
        DrugShopUI.SetActive(false);
        OKBtn.SetActive(false);
        BackBtn.SetActive(false);
        NextBtn.SetActive(false);
    }
    public void ShowDrugUI(){
        tp.PlayForward();
        WeponShopUI.SetActive(false);
        DrugShopUI.SetActive(true);
        OKBtn.SetActive(false);
        BackBtn.SetActive(false);
        NextBtn.SetActive(false);

    }
    public void HideQusetUI(){
		tp.PlayReverse ();
	}
	void SwitchAUI(){
        WeponShopUI.SetActive (true);
        DrugShopUI.SetActive (true);
		OKBtn.SetActive (false);
		BackBtn.SetActive (false);
		NextBtn.SetActive (false);
	}
	void SwitchQUI(){
        WeponShopUI.SetActive (false);
        DrugShopUI.SetActive (false);
		OKBtn.SetActive (true);
		BackBtn.SetActive (true);
		NextBtn.SetActive (true);
	}

}
