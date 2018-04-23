using System;

public class QuestTxt
{
	public const string killWolfBaby="巨树消失了......附近又出现了许多怪物，你能不能去帮我清理一下呢？就在前面的那个山谷旁......\n\n任务:杀死10只小野狼\n奖励：1000金币";
	public const string killWolfNormal="我们是在附近村庄中做生意的商人，昨天在途中遭到了一群半人半狼的怪物的袭击，只能一直躲在这里。能不能请你帮我们把附近的狼人清理掉呢？\n\n任务：杀死5只狼人\n奖励：小Hp药剂X2";
	public const string QuestComplete="任务已完成";
    
	public const string BarNpcWords="如果需要补给和装备,可以去我身后找商人购买";
    public const string WeaponNpcWords = "嘘!低头,别看我,有什么要的就说出来.";
	public const string DragNpcWords="我是药店商人,有什么需要吗?";


	public static string UpdateQuest(int id,int count){
		switch (id) {
		case 1:
			if (count < 10) {
				return "任务：\n你已经杀死了" + count + "/10只小狼\n\n奖励:\n1000金币";
			} else {
				Bar_Npc.isDone = true;
				return QuestComplete;
			}
			break;
		case 2:
			if (count < 5) {
				return "任务：\n你已经杀死了" + count + "/5只狼人\n\n奖励:\n小HP药剂X2";
			} else {
				IBCheckPoint.isDone = true;
				return QuestComplete;
			}
			break;
		}
		return null;
	}
}

