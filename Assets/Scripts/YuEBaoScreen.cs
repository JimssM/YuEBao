using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class YuEBaoScreen : MonoBehaviour
{
    //rootVisualElement取得根视觉元素进行UI元素的操作
    private VisualElement rootVisualElement;
    //yuEBaoData获取相关数据
    public YuEBaoData yuEBaoData;

    private void Awake()
    {
        //第一次打开软件时跳过读取数据，否则读取以往数据
        if (!PlayerPrefs.HasKey("first"))
            PlayerPrefs.SetInt("first", 1);
        else
            yuEBaoData.YuEBaoStats.Load();
        
        //获取根视觉元素
        rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        var main = rootVisualElement.Q("Main");
        main.Clear();

        var yuEBaoPanel = new YuEBaoPanel(yuEBaoData);
        main.Add(yuEBaoPanel);
    }
    
    private void Start()
    {
        //加载数据
        if (PlayerPrefs.HasKey("first"))
            yuEBaoData.YuEBaoStats.Load();
    }
}