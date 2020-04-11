function MapCalc()
{
    var _loc1 = _global;
    var _loc2;
    _loc2 = _loc1.DegrArr[_loc1.year] - _loc1.DegrArr[_loc1.year - 1];
    DegrR(_loc2);
    if (_loc2 > 0)
    {
        var Melk = int(_loc2 * 0.250000);
        var Plag = int(_loc2 * 0.250000);
        var Sea = int(_loc2 * 0.250000);
        var PrirF = int(_loc2 * 0.120000);
        var PrirL = _loc2 - Sea - Melk - Plag - PrirF;
        ost = ModifMMap(2, 7, Melk);
        _loc1.DegrSeaArr[_loc1.year] = _loc1.DegrSeaArr[_loc1.year - 1] + (Melk - ost);
        Plag = Plag + ost;
        ost = ModifMMap(3, 8, Plag);
        _loc1.DegrLandArr[_loc1.year] = _loc1.DegrLandArr[_loc1.year - 1] + (Plag - ost);
        Sea = Sea + ost;
        ost = ModifMMap(1, 6, Sea);
        _loc1.DegrSeaArr[_loc1.year] = _loc1.DegrSeaArr[_loc1.year] + (Sea - ost);
        PrirF = PrirF + ost;
        ost = ModifMMap(4, 9, PrirF);
        _loc1.DegrLandArr[_loc1.year] = _loc1.DegrLandArr[_loc1.year] + (PrirF - ost);
        PrirL = PrirL + ost;
        ost = ModifMMap(14, 9, PrirL);
        _loc1.DegrLandArr[_loc1.year] = _loc1.DegrLandArr[_loc1.year] + (PrirL - ost);
        trace ("ost_for_forest=" + ost);
        if (ost > 0)
        {
            ost = ModifMMap(4, 9, ost);
        } // end if
        trace ("ost_all=" + ost);
        if (ost > 0)
        {
            AddTextInf("<br><b>" + MSG_endprir + "</b>");
            MC_msg.MSG_bot.text = MSG_endprir;
            _loc1.is_over = true;
        } // end if
    }
    else
    {
        _loc2 = Math.abs(_loc2);
        var Melk = int(_loc2 * 0.250000);
        var Plag = int(_loc2 * 0.250000);
        var Sea = int(_loc2 * 0.250000);
        var PrirF = int(_loc2 * 0.120000);
        var PrirL = _loc2 - Sea - Melk - Plag - PrirF;
        ost = ModifMMap(7, 2, int(Math.abs(Melk)));
        trace ("Melk=" + Melk + "  ost=" + ost);
        _loc1.DegrSeaArr[_loc1.year] = _loc1.DegrSeaArr[_loc1.year - 1] - (Melk - ost);
        Plag = Plag + ost;
        ost = ModifMMap(8, 3, int(Math.abs(Plag)));
        _loc1.DegrLandArr[_loc1.year] = _loc1.DegrLandArr[_loc1.year - 1] - (Plag - ost);
        Sea = Sea + ost;
        ost = ModifMMap(6, 1, int(Math.abs(Sea)));
        _loc1.DegrSeaArr[_loc1.year] = _loc1.DegrSeaArr[_loc1.year] - (Sea - ost);
        PrirF = PrirF + ost;
        ost = ModifMMap(9, 4, int(Math.abs(PrirF)));
        _loc1.DegrLandArr[_loc1.year] = _loc1.DegrLandArr[_loc1.year] - (PrirF - ost);
        PrirL = PrirL + ost;
        ost = ModifMMap(9, 14, int(Math.abs(PrirL)));
        _loc1.DegrLandArr[_loc1.year] = _loc1.DegrLandArr[_loc1.year] - (PrirL - ost);
    } // end else if
    var _loc3 = (_loc1.CapPar5[_loc1.year] - _loc1.CapPar5[_loc1.year - 1]) / _loc1.TurUCap;
    TurR(_loc3);
    if (_loc3 > 0)
    {
        var Plag = int(_loc3 * 0.250000);
        var Prir = _loc3 - Plag;
        ost = ModifMMap(3, 12, Plag);
        Prir = Prir + ost;
        ost = ModifMMap(4, 13, Prir);
        if (ost > 0)
        {
            _loc1.is_over = true;
            AddTextInf("<br><b>" + MSG_endres + "</b>");
            MC_msg.MSG_bot.text = MSG_endres;
        } // end if
    }
    else
    {
        var Plag = int(_loc3 * 0.250000);
        var Prir = _loc3 - Plag;
        ost = ModifMMap(12, 3, int(Math.abs(Plag)));
        Prir = Prir + ost;
        ost = ModifMMap(13, 4, int(Math.abs(Prir)));
    } // end else if
    var Agro = (_loc1.CapPar4[_loc1.year] - _loc1.CapPar4[_loc1.year - 1]) / _loc1.AgroUCap;
    AgroR(Agro);
    if (Agro > 0)
    {
        ost = ModifMMap(14, 5, int(Agro));
        ost = ModifMMap(4, 5, int(Math.abs(ost)));
        if (ost > 0)
        {
            _loc1.is_over = true;
            AddTextInf("<br><b>" + MSG_endres + "</b>");
            MC_msg.MSG_bot.text = MSG_endres;
        } // end if
    }
    else
    {
        Flug = int(Agro * 0.500000);
        Fles = Agro - Flug;
        ost = ModifMMap(5, 14, int(Math.abs(Flug)));
        Fles = Fles + ost;
        ost = ModifMMap(5, 4, int(Math.abs(Fles)));
    } // end else if
    var Ship = (_loc1.CapPar2[_loc1.year] - _loc1.CapPar2[_loc1.year - 1]) / _loc1.ShipUCap;
    FishR(Ship);
    if (Ship > 0)
    {
        var Sea = int(Ship * 0.750000);
        ost = ModifMMap(1, 10, int(Sea));
        Melk = Ship - Sea + ost;
        ost = ModifMMap(2, 11, int(Melk));
        if (ost > 0)
        {
            _loc1.is_over = true;
            AddTextInf("<br><b>" + MSG_endres + "</b>");
            MC_msg.MSG_bot.text = MSG_endres;
        } // end if
    }
    else
    {
        var Sea = int(Ship * 0.750000);
        var Melk = int(Ship) - Sea;
        ost = ModifMMap(10, 1, int(Math.abs(Sea)));
        Melk = Melk + ost;
        ost = ModifMMap(11, 2, int(Math.abs(Melk)));
    } // end else if
    CbkR(_loc1.CapPar1[_loc1.year]);
    if (_loc1.PribPar1[_loc1.year] < 0)
    {
        AddTextInf(ALT_cbkMC + ": " + MSG_ubi);
    } // end if
    if (_loc1.PribPar2[_loc1.year] < 0)
    {
        AddTextInf(ALT_ribMC + ": " + MSG_ubi);
    } // end if
    AcvaFermR(_loc1.CapPar3[_loc1.year]);
    if (_loc1.PribPar3[_loc1.year] < 0)
    {
        AddTextInf(ALT_aqMC + ": " + MSG_ubi);
    } // end if
    if (_loc1.PribPar4[_loc1.year] < 0)
    {
        AddTextInf(ALT_agroMC + ": " + MSG_ubi);
    } // end if
    if (_loc1.PribPar5[_loc1.year] < 0)
    {
        AddTextInf(ALT_turMC + ": " + MSG_ubi);
    } // end if
    BioClnR(_loc1.CapPar7[_loc1.year]);
    ChemClnR(_loc1.CapPar6[_loc1.year]);
    _loc1.QuolOcrSr[_loc1.year] = QuolOcrSrCalc();
    _loc1.HDev[_loc1.year] = HDevCalc();
    _loc1.ProdLive[_loc1.year] = int(75 * _loc1.QuolOcrSr[_loc1.year]);
    HDevR();    
    OcrSrR();
    TestTime();
    MC_msg.Year_tm.text = _root.MSG_year + " " + _loc1.year + " " + _root.MSG_of + " " + _loc1.endYear;
    MC_msg.I1.text = _loc1.Budt[_loc1.year];
    MC_msg.I2.text = _loc1.FishAm[_loc1.year];
    MC_msg.I3.text = _loc1.NasAm[_loc1.year];
    MC_msg.U1.text = _loc1.DohSumNDN[_loc1.year];
    MC_msg.U2.text = _loc1.QuolOcrSr[_loc1.year];
    MC_msg.U3.text = _loc1.HDev[_loc1.year];
    EndGame();
} // End of the function



