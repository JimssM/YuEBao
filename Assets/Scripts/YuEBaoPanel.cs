using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class YuEBaoPanel : VisualElement
{
    //templateContainer用于从代码初始化UI界面
    readonly TemplateContainer templateContainer;
    //Amount记录在代码中要修改的UI元素
    private readonly List<Label> Amount;

    public new class UxmlFactory : UxmlFactory<YuEBaoPanel>
    {
    }

    //初始化UI界面
    public YuEBaoPanel()
    {
        templateContainer = Resources.Load<VisualTreeAsset>("Background").Instantiate();
        templateContainer.style.flexGrow = 1.0f;
        this.style.flexGrow = 1.0f;

        hierarchy.Add(templateContainer);
    }

    //利用YuEBaoData中存放的数据更新UI界面
    public YuEBaoPanel(YuEBaoData yuEBaoData) : this()
    {
        userData = yuEBaoData;

        Amount = templateContainer.Query<Label>("Amount").ToList();

        UpdateYuEBaoStats();

        //添加需要与UI进行的交互
        Clickable addLeftClickManipulator = new Clickable(AddLeftClicked);
        Clickable reduceLeftClickManipulator = new Clickable(ReduceLeftClicked);
        Clickable nextdayLeftClickManipulator = new Clickable(nextdayLeftClicked);
        Clickable exitLeftClickManipulator = new Clickable(exitLeftClicked);
        Clickable restartLeftClickManipulator = new Clickable(restartLeftClicked);
        templateContainer.Q("Add").AddManipulator(addLeftClickManipulator);
        templateContainer.Q("Reduce").AddManipulator(reduceLeftClickManipulator);
        templateContainer.Q("NextDay").AddManipulator(nextdayLeftClickManipulator);
        templateContainer.Q("Exit").AddManipulator(exitLeftClickManipulator);
        templateContainer.Q("Restart").AddManipulator(restartLeftClickManipulator);
    }

    //鼠标左键点击按钮重置数据
    private void restartLeftClicked(EventBase obj)
    {
        ((YuEBaoData)userData).YuEBaoStats.Restart();
        UpdateYuEBaoStats();
    }

    //鼠标左键点击按钮退出软件
    private void exitLeftClicked(EventBase obj)
    {
        ((YuEBaoData)userData).YuEBaoStats.Save();
        Application.Quit();
    }

    //鼠标左键点击按钮进入下一天
    private void nextdayLeftClicked(EventBase obj)
    {
        ((YuEBaoData)userData).YuEBaoStats.Generate();
        UpdateYuEBaoStats();
    }

    //鼠标左键点击按钮增加存储金额
    private void AddLeftClicked(EventBase clickEvent)
    {
        ((YuEBaoData)userData).YuEBaoStats.deposit += ((YuEBaoData)userData).YuEBaoStats.amount;
        UpdateYuEBaoStats();
    }

    //鼠标左键点击减少存储金额
    private void ReduceLeftClicked(EventBase clickEvent)
    {
        if(((YuEBaoData)userData).YuEBaoStats.deposit>=100)
            ((YuEBaoData)userData).YuEBaoStats.deposit -= ((YuEBaoData)userData).YuEBaoStats.amount;
        UpdateYuEBaoStats();
    }

    //更新UI的数据
    private void UpdateYuEBaoStats()
    {
        var yuEBaoData = (YuEBaoData)userData;

        Amount[0].text = yuEBaoData.YuEBaoStats.deposit.ToString("f2")+" $";
        Amount[1].text = yuEBaoData.YuEBaoStats.amount.ToString("f0")+" $";
        Amount[2].text= yuEBaoData.YuEBaoStats.todayProfit.ToString("f2")+" $";
        Amount[3].text = yuEBaoData.YuEBaoStats.todayRate.ToString("f2")+" %";
        Amount[4].text = yuEBaoData.YuEBaoStats.yesterdayProfit.ToString("f2")+" $";
        Amount[5].text = yuEBaoData.YuEBaoStats.yesterdayRate.ToString("f2")+" %";
        Amount[6].text = yuEBaoData.YuEBaoStats.avgProfit.ToString("f2")+" $";
        Amount[7].text = yuEBaoData.YuEBaoStats.avgRate.ToString("f2")+" %";
    }
}