using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderAdded : MonoBehaviour
{
    public GameManager GameManager;

    public List<Order> allOrders;
    // 0 - ������� ������ � - ������ �����
    // 1 - ������� ������ � - ������ �����
    // 2 - ������� ������ � - ������ �����
    // 3 - ������ � ������� ����
    // 4 - ������ � ��������� ����
    // 5 - ������ ������������ ����
    // 6 - ������ ������������ � ����
    // 7 - ������ ������������ � ����
    // 8 - ������ ������������ � ����
    // 9 - ���������� - ������ ����� 
    // 10 - ������ ����� ����
    // 11 - ������� ��������� ����
    // 12 - ������ ������ ����
    // 13 - ������ � ������� ����
    // 14 - ������ ������ ����
    // 15 - �������� ����
    // 16 - ������ ��������� ����
    // 17 - ������ ��������� � ����
    // 18 - ������ ��������� � ����
    // 19 - ������ ��������� � ����
    // 20 - ���������� � ����� ����
    // 21 - ������ ��������� ����
    // 22 - ������ ��������� � ����
    // 23 - ������ ��������� � ����
    // 24 - ������ ��������� � ����
    // 25 - ������ � ������ ����
    // 26 - ������ ���� 
    // 27 - ������ � ����
    // 28 - ������ � ����
    // 29 - ������ � ����
    // 30 - ������ ������� ��� ����
    // 31 - ������ � ����� ����
    // 32 - ������ ����
    // 33 - ������ � ����
    // 34 - ������ � ����
    // 35 - ������ � ����
    // 36 - ������� ����
    // 37 - ����� ����
    // 38 - ������ ������ ����
    // 39 - ������ ����� ����
    // 40 - �������������� ����
    // 41 - �������������� ������� ����
    // 42 - ���� �������������� ����
    // 43 - ���� �������������� � ����
    // 44 - ���� �������������� � ����
    // 45 - ���� �������������� � ����
    // 46 - ������ ��������� ����
    // 47 - ������ ��������� � ����
    // 48 - ������ ��������� � ����
    // 49 - ������ ��������� � ����
    // 50 - ������ ������
    // 51 - ������ ������ �
    // 52 - ������ ������ �
    // 53 - ������ ������ �

    public void RefreshOrders(List<Order> orders)
    {
        if (GameManager.saving.tomatOpen) 
        {
            orders.Add(allOrders[4]);// 4 - ������ � ���������
        }

        if (GameManager.saving.saladOpen)
        {
            orders.Add(allOrders[3]);// 3 - ������ � �������
            orders.Add(allOrders[40]);// 40 - �������������� 
        }

        if (GameManager.saving.pikuliOpen) 
        {
            orders.Add(allOrders[12]);// 12 - ������ ������
        }

        if (GameManager.saving.mushroomsOpen)
        {
            orders.Add(allOrders[13]);// 13 - ������ � �������
        }

        if (GameManager.saving.cheeseOpen)    
        {
            orders.Add(allOrders[20]);// 20 - ������ � ����� 
            orders.Add(allOrders[30]);// 30 - ������ ������� ���
        }

        if (GameManager.saving.perecOpen) 
        {
            orders.Add(allOrders[25]);// 25 - ������ � ������
        }

        if (GameManager.saving.onionOpen)
        {
            orders.Add(allOrders[31]);// 31 - ������ � �����
        }
        if (GameManager.saving.saladOpen && GameManager.saving.tomatOpen)
        {
            orders.Add(allOrders[5]);// 5 - ������ ������������
            orders.Add(allOrders[6]);// 6 - ������ ������������ �
            orders.Add(allOrders[7]);// 7 - ������ ������������ �
            orders.Add(allOrders[8]);// 8 - ������ ������������ �
        }
        if (GameManager.saving.onionOpen && GameManager.saving.saladOpen)
        {
            orders.Add(allOrders[10]);// 10 - ������ �����
        }
        if (GameManager.saving.pikuliOpen && GameManager.saving.mushroomsOpen)
        {
            orders.Add(allOrders[11]);// 11 - ������� ���������     
        }
        if (GameManager.saving.pikuliOpen && GameManager.saving.onionOpen)
        {
            orders.Add(allOrders[14]);// 14 - ������ ������   
        }
        if (GameManager.saving.onionOpen && GameManager.saving.mushroomsOpen)
        {
            orders.Add(allOrders[15]);// 15 - ��������
        }
        if (GameManager.saving.mushroomsOpen && GameManager.saving.onionOpen && GameManager.saving.saladOpen)
        {
            orders.Add(allOrders[16]);// 16 - ������ ��������� 
            orders.Add(allOrders[17]);// 17 - ������ ��������� �
            orders.Add(allOrders[18]);// 18 - ������ ��������� � 
            orders.Add(allOrders[19]);// 19 - ������ ��������� �
        }
        if (GameManager.saving.perecOpen && GameManager.saving.tomatOpen)
        {
            orders.Add(allOrders[21]);// 21 - ������ ���������
            orders.Add(allOrders[22]);// 22 - ������ ��������� �
            orders.Add(allOrders[23]);// 23 - ������ ��������� �
            orders.Add(allOrders[24]);// 24 - ������ ��������� �
        }
        if (GameManager.saving.cheeseOpen && GameManager.saving.saladOpen && GameManager.saving.pikuliOpen)
        {
            orders.Add(allOrders[26]);// 26 - ������
            orders.Add(allOrders[27]);// 27 - ������ �
            orders.Add(allOrders[28]);// 28 - ������ �
            orders.Add(allOrders[29]);// 29 - ������ �
        }
        if (GameManager.saving.cheeseOpen && GameManager.saving.saladOpen && GameManager.saving.tomatOpen)
        { 
            orders.Add(allOrders[32]);// 32 - ������
            orders.Add(allOrders[33]);// 33 - ������ �
            orders.Add(allOrders[34]);// 34 - ������ �
            orders.Add(allOrders[35]);// 35 - ������ �
        }
        if (GameManager.saving.pikuliOpen && GameManager.saving.onionOpen && GameManager.saving.cheeseOpen && GameManager.saving.saladOpen)
        {
            orders.Add(allOrders[36]);// 36 - �������
        }
        if (GameManager.saving.pikuliOpen && GameManager.saving.tomatOpen && GameManager.saving.cheeseOpen)
        {
            orders.Add(allOrders[37]);// 37 - �����
        }
        if (GameManager.saving.pikuliOpen && GameManager.saving.onionOpen && GameManager.saving.mushroomsOpen)
        {
            orders.Add(allOrders[38]);// 38 - ������ ������
        }
        if (GameManager.saving.onionOpen && GameManager.saving.cheeseOpen)
        {
            orders.Add(allOrders[39]);// 39 - ������ ����� 
        }
        if (GameManager.saving.mushroomsOpen && GameManager.saving.perecOpen && GameManager.saving.pikuliOpen && GameManager.saving.tomatOpen && GameManager.saving.saladOpen)
        { 
            orders.Add(allOrders[42]);// 42 - ���� ��������������
            orders.Add(allOrders[43]);// 43 - ���� �������������� � 
            orders.Add(allOrders[44]);// 44 - ���� �������������� � 
            orders.Add(allOrders[45]);// 45 - ���� �������������� � 
        }
        if (GameManager.saving.mushroomsOpen && GameManager.saving.perecOpen)
        {
            orders.Add(allOrders[46]);// 46 - ������ ���������
            orders.Add(allOrders[47]);// 47 - ������ ��������� �
            orders.Add(allOrders[48]);// 48 - ������ ��������� �
            orders.Add(allOrders[49]);// 49 - ������ ��������� �
        }
        if (GameManager.saving.cheeseOpen && GameManager.saving.perecOpen && GameManager.saving.tomatOpen)
        {
            orders.Add(allOrders[50]);// 50 - ������ ������
            orders.Add(allOrders[51]);// 51 - ������ ������ �
            orders.Add(allOrders[52]);// 52 - ������ ������ �
            orders.Add(allOrders[53]);// 53 - ������ ������ �
        }
        if (GameManager.saving.saladOpen && GameManager.saving.tomatOpen && GameManager.saving.pikuliOpen)
        {
            orders.Add(allOrders[41]);// 41 - �������������� �������
        }
    }
    public void DeleteOrders(List<Order> orders)
    {
        orders.Clear();
    }
    public void AddDefaultOrders(List<Order> orders)
    {
        orders.Add(allOrders[0]);// 0 - ������� ������ � - ������ �����
        orders.Add(allOrders[1]);// 1 - ������� ������ � - ������ �����
        orders.Add(allOrders[2]);// 2 - ������� ������ � - ������ �����
        orders.Add(allOrders[9]);// 9 - ����������
    }
}
