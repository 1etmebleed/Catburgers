using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewOrder", menuName = "Orders/Order")]

public class Order : ScriptableObject
{
    [Header("�������� �������:")]
    public string orderName;
    [Header("����������:")]
    [Header("����� �����")]
    [Header("��� ������ ������������")]
    [Header("��� ����� �������")]
    [Header("������ ������� �������")]
    public List<string> components;

    public bool withPotato;

    public Sprite sprite;

    public bool salad;
    public bool tomat;
    public bool cheese;
    public bool pikuli;
    public bool onion;
    public bool perec;
    public bool mushrooms;
    public bool potato;

    
}