function ModifMMap(old_index, new_index, count)
{
    var _loc1 = count;
    var _loc2 = old_index;
    var _loc3 = _global;
    while (_loc1 > 0)
    {
        AnMMap(_loc2);
        if (_loc3.OldArr.length == 0)
        {
            break;
        }
        else
        {
            RandMMap(_loc2, new_index);
        } // end else if
        --_loc1;
    } // end while
    return (_loc1);
} // End of the function

function AnMMap(old_index)
{
    var _loc1 = old_index;
    _global.OldArr = new Array(0);
    for (row = 0; row < numMapY; row++)
    {
        for (column = 0; column < numMapX; column++)
        {
            if (MapArr[column][row] == _loc1)
            {
                OldArr.push([column, row]);
            } // end if
        } // end of for
    } // end of for
} // End of the function

function RandMMap(old_index, new_index)
{
    numb = int(Math.random() * _global.OldArr.length);
    ++_global.all_num;
    column = _global.OldArr[numb][0];
    row = _global.OldArr[numb][1];
    MapArr[column][row] = new_index;
    eval(base + "." + column + "." + row + "." + "icon").gotoAndStop(new_index);
} // End of the function


function SetMMap()
{
    for (row = 0; row < numMapY; row++)
    {
        for (column = 0; column < numMapX; column++)
        {
            if (row == 0)
            {
                eval(base).createEmptyMovieClip(column, column);
            } // end if
            eval(base + "." + column).createEmptyMovieClip(row, row);
            eval(base + "." + column + "." + row).attachMovie("icons", "icon", 0);
            eval(base + "." + column + "." + row)._x = row * 22 - 209;
            eval(base + "." + column + "." + row)._y = column * 22 - 209;
            eval(base + "." + column + "." + row)._height = 22;
            eval(base + "." + column + "." + row)._width = 22;
            eval(base + "." + column + "." + row + "." + "icon").gotoAndStop(MapArr[column][row]);
        } // end of for
    } // end of for
} // End of the function