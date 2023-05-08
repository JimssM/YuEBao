using System;
using UnityEngine;

[System.Serializable]
public class YuEBaoStats
{
    //八项基本数据
    public float deposit; //存款
    public float amount; //存、取款操作单位金额
    public float todayProfit; //今日收益
    public float todayRate; //今日利率
    public float yesterdayProfit; //昨日收益
    public float yesterdayRate; //昨日收益
    public float avgProfit; //七日平均收益
    public float avgRate; //七日平均利率

    //用于计算七日平均收益
    public float profit1;
    public float profit2;
    public float profit3;
    public float profit4;
    public float profit5;
    public float profit6;
    public float profit7;

    //用于计算七日平均利率
    public float rate1;
    public float rate2;
    public float rate3;
    public float rate4;
    public float rate5;
    public float rate6;
    public float rate7;

    //用于生成下一天的数据
    public void Generate()
    {
        profit7 = profit6;
        profit6 = profit5;
        profit5 = profit4;
        profit4 = profit3;
        profit3 = profit2;
        profit2 = profit1;

        rate7 = rate6;
        rate6 = rate5;
        rate5 = rate4;
        rate4 = rate3;
        rate3 = rate2;
        rate2 = rate1;

        yesterdayProfit = todayProfit;
        yesterdayRate = todayRate;

        Today();

        profit1 = todayProfit;
        rate1 = todayRate;

        deposit += todayProfit;

        avgProfit = (profit1 + profit2 + profit3 + profit4 + profit5 + profit6 + profit7) / 7;
        avgRate = (rate1 + rate2 + rate3 + rate4 + rate5 + rate6 + rate7) / 7;
    }

    //生成今天的利率和收益
    public void Today()
    {
        todayRate = UnityEngine.Random.Range(1.0f, 2.0f);
        todayProfit = deposit * todayRate / 100;
    }

    //用于退出软件时保存数据
    public void Save()
    {
        PlayerPrefs.SetFloat("deposit", deposit);
        PlayerPrefs.SetFloat("amount", amount);
        PlayerPrefs.SetFloat("todayProfit", todayProfit);
        PlayerPrefs.SetFloat("todayRate", todayRate);
        PlayerPrefs.SetFloat("yesterdayProfit", yesterdayProfit);
        PlayerPrefs.SetFloat("yesterdayRate", yesterdayRate);
        PlayerPrefs.SetFloat("avgProfit", avgProfit);
        PlayerPrefs.SetFloat("avgRate", avgRate);

        PlayerPrefs.SetFloat("profit1", profit1);
        PlayerPrefs.SetFloat("profit2", profit2);
        PlayerPrefs.SetFloat("profit3", profit3);
        PlayerPrefs.SetFloat("profit4", profit4);
        PlayerPrefs.SetFloat("profit5", profit5);
        PlayerPrefs.SetFloat("profit6", profit6);
        PlayerPrefs.SetFloat("profit7", profit7);

        PlayerPrefs.SetFloat("rate1", rate1);
        PlayerPrefs.SetFloat("rate2", rate2);
        PlayerPrefs.SetFloat("rate3", rate3);
        PlayerPrefs.SetFloat("rate4", rate4);
        PlayerPrefs.SetFloat("rate5", rate5);
        PlayerPrefs.SetFloat("rate6", rate6);
        PlayerPrefs.SetFloat("rate7", rate7);
    }

    //用于打开软件时加载数据
    public void Load()
    {
        deposit = PlayerPrefs.GetFloat("deposit");
        amount = PlayerPrefs.GetFloat("amount");
        todayProfit = PlayerPrefs.GetFloat("todayProfit");
        todayRate = PlayerPrefs.GetFloat("todayRate");
        yesterdayProfit = PlayerPrefs.GetFloat("yesterdayProfit");
        yesterdayRate = PlayerPrefs.GetFloat("yesterdayRate");
        avgProfit = PlayerPrefs.GetFloat("avgProfit");
        avgRate = PlayerPrefs.GetFloat("avgRate");

        profit1 = PlayerPrefs.GetFloat("profit1");
        profit2 = PlayerPrefs.GetFloat("profit2");
        profit3 = PlayerPrefs.GetFloat("profit3");
        profit4 = PlayerPrefs.GetFloat("profit4");
        profit5 = PlayerPrefs.GetFloat("profit5");
        profit6 = PlayerPrefs.GetFloat("profit6");
        profit7 = PlayerPrefs.GetFloat("profit7");

        rate1 = PlayerPrefs.GetFloat("rate1");
        rate2 = PlayerPrefs.GetFloat("rate2");
        rate3 = PlayerPrefs.GetFloat("rate3");
        rate4 = PlayerPrefs.GetFloat("rate4");
        rate5 = PlayerPrefs.GetFloat("rate5");
        rate6 = PlayerPrefs.GetFloat("rate6");
        rate7 = PlayerPrefs.GetFloat("rate7");
    }

    //用于重置软件存储的所有数据
    public void Restart()
    {
        deposit = 0;
        amount = 100;
        todayProfit = 0;
        todayRate = 0;
        yesterdayProfit = 0;
        yesterdayRate = 0;
        avgProfit = 0;
        avgRate = 0;

        profit1 = 0;
        profit2 = 0;
        profit3 = 0;
        profit4 = 0;
        profit5 = 0;
        profit6 = 0;
        profit7 = 0;

        rate1 = 0;
        rate2 = 0;
        rate3 = 0;
        rate4 = 0;
        rate5 = 0;
        rate6 = 0;
        rate7 = 0;
    }
}