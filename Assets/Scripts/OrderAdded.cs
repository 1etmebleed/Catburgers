using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderAdded : MonoBehaviour
{
    public GameManager GameManager;

    public List<Order> allOrders;
    // 0 - Дешёвый бургер К - открыт сразу
    // 1 - Дешёвый бургер М - открыт сразу
    // 2 - Дешёвый бургер Г - открыт сразу
    // 3 - Бургер с салатом ЕСТЬ
    // 4 - бургер с помидором ЕСТЬ
    // 5 - Бургер классический ЕСТЬ
    // 6 - Бургер классический К ЕСТЬ
    // 7 - Бургер классический Г ЕСТЬ
    // 8 - Бургер классический М ЕСТЬ
    // 9 - Бомжбургер - открыт сразу 
    // 10 - Бургер лучок ЕСТЬ
    // 11 - Грибной деликатес ЕСТЬ
    // 12 - Бургер пикуля ЕСТЬ
    // 13 - Бургер с грибами ЕСТЬ
    // 14 - Сочный бургер ЕСТЬ
    // 15 - Суперфуд ЕСТЬ
    // 16 - Бургер пикантный ЕСТЬ
    // 17 - Бургер пикантный К ЕСТЬ
    // 18 - Бургер пикантный М ЕСТЬ
    // 19 - Бургер пикантный Г ЕСТЬ
    // 20 - бомжбургер с сыром ЕСТЬ
    // 21 - Бургер азиатский ЕСТЬ
    // 22 - Бургер азиатский М ЕСТЬ
    // 23 - Бургер азиатский Г ЕСТЬ
    // 24 - Бургер азиатский К ЕСТЬ
    // 25 - бургер с перцем ЕСТЬ
    // 26 - Гурман ЕСТЬ 
    // 27 - Гурман К ЕСТЬ
    // 28 - Гурман М ЕСТЬ
    // 29 - Гурман Г ЕСТЬ
    // 30 - Бургер двойной сыр ЕСТЬ
    // 31 - Бургер с луком ЕСТЬ
    // 32 - Канеки ЕСТЬ
    // 33 - Канеки М ЕСТЬ
    // 34 - Канеки К ЕСТЬ
    // 35 - Канеки Г ЕСТЬ
    // 36 - Великан ЕСТЬ
    // 37 - Артем ЕСТЬ
    // 38 - Бургер гигант ЕСТЬ
    // 39 - Бургер башня ЕСТЬ
    // 40 - Вегетарианский ЕСТЬ
    // 41 - Вегетарианский средний ЕСТЬ
    // 42 - Мега вегетарианский ЕСТЬ
    // 43 - Мега вегетарианский Г ЕСТЬ
    // 44 - Мега вегетарианский К ЕСТЬ
    // 45 - Мега вегетарианский М ЕСТЬ
    // 46 - Бургер пикантный ЕСТЬ
    // 47 - Бургер пикантный Г ЕСТЬ
    // 48 - Бургер пикантный К ЕСТЬ
    // 49 - Бургер пикантный М ЕСТЬ
    // 50 - Бургер браток
    // 51 - Бургер браток К
    // 52 - Бургер браток Г
    // 53 - Бургер браток М

    public void RefreshOrders(List<Order> orders)
    {
        if (GameManager.saving.tomatOpen) 
        {
            orders.Add(allOrders[4]);// 4 - бургер с помидором
        }

        if (GameManager.saving.saladOpen)
        {
            orders.Add(allOrders[3]);// 3 - бургер с салатом
            orders.Add(allOrders[40]);// 40 - Вегетарианский 
        }

        if (GameManager.saving.pikuliOpen) 
        {
            orders.Add(allOrders[12]);// 12 - Бургер пикуля
        }

        if (GameManager.saving.mushroomsOpen)
        {
            orders.Add(allOrders[13]);// 13 - Бургер с грибами
        }

        if (GameManager.saving.cheeseOpen)    
        {
            orders.Add(allOrders[20]);// 20 - бургер с сыром 
            orders.Add(allOrders[30]);// 30 - Бургер двойной сыр
        }

        if (GameManager.saving.perecOpen) 
        {
            orders.Add(allOrders[25]);// 25 - бургер с перцем
        }

        if (GameManager.saving.onionOpen)
        {
            orders.Add(allOrders[31]);// 31 - Бургер с луком
        }
        if (GameManager.saving.saladOpen && GameManager.saving.tomatOpen)
        {
            orders.Add(allOrders[5]);// 5 - Бургер классический
            orders.Add(allOrders[6]);// 6 - Бургер классический К
            orders.Add(allOrders[7]);// 7 - Бургер классический Г
            orders.Add(allOrders[8]);// 8 - Бургер классический М
        }
        if (GameManager.saving.onionOpen && GameManager.saving.saladOpen)
        {
            orders.Add(allOrders[10]);// 10 - Бургер лучок
        }
        if (GameManager.saving.pikuliOpen && GameManager.saving.mushroomsOpen)
        {
            orders.Add(allOrders[11]);// 11 - Грибной деликатес     
        }
        if (GameManager.saving.pikuliOpen && GameManager.saving.onionOpen)
        {
            orders.Add(allOrders[14]);// 14 - Сочный бургер   
        }
        if (GameManager.saving.onionOpen && GameManager.saving.mushroomsOpen)
        {
            orders.Add(allOrders[15]);// 15 - Суперфуд
        }
        if (GameManager.saving.mushroomsOpen && GameManager.saving.onionOpen && GameManager.saving.saladOpen)
        {
            orders.Add(allOrders[16]);// 16 - Бургер пикантный 
            orders.Add(allOrders[17]);// 17 - Бургер пикантный К
            orders.Add(allOrders[18]);// 18 - Бургер пикантный М 
            orders.Add(allOrders[19]);// 19 - Бургер пикантный Г
        }
        if (GameManager.saving.perecOpen && GameManager.saving.tomatOpen)
        {
            orders.Add(allOrders[21]);// 21 - Бургер азиатский
            orders.Add(allOrders[22]);// 22 - Бургер азиатский М
            orders.Add(allOrders[23]);// 23 - Бургер азиатский Г
            orders.Add(allOrders[24]);// 24 - Бургер азиатский К
        }
        if (GameManager.saving.cheeseOpen && GameManager.saving.saladOpen && GameManager.saving.pikuliOpen)
        {
            orders.Add(allOrders[26]);// 26 - Гурман
            orders.Add(allOrders[27]);// 27 - Гурман К
            orders.Add(allOrders[28]);// 28 - Гурман М
            orders.Add(allOrders[29]);// 29 - Гурман Г
        }
        if (GameManager.saving.cheeseOpen && GameManager.saving.saladOpen && GameManager.saving.tomatOpen)
        { 
            orders.Add(allOrders[32]);// 32 - Канеки
            orders.Add(allOrders[33]);// 33 - Канеки М
            orders.Add(allOrders[34]);// 34 - Канеки К
            orders.Add(allOrders[35]);// 35 - Канеки Г
        }
        if (GameManager.saving.pikuliOpen && GameManager.saving.onionOpen && GameManager.saving.cheeseOpen && GameManager.saving.saladOpen)
        {
            orders.Add(allOrders[36]);// 36 - Великан
        }
        if (GameManager.saving.pikuliOpen && GameManager.saving.tomatOpen && GameManager.saving.cheeseOpen)
        {
            orders.Add(allOrders[37]);// 37 - Артем
        }
        if (GameManager.saving.pikuliOpen && GameManager.saving.onionOpen && GameManager.saving.mushroomsOpen)
        {
            orders.Add(allOrders[38]);// 38 - Бургер гигант
        }
        if (GameManager.saving.onionOpen && GameManager.saving.cheeseOpen)
        {
            orders.Add(allOrders[39]);// 39 - Бургер башня 
        }
        if (GameManager.saving.mushroomsOpen && GameManager.saving.perecOpen && GameManager.saving.pikuliOpen && GameManager.saving.tomatOpen && GameManager.saving.saladOpen)
        { 
            orders.Add(allOrders[42]);// 42 - Мега вегетарианский
            orders.Add(allOrders[43]);// 43 - Мега вегетарианский Г 
            orders.Add(allOrders[44]);// 44 - Мега вегетарианский К 
            orders.Add(allOrders[45]);// 45 - Мега вегетарианский М 
        }
        if (GameManager.saving.mushroomsOpen && GameManager.saving.perecOpen)
        {
            orders.Add(allOrders[46]);// 46 - Бургер пикантный
            orders.Add(allOrders[47]);// 47 - Бургер пикантный Г
            orders.Add(allOrders[48]);// 48 - Бургер пикантный К
            orders.Add(allOrders[49]);// 49 - Бургер пикантный М
        }
        if (GameManager.saving.cheeseOpen && GameManager.saving.perecOpen && GameManager.saving.tomatOpen)
        {
            orders.Add(allOrders[50]);// 50 - Бургер браток
            orders.Add(allOrders[51]);// 51 - Бургер браток К
            orders.Add(allOrders[52]);// 52 - Бургер браток Г
            orders.Add(allOrders[53]);// 53 - Бургер браток М
        }
        if (GameManager.saving.saladOpen && GameManager.saving.tomatOpen && GameManager.saving.pikuliOpen)
        {
            orders.Add(allOrders[41]);// 41 - Вегетарианский средний
        }
    }
    public void DeleteOrders(List<Order> orders)
    {
        orders.Clear();
    }
    public void AddDefaultOrders(List<Order> orders)
    {
        orders.Add(allOrders[0]);// 0 - Дешёвый бургер К - открыт сразу
        orders.Add(allOrders[1]);// 1 - Дешёвый бургер М - открыт сразу
        orders.Add(allOrders[2]);// 2 - Дешёвый бургер Г - открыт сразу
        orders.Add(allOrders[9]);// 9 - Бомжбургер
    }
}
