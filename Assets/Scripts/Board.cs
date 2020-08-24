﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board
{
    public int columns;
    public int rows;

   public List<List<int>> array2d;
};

// "board" : [[4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4],
// [4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4],
// [4, 4, 4, 4, 4, 4, 4, 4, 14, 14, 14, 14, 14, 4, 4, 4, 4, 4, 4, 4],
// [4, 4, 15, 15, 15, 14, 14, 14, 14, 14, 14, 14, 4, 4, 4, 4, 4, 4, 4, 4],
// [4, 4, 15, 15, 15, 14, 5, 5, 5, 5, 5, 14, 4, 4, 15, 15, 15, 4, 4, 4],
// [14, 4, 4, 4, 4, 14, 5, 5, 5, 5, 5, 14, 4, 4, 15, 15, 15, 4, 4, 4],
// [3, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 4, 4, 4, 4, 4, 4, 4],
// [3, 3, 3, 3, 4, 4, 14, 5, 5, 5, 5, 5, 14, 4, 4, 4, 4, 4, 4, 4],
// [2, 2, 2, 3, 3, 4, 14, 5, 5, 5, 5, 5, 14, 14, 4, 4, 4, 4, 4, 4],
// [1, 1, 1, 1, 2, 3, 3, 14, 14, 14, 14, 14, 14, 4, 4, 4, 4, 4, 4, 4],
// [1, 1, 1, 1, 1, 2, 3, 3, 3, 14, 4, 4, 4, 4, 4, 4, 13, 4, 4, 4],
// [1, 1, 1, 1, 1, 11, 3, 3, 3, 3, 14, 4, 4, 4, 4, 4, 4, 4, 4, 4],
// [1, 1, 1, 1, 2, 2, 3, 3, 3, 3, 14, 14, 4, 4, 4, 4, 4, 4, 4, 4],
// [1, 1, 1, 1, 2, 3, 3, 3, 3, 3, 14, 14, 14, 4, 4, 4, 4, 4, 4, 4],
// [1, 1, 1, 1, 2, 2, 3, 3, 3, 3, 14, 14, 14, 14, 14, 15, 15, 15, 4, 4],
// [1, 10, 1, 1, 1, 2, 2, 12, 3, 3, 3, 14, 14, 14, 14, 15, 15, 15, 4, 4],
// [1, 1, 1, 1, 1, 2, 2, 3, 3, 3, 3, 14, 14, 14, 4, 4, 4, 4, 4, 4],
// [1, 1, 1, 1, 1, 15, 15, 15, 3, 3, 3, 3, 14, 14, 4, 4, 4, 4, 14, 14],
// [1, 1, 1, 1, 2, 15, 15, 15, 3, 3, 3, 3, 14, 4, 4, 4, 14, 4, 14, 14],
// [1, 1, 1, 1, 2, 3, 3, 3, 3, 3, 3, 3, 14, 4, 4, 14, 14, 14, 14, 14]]

/*
10 - Кораблик
11 - маленький кораблик
1 - Outer Waters
2 - Middle Waters (Чуть светлее )
3 - Inner Waters (Вода у берега)
4 - Forest 
5 - Agro cultura

15 - FActory
14 - planes (луга)
13 - туризм
12 - туризм на пляже


*/
