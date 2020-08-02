?// Action script...

// [onClipEvent of sprite 242 in frame 144]
onClipEvent (initialize)
{
    editable = false;
    rowCount = 8;
    changeHandler = "";
}

// [onClipEvent of sprite 130 in frame 177]
onClipEvent (load)
{
    this.startDrag(true);
}

// [Action in Frame 1]
fscommand("fullscreen", "true");
fscommand("showmenu", "false");
fscommand("allowscale", "true");

// [Action in Frame 91]
function InitVars()
{
    var _loc1 = _global;
    _loc1.Budt = new Array();
    _loc1.InvPar1 = new Array();
    _loc1.InvPar2 = new Array();
    _loc1.InvPar3 = new Array();
    _loc1.InvPar4 = new Array();
    _loc1.InvPar5 = new Array();
    _loc1.InvPar6 = new Array();
    _loc1.InvPar7 = new Array();
    _loc1.CapPar1 = new Array();
    _loc1.CapPar2 = new Array();
    _loc1.CapPar3 = new Array();
    _loc1.CapPar4 = new Array();
    _loc1.CapPar5 = new Array();
    _loc1.CapPar6 = new Array();
    _loc1.CapPar7 = new Array();
    _loc1.FPrvPar1 = new Array();
    _loc1.FPrvPar2 = new Array();
    _loc1.FPrvPar3 = new Array();
    _loc1.FPrvPar4 = new Array();
    _loc1.FPrvPar5 = new Array();
    _loc1.FPrvPar6 = new Array();
    _loc1.FPrvPar7 = new Array();
    _loc1.AmorPar1 = new Array();
    _loc1.AmorPar2 = new Array();
    _loc1.AmorPar3 = new Array();
    _loc1.AmorPar4 = new Array();
    _loc1.AmorPar5 = new Array();
    _loc1.AmorPar6 = new Array();
    _loc1.AmorPar7 = new Array();
    _loc1.DohPar1 = new Array();
    _loc1.DohPar2 = new Array();
    _loc1.DohPar3 = new Array();
    _loc1.DohPar4 = new Array();
    _loc1.DohPar5 = new Array();
    _loc1.PribPar1 = new Array();
    _loc1.PribPar2 = new Array();
    _loc1.PribPar3 = new Array();
    _loc1.PribPar4 = new Array();
    _loc1.PribPar5 = new Array();
    _loc1.ToBgtPar1 = new Array();
    _loc1.ToBgtPar2 = new Array();
    _loc1.ToBgtPar3 = new Array();
    _loc1.ToBgtPar4 = new Array();
    _loc1.ToBgtPar5 = new Array();
    _loc1.RasprAm = new Array();
    _loc1.NRasprBgt = new Array();
    _loc1.DohSum = new Array();
    _loc1.NasAm = new Array();
    _loc1.NasEncM = new Array();
    _loc1.RabAmSum = new Array();
    _loc1.RabAmPar1 = new Array();
    _loc1.RabAmPar2 = new Array();
    _loc1.RabAmPar3 = new Array();
    _loc1.RabAmPar4 = new Array();
    _loc1.RabAmPar5 = new Array();
    _loc1.RabAmPar6 = new Array();
    _loc1.RabAmPar7 = new Array();
    _loc1.NRTN = new Array();
    _loc1.NRSC = new Array();
    _loc1.ProdLive = new Array();
    _loc1.UrZan = new Array();
    _loc1.UrBezr = new Array();
    _loc1.FishAm = new Array();
    _loc1.VibEcl = new Array();
    _loc1.VibOmt = new Array();
    _loc1.VibPhs = new Array();
    _loc1.OstEcl = new Array();
    _loc1.OstOmt = new Array();
    _loc1.OstPhs = new Array();
    _loc1.DegrArr = new Array();
    _loc1.DegrLandArr = new Array();
    _loc1.DegrSeaArr = new Array();
    _loc1.DohSumNDN = new Array();
    _loc1.HDev = new Array();
    _loc1.QuolOcrSr = new Array();
    _loc1.NRC1;
    _loc1.NRC2;
    _loc1.NRC3;
    _loc1.NRC4;
    _loc1.NRC5;
    _loc1.NRC6;
    _loc1.NRC7;
    _loc1.CapSum;
    _loc1.ShipUCap;
    _loc1.AgroUCap;
    _loc1.TurUCap;
    _loc1.BankProc;
} // End of the function

// [Action in Frame 92]
function RabAmOrig()
{
    var _loc1 = _global;
    var _loc2;
    if (_loc1.NRSC[_loc1.year] > _loc1.NRTN[_loc1.year])
    {
        _loc2 = _loc1.NRTN[_loc1.year];
    }
    else
    {
        _loc2 = _loc1.NRSC[_loc1.year];
    } // end else if
    return (int(_loc2));
} // End of the function
function PrvExpCalc(PrRez, NalSyr)
{
    var _loc1;
    if (PrRez > NalSyr)
    {
        _loc1 = NalSyr;
    }
    else
    {
        _loc1 = PrRez;
    } // end else if
    return (int(_loc1));
} // End of the function
function DegrCalc()
{
    var _loc1 = _global;
    Res = -0.040000 * (1 - Math.pow(1000 / _loc1.OstOmt[_loc1.year], -0.300000));
    Res = Res - 0.010000 * (1 - Math.pow(1000 / _loc1.OstEcl[_loc1.year], -0.200000));
    Res = Res + 0.010000 * (1 - Math.pow(1000 / _loc1.OstPhs[_loc1.year], -0.300000));
    Res = Res * 2;
    return (int(Res * 1000));
} // End of the function
function ToBgtCalc(num)
{
    Prb = eval("_global.PribPar" + num)[_global.year];
    if (Prb > 0)
    {
        Res = Prb * _global.NalogPrib / 100;
    }
    else
    {
        Res = 0;
    } // end else if
    return (int(Res));
} // End of the function
function QuolOcrSrCalc()
{
    var _loc1 = _global;
    Sea_good = 0;
    Sea_beg = 0;
    Land_good = 0;
    Land_bed = 0;
    AnMMap(1);
    Sea_good = Sea_good + _loc1.OldArr.length;
    AnMMap(2);
    Sea_good = Sea_good + _loc1.OldArr.length;
    AnMMap(10);
    Sea_good = Sea_good + _loc1.OldArr.length;
    AnMMap(11);
    Sea_good = Sea_good + _loc1.OldArr.length;
    AnMMap(6);
    Sea_bed = Sea_bed + _loc1.OldArr.length;
    AnMMap(7);
    Sea_bed = Sea_bed + _loc1.OldArr.length;
    AnMMap(6);
    Land_good = Land_good + _loc1.OldArr.length;
    AnMMap(4);
    Land_good = Land_good + _loc1.OldArr.length;
    AnMMap(3);
    Land_good = Land_good + _loc1.OldArr.length;
    AnMMap(12);
    Land_good = Land_good + _loc1.OldArr.length;
    AnMMap(13);
    Land_good = Land_good + _loc1.OldArr.length;
    AnMMap(14);
    Land_good = Land_good + _loc1.OldArr.length;
    AnMMap(8);
    Land_bed = Land_bed + _loc1.OldArr.length;
    AnMMap(9);
    Land_bed = Land_bed + _loc1.OldArr.length;
    Res = (Sea_good - Sea_bed) / Sea_good * 0.100000 + (Land_good - Land_bed) / Land_good * 0.900000;
    return (int(Math.pow(Res, 3) * 100) / 100);
} // End of the function
function HDevCalc()
{
    var _loc1 = _global;
    Res = 33 * _loc1.QuolOcrSr[_loc1.year] + 33 * (_loc1.DohSumNDN[_loc1.year] / 25) + 33 * (_loc1.UrZan[_loc1.year] / 100);
    return (int(Res));
} // End of the function

// [Action in Frame 93]
function AbsCalc()
{
    var _loc1 = _global;
    PcPar1 = MC_map.APar1.text;
    PcPar2 = MC_map.APar2.text;
    PcPar3 = MC_map.APar3.text;
    PcPar4 = MC_map.APar4.text;
    PcPar5 = MC_map.APar5.text;
    PcPar6 = MC_map.APar6.text;
    PcPar7 = MC_map.APar7.text;
    PcOst = MC_map.AOst.text;
    _loc1.InvPar1[_loc1.year] = int(PcPar1);
    _loc1.InvPar2[_loc1.year] = int(PcPar2);
    _loc1.InvPar3[_loc1.year] = int(PcPar3);
    _loc1.InvPar4[_loc1.year] = int(PcPar4);
    _loc1.InvPar5[_loc1.year] = int(PcPar5);
    _loc1.InvPar6[_loc1.year] = int(PcPar6);
    _loc1.InvPar7[_loc1.year] = int(PcPar7);
    _loc1.RasprAm[_loc1.year] = int(PcOst);
    _loc1.NRasprBgt[_loc1.year] = int(_loc1.Budt[_loc1.year - 1]) - int(_loc1.RasprAm[_loc1.year]);
    _loc1.AmorPar1[_loc1.year] = int(_loc1.CapPar1[_loc1.year - 1] / _loc1.Tsl1);
    _loc1.AmorPar2[_loc1.year] = int(_loc1.CapPar2[_loc1.year - 1] / _loc1.Tsl2);
    _loc1.AmorPar3[_loc1.year] = int(_loc1.CapPar3[_loc1.year - 1] / _loc1.Tsl3);
    _loc1.AmorPar4[_loc1.year] = int(_loc1.CapPar4[_loc1.year - 1] / _loc1.Tsl4);
    _loc1.AmorPar5[_loc1.year] = int(_loc1.CapPar5[_loc1.year - 1] / _loc1.Tsl5);
    _loc1.AmorPar6[_loc1.year] = int(_loc1.CapPar6[_loc1.year - 1] / _loc1.Tsl6);
    _loc1.AmorPar7[_loc1.year] = int(_loc1.CapPar7[_loc1.year - 1] / _loc1.Tsl7);
    _loc1.CapPar1[_loc1.year] = int(_loc1.CapPar1[_loc1.year - 1] + _loc1.InvPar1[_loc1.year] - _loc1.AmorPar1[_loc1.year]);
    _loc1.CapPar2[_loc1.year] = int(_loc1.CapPar2[_loc1.year - 1] + _loc1.InvPar2[_loc1.year] - _loc1.AmorPar2[_loc1.year]);
    _loc1.CapPar3[_loc1.year] = int(_loc1.CapPar3[_loc1.year - 1] + _loc1.InvPar3[_loc1.year] - _loc1.AmorPar3[_loc1.year]);
    _loc1.CapPar4[_loc1.year] = int(_loc1.CapPar4[_loc1.year - 1] + _loc1.InvPar4[_loc1.year] - _loc1.AmorPar4[_loc1.year]);
    _loc1.CapPar5[_loc1.year] = int(_loc1.CapPar5[_loc1.year - 1] + _loc1.InvPar5[_loc1.year] - _loc1.AmorPar5[_loc1.year]);
    _loc1.CapPar6[_loc1.year] = int(_loc1.CapPar6[_loc1.year - 1] + _loc1.InvPar6[_loc1.year] - _loc1.AmorPar6[_loc1.year]);
    _loc1.CapPar7[_loc1.year] = int(_loc1.CapPar7[_loc1.year - 1] + _loc1.InvPar7[_loc1.year] - _loc1.AmorPar7[_loc1.year]);
    _loc1.CapSum = int(_loc1.CapPar1[_loc1.year]) + int(_loc1.CapPar2[_loc1.year]);
    _loc1.CapSum = _loc1.CapSum + int(_loc1.CapPar3[_loc1.year]) + int(_loc1.CapPar4[_loc1.year]);
    _loc1.CapSum = _loc1.CapSum + int(_loc1.CapPar5[_loc1.year]) + int(_loc1.CapPar6[_loc1.year]);
    _loc1.CapSum = _loc1.CapSum + int(_loc1.CapPar7[_loc1.year]);
    _loc1.NRC1 = int(_loc1.NumRCap1 * _loc1.CapPar1[_loc1.year]);
    _loc1.NRC2 = int(_loc1.NumRCap2 * _loc1.CapPar2[_loc1.year]);
    _loc1.NRC3 = int(_loc1.NumRCap3 * _loc1.CapPar3[_loc1.year]);
    _loc1.NRC4 = int(_loc1.NumRCap4 * _loc1.CapPar4[_loc1.year]);
    _loc1.NRC5 = int(_loc1.NumRCap5 * _loc1.CapPar5[_loc1.year]);
    _loc1.NRC6 = int(_loc1.NumRCap6 * _loc1.CapPar6[_loc1.year]);
    _loc1.NRC7 = int(_loc1.NumRCap7 * _loc1.CapPar7[_loc1.year]);
    _loc1.NRSC[_loc1.year] = int(_loc1.NRC1 + _loc1.NRC2 + _loc1.NRC3 + _loc1.NRC4 + _loc1.NRC5 + _loc1.NRC6 + _loc1.NRC7);
    _loc1.NasEncM[_loc1.year] = _loc1.NasEnc * _loc1.QuolOcrSr[_loc1.year - 1];
    _loc1.NasAm[_loc1.year] = int(_loc1.NasAm[_loc1.year - 1] * (1 + _loc1.NasEncM[_loc1.year - 1] / 100));
    _loc1.NRTN[_loc1.year] = int(_loc1.NasAm[_loc1.year] * _loc1.NasTrud / 100);
    _loc1.RabAmSum[_loc1.year] = RabAmOrig();
    _loc1.RabAmPar1[_loc1.year] = int(_loc1.NRC1 * _loc1.RabAmSum[_loc1.year] / _loc1.NRSC[_loc1.year]);
    _loc1.RabAmPar2[_loc1.year] = int(_loc1.NRC2 * _loc1.RabAmSum[_loc1.year] / _loc1.NRSC[_loc1.year]);
    _loc1.RabAmPar3[_loc1.year] = int(_loc1.NRC3 * _loc1.RabAmSum[_loc1.year] / _loc1.NRSC[_loc1.year]);
    _loc1.RabAmPar4[_loc1.year] = int(_loc1.NRC4 * _loc1.RabAmSum[_loc1.year] / _loc1.NRSC[_loc1.year]);
    _loc1.RabAmPar5[_loc1.year] = int(_loc1.NRC5 * _loc1.RabAmSum[_loc1.year] / _loc1.NRSC[_loc1.year]);
    _loc1.RabAmPar6[_loc1.year] = int(_loc1.NRC6 * _loc1.RabAmSum[_loc1.year] / _loc1.NRSC[_loc1.year]);
    _loc1.RabAmPar7[_loc1.year] = int(_loc1.NRC7 * _loc1.RabAmSum[_loc1.year] / _loc1.NRSC[_loc1.year]);
    _loc1.FPrvPar1[_loc1.year] = int(_loc1.PrTr1 * _loc1.RabAmPar1[_loc1.year] * _loc1.QuolOcrSr[_loc1.year - 1]);
    _loc1.FPrvPar2[_loc1.year] = int(PrvExpCalc(_loc1.PrTr2 * _loc1.RabAmPar2[_loc1.year], _loc1.FishAm[_loc1.year - 1]) * _loc1.QuolOcrSr[_loc1.year - 1]);
    _loc1.FPrvPar3[_loc1.year] = int(_loc1.PrTr3 * _loc1.RabAmPar3[_loc1.year] * _loc1.QuolOcrSr[_loc1.year - 1]);
    _loc1.FPrvPar4[_loc1.year] = int(_loc1.PrTr4 * _loc1.RabAmPar4[_loc1.year] * _loc1.QuolOcrSr[_loc1.year - 1]);
    _loc1.FPrvPar5[_loc1.year] = int(_loc1.PrTr5 * _loc1.RabAmPar5[_loc1.year] * _loc1.QuolOcrSr[_loc1.year - 1]);
    if (_loc1.OstOmt[_loc1.year - 1] < _loc1.OmtFact)
    {
        EffOmt = 0;
    }
    else
    {
        EffOmt = _loc1.OstOmt[_loc1.year - 1];
    } // end else if
    _loc1.FPrvPar6[_loc1.year] = int(PrvExpCalc(_loc1.PrTr6 * _loc1.RabAmPar6[_loc1.year], EffOmt));
    if (_loc1.OstEcl[_loc1.year - 1] < _loc1.EclFact)
    {
        EffEcl = 0;
    }
    else
    {
        EffEcl = _loc1.OstEcl[_loc1.year - 1];
    } // end else if
    _loc1.FPrvPar7[_loc1.year] = int(PrvExpCalc(_loc1.PrTr7 * _loc1.RabAmPar7[_loc1.year], EffEcl));
    _loc1.UrZan[_loc1.year] = int(_loc1.RabAmSum[_loc1.year] / _loc1.NRTN[_loc1.year] * 100);
    _loc1.UrBezr[_loc1.year] = 100 - _loc1.UrZan[_loc1.year];
    _loc1.FishAm[_loc1.year] = int(_loc1.FishAm[_loc1.year - 1] + _loc1.FishAm[_loc1.year - 1] * _loc1.FishEnc / 100 * _loc1.QuolOcrSr[_loc1.year - 1] * (2.600000 * Math.exp(-1 * ((_loc1.FishAm[_loc1.year - 1] - 2000) * (_loc1.FishAm[_loc1.year - 1] - 2000)) / 180000)) - _loc1.FPrvPar2[_loc1.year]);
    _loc1.VibEcl[_loc1.year] = int(_loc1.FPrvPar2[_loc1.year] * _loc1.EclOth2 / 100 + _loc1.FPrvPar4[_loc1.year] * _loc1.EclOth4 / 100 + _loc1.FPrvPar5[_loc1.year] * _loc1.EclOth5 / 100 + _loc1.EclOthNas * _loc1.NasAm[_loc1.year]);
    _loc1.VibOmt[_loc1.year] = int(_loc1.FPrvPar1[_loc1.year] * _loc1.OmtOth1 / 100 + _loc1.FPrvPar2[_loc1.year] * _loc1.OmtOth2 / 100 + _loc1.FPrvPar3[_loc1.year] * _loc1.OmtOth3 / 100 + _loc1.FPrvPar4[_loc1.year] * _loc1.OmtOth4 / 100 + _loc1.FPrvPar5[_loc1.year] * _loc1.OmtOth5 / 100 + _loc1.OmtOthNas * _loc1.NasAm[_loc1.year]);
    _loc1.VibPhs[_loc1.year] = int(_loc1.FPrvPar3[_loc1.year] * _loc1.PhsOth3 / 100 + _loc1.FPrvPar4[_loc1.year] * _loc1.PhsOth4 / 100);
    _loc1.OstEcl[_loc1.year] = _loc1.OstEcl[_loc1.year - 1] + _loc1.VibEcl[_loc1.year];
    _loc1.OstEcl[_loc1.year] = _loc1.OstEcl[_loc1.year] - _loc1.FPrvPar7[_loc1.year];
    _loc1.OstOmt[_loc1.year] = _loc1.OstOmt[_loc1.year - 1] + _loc1.VibOmt[_loc1.year];
    _loc1.OstOmt[_loc1.year] = _loc1.OstOmt[_loc1.year] - _loc1.FPrvPar6[_loc1.year];
    _loc1.OstPhs[_loc1.year] = _loc1.OstPhs[_loc1.year - 1] + _loc1.VibPhs[_loc1.year];
    _loc1.DegrArr[_loc1.year] = DegrCalc();
    _loc1.DohPar1[_loc1.year] = int(_loc1.CenaPar1 * (1 + _loc1.Inc / 100 * _loc1.year) * _loc1.FPrvPar1[_loc1.year]);
    _loc1.DohPar2[_loc1.year] = int(_loc1.CenaPar2 * (1 + _loc1.Inc / 100 * _loc1.year) * _loc1.FPrvPar2[_loc1.year]);
    _loc1.DohPar3[_loc1.year] = int(_loc1.CenaPar3 * (1 + _loc1.Inc / 100 * _loc1.year) * _loc1.FPrvPar3[_loc1.year]);
    _loc1.DohPar4[_loc1.year] = int(_loc1.CenaPar4 * (1 + _loc1.Inc / 100 * _loc1.year) * _loc1.FPrvPar4[_loc1.year]);
    _loc1.DohPar5[_loc1.year] = int(_loc1.CenaPar5 * (1 + _loc1.Inc / 100 * _loc1.year) * _loc1.FPrvPar5[_loc1.year]);
    _loc1.DohSum[_loc1.year] = _loc1.DohPar1[_loc1.year] + _loc1.DohPar2[_loc1.year] + _loc1.DohPar3[_loc1.year] + _loc1.DohPar4[_loc1.year] + _loc1.DohPar5[_loc1.year];
    _loc1.PribPar1[_loc1.year] = int(_loc1.DohPar1[_loc1.year] - _loc1.AmorPar1[_loc1.year] - _loc1.FPrvPar1[_loc1.year] * _loc1.VcPar1);
    _loc1.PribPar2[_loc1.year] = int(_loc1.DohPar2[_loc1.year] - _loc1.AmorPar2[_loc1.year] - _loc1.FPrvPar2[_loc1.year] * _loc1.VcPar2);
    _loc1.PribPar3[_loc1.year] = int(_loc1.DohPar3[_loc1.year] - _loc1.AmorPar3[_loc1.year] - _loc1.FPrvPar3[_loc1.year] * _loc1.VcPar3);
    _loc1.PribPar4[_loc1.year] = int(_loc1.DohPar4[_loc1.year] - _loc1.AmorPar4[_loc1.year] - _loc1.FPrvPar4[_loc1.year] * _loc1.VcPar4);
    _loc1.PribPar5[_loc1.year] = int(_loc1.DohPar5[_loc1.year] - _loc1.AmorPar5[_loc1.year] - _loc1.FPrvPar5[_loc1.year] * _loc1.VcPar5);
    _loc1.ToBgtPar1[_loc1.year] = ToBgtCalc(1);
    _loc1.ToBgtPar2[_loc1.year] = ToBgtCalc(2);
    _loc1.ToBgtPar3[_loc1.year] = ToBgtCalc(3);
    _loc1.ToBgtPar4[_loc1.year] = ToBgtCalc(4);
    _loc1.ToBgtPar5[_loc1.year] = ToBgtCalc(5);
    _loc1.Budt[_loc1.year] = _loc1.NRasprBgt[_loc1.year] * (1 + _loc1.BankProc / 100) + _loc1.ToBgtPar1[_loc1.year] + _loc1.ToBgtPar2[_loc1.year];
    _loc1.Budt[_loc1.year] = _loc1.Budt[_loc1.year] + _loc1.ToBgtPar3[_loc1.year] + _loc1.ToBgtPar4[_loc1.year];
    _loc1.Budt[_loc1.year] = int(_loc1.Budt[_loc1.year] + _loc1.ToBgtPar5[_loc1.year]);
    _loc1.DohSumNDN[_loc1.year] = int(_loc1.DohSum[_loc1.year] / _loc1.NasAm[_loc1.year]);
} // End of the function

// [Action in Frame 94]
function DegrR(amount)
{
    if (amount < 0)
    {
        AddTextInf(MSG_degr2);
    }
    else
    {
        AddTextInf(MSG_degr1);
    } // end else if
} // End of the function
function CbkR(cap)
{
    var _loc1 = _global;
    var _loc2 = cap;
    if (_loc2 > _loc1.CapPar1[0] * 5)
    {
        AddTextInf(ALT_cbkMC + ": " + MS_prv3);
        MC_msg.P1.text = MS_prv3;
        MC_map.CBK.gotoAndStop(3);
        return;
    } // end if
    if (_loc2 < _loc1.CapPar1[0] / 10)
    {
        AddTextInf(ALT_cbkMC + ": " + MS_prv4);
        MC_msg.P1.text = MS_prv4;
        MC_map.CBK.gotoAndStop(4);
        return;
    } // end if
    if (_loc2 < _loc1.CapPar1[0])
    {
        AddTextInf(ALT_cbkMC + ": " + MS_prv1);
        MC_msg.P1.text = MS_prv1;
        MC_map.CBK.gotoAndStop(1);
        return;
    } // end if
    AddTextInf(ALT_cbkMC + ": " + MS_prv2);
    MC_msg.P1.text = MS_prv2;
    MC_map.CBK.gotoAndStop(2);
} // End of the function
function FishR(amount)
{
    if (amount < 0)
    {
        AddTextInf(ALT_ribMC + ": " + MS_rem);
        MC_msg.P2.text = MS_rem;
    }
    else
    {
        AddTextInf(ALT_ribMC + ": " + MS_add);
        MC_msg.P2.text = MS_add;
    } // end else if
} // End of the function
function AcvaFermR(cap)
{
    var _loc1 = _global;
    var _loc2 = cap;
    if (_loc2 > _loc1.CapPar3[0] * 5)
    {
        AddTextInf(ALT_aqMC + ": " + MS_prv3);
        MC_msg.P3.text = MS_prv3;
        MC_map.AQ.gotoAndStop(3);
        return;
    } // end if
    if (_loc2 < _loc1.CapPar3[0] / 10)
    {
        AddTextInf(ALT_aqMC + ": " + MS_prv4);
        MC_msg.P3.text = MS_prv4;
        MC_map.AQ.gotoAndStop(4);
        return;
    } // end if
    if (_loc2 < _loc1.CapPar3[0])
    {
        AddTextInf(ALT_aqMC + ": " + MS_prv1);
        MC_msg.P3.text = MS_prv1;
        MC_map.AQ.gotoAndStop(1);
        return;
    } // end if
    AddTextInf(ALT_aqMC + ": " + MS_prv2);
    MC_msg.P3.text = MS_prv2;
    MC_map.AQ.gotoAndStop(2);
} // End of the function
function AgroR(amount)
{
    if (amount < 0)
    {
        AddTextInf(ALT_agroMC + ": " + MS_rem);
        MC_msg.P4.text = MS_rem;
    }
    else
    {
        AddTextInf(ALT_agroMC + ": " + MS_add);
        MC_msg.P4.text = MS_add;
    } // end else if
} // End of the function
function TurR(amount)
{
    if (amount < 0)
    {
        AddTextInf(ALT_turMC + ": " + MS_rem);
        MC_msg.P5.text = MS_rem;
    }
    else
    {
        AddTextInf(ALT_turMC + ": " + MS_add);
        MC_msg.P5.text = MS_add;
    } // end else if
} // End of the function
function BioClnR(cap)
{
    var _loc1 = _global;
    var _loc2 = cap;
    if (_loc2 > _loc1.CapPar7[0] * 10)
    {
        AddTextInf(ALT_bclMC + ": " + MS_prv3);
        MC_msg.P7.text = MS_prv3;
        MC_map.BCL.gotoAndStop(3);
        return;
    } // end if
    if (_loc2 < _loc1.CapPar7[0] / 2)
    {
        AddTextInf(ALT_bclMC + ": " + MS_prv4);
        MC_msg.P7.text = MS_prv4;
        MC_map.BCL.gotoAndStop(4);
        return;
    } // end if
    if (_loc2 < _loc1.CapPar7[0])
    {
        AddTextInf(ALT_bclMC + ": " + MS_prv1);
        MC_msg.P7.text = MS_prv1;
        MC_map.BCL.gotoAndStop(1);
        return;
    } // end if
    AddTextInf(ALT_bclMC + ": " + MS_prv2);
    MC_msg.P7.text = MS_prv2;
    MC_map.BCL.gotoAndStop(2);
} // End of the function
function ChemClnR(cap)
{
    var _loc1 = _global;
    var _loc2 = cap;
    if (_loc2 > _loc1.CapPar6[0] * 10)
    {
        AddTextInf(ALT_cclMC + ": " + MS_prv3);
        MC_msg.P6.text = MS_prv3;
        MC_map.CCL.gotoAndStop(3);
        return;
    } // end if
    if (_loc2 < _loc1.CapPar6[0] / 2)
    {
        AddTextInf(ALT_cclMC + ": " + MS_prv4);
        MC_msg.P6.text = MS_prv4;
        MC_map.CCL.gotoAndStop(4);
        return;
    } // end if
    if (_loc2 < _loc1.CapPar6[0])
    {
        AddTextInf(ALT_cclMC + ": " + MS_prv1);
        MC_msg.P6.text = MS_prv1;
        MC_map.CCL.gotoAndStop(1);
        return;
    } // end if
    AddTextInf(ALT_cclMC + ": " + MS_prv2);
    MC_msg.P6.text = MS_prv2;
    MC_map.CCL.gotoAndStop(2);
} // End of the function
function HDevR()
{
    var _loc1 = _global;
    if (_loc1.HDev[_loc1.year] < 50)
    {
        AddTextInf(MS_popul + " " + MS_hdev1);
        return;
    } // end if
    if (_loc1.HDev[_loc1.year] < 75)
    {
        AddTextInf(MS_popul + " " + MS_hdev2);
        return;
    } // end if
    AddTextInf(MS_popul + " " + MS_hdev3);
} // End of the function
function OcrSrR()
{
    var _loc1 = _global;
    if (_loc1.QuolOcrSr[_loc1.year] < 0.500000)
    {
        AddTextInf(MS_ocrsr + " " + MS_okr1);
        return;
    } // end if
    if (_loc1.QuolOcrSr[_loc1.year] < 0.750000)
    {
        AddTextInf(MS_ocrsr + " " + MS_okr2);
        return;
    } // end if
    AddTextInf(MS_ocrsr + " " + MS_okr3);
} // End of the function
function TestTime()
{
    var _loc1 = _global;
    if (_loc1.year == _loc1.endYear)
    {
        _loc1.is_over = true;
        AddTextInf("<br><b>" + MSG_endtime + "</b>");
        MC_msg.MSG_bot.text = MSG_endtime;
    } // end if
} // End of the function
function EndGame()
{
    var _loc1 = _root;
    if (_global.is_over == true)
    {
        _loc1.MC_map.BT_start.enabled = false;
        _loc1.MC_map.BT_p1.enabled = false;
        _loc1.MC_map.BT_p2.enabled = false;
        _loc1.MC_map.BT_p3.enabled = false;
        _loc1.MC_map.BT_p4.enabled = false;
        _loc1.MC_map.BT_p5.enabled = false;
        _loc1.MC_map.BT_p6.enabled = false;
        _loc1.MC_map.BT_p7.enabled = false;
        _loc1.MC_map.BT_m1.enabled = false;
        _loc1.MC_map.BT_m2.enabled = false;
        _loc1.MC_map.BT_m3.enabled = false;
        _loc1.MC_map.BT_m4.enabled = false;
        _loc1.MC_map.BT_m5.enabled = false;
        _loc1.MC_map.BT_m6.enabled = false;
        _loc1.MC_map.BT_m7.enabled = false;
        return;
    } // end if
    MC_msg.MSG_bot.text = MSG_progame;
} // End of the function
function AddTextInf(str)
{
    _root.MC_anal.rew_text.htmlText = "<i>" + str + "</i><br>" + _root.MC_anal.rew_text.htmlText;
} // End of the function
_global.endYear = 20;

// [Action in Frame 95]
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

// [Action in Frame 96]
function ShowAlt(txt_var)
{
    var _loc1 = _root;
    _loc1.createTextField("alttxt", 91, _loc1._xmouse + 3, _loc1._ymouse + 3, 10, 10);
    _loc1.alttxt.textColor = 0;
    _loc1.alttxt.border = true;
    _loc1.alttxt.borderColor = 8421504;
    _loc1.alttxt.background = true;
    _loc1.alttxt.backgroundColor = 16645846;
    _loc1.alttxt.text = txt_var;
    _loc1.alttxt.setTextFormat(altText);
    _loc1.alttxt.autoSize = true;
    _loc1.alttxt._alpha = 100;
    _loc1.alttxt._visible = true;
    if (_loc1.alttxt._x + _loc1.alttxt.textWidth > 640)
    {
        _loc1.alttxt._x = _loc1._xmouse - _loc1.alttxt.textWidth - 10;
        return;
    } // end if
    if (_loc1.alttxt._x - _loc1.alttxt.textWidth < 0)
    {
        _loc1.alttxt._x = _loc1._xmouse + 10;
    } // end if
} // End of the function
_root.altText = new TextFormat();
_root.altText.font = "Arial";
_root.altText.bold = false;
_root.altText.size = 12;

// [Action in Frame 97]
_root.onData = function ()
{
    if (success != 1)
    {
        loadVariables(_global.LANG + "//data.txt", "_root");
    }
    else
    {
        _global.ArrFCol = [_level0.DohSumNDNT, _level0.HDevT, _level0.QuolOcrSrT, _level0.FishAmT, _level0.FPrvPar2T2, _level0.VibEclT, _level0.VibPhsT, _level0.VibOmtT, _level0.OstEclT, _level0.OstPhsT, _level0.OstOmtT, _level0.DegrLandArrT, _level0.DegrSeaArrT, _level0.FPrvPar6T, _level0.FPrvPar7T, _level0.NasAmT, _level0.NasEncMT, _level0.ProdLiveT, _level0.NRTNT, _level0.NRSCT, _level0.RabAmSumT, _level0.RabAmPar1T, _level0.RabAmPar2T, _level0.RabAmPar3T, _level0.RabAmPar4T, _level0.RabAmPar5T, _level0.RabAmPar6T, _level0.RabAmPar7T, _level0.UrZanT, _level0.UrBezrT, _level0.InvPar1T, _level0.InvPar2T, _level0.InvPar3T, _level0.InvPar4T, _level0.InvPar5T, _level0.InvPar6T, _level0.InvPar7T, _level0.CapPar1T, _level0.CapPar2T, _level0.CapPar3T, _level0.CapPar4T, _level0.CapPar5T, _level0.CapPar6T, _level0.CapPar7T, _level0.AmorPar1T, _level0.AmorPar2T, _level0.AmorPar3T, _level0.AmorPar4T, _level0.AmorPar5T, _level0.AmorPar6T, _level0.AmorPar7T, _level0.FPrvPar1T, _level0.FPrvPar2T, _level0.FPrvPar3T, _level0.FPrvPar4T, _level0.FPrvPar5T, _level0.FPrvPar6T, _level0.FPrvPar7T, _level0.DohSumT, _level0.DohPar1T, _level0.DohPar2T, _level0.DohPar3T, _level0.DohPar4T, _level0.DohPar5T, _level0.PribPar1T, _level0.PribPar2T, _level0.PribPar3T, _level0.PribPar4T, _level0.PribPar5T, _level0.ToBgtPar1T, _level0.ToBgtPar2T, _level0.ToBgtPar3T, _level0.ToBgtPar4T, _level0.ToBgtPar5T, _level0.RasprAmT, _level0.NRasprBgtT, _level0.RabAmSumT, _level0.RabAmPar1T, _level0.RabAmPar2T, _level0.RabAmPar3T, _level0.RabAmPar4T, _level0.RabAmPar5T, _level0.RabAmPar6T, _level0.RabAmPar7T];
        _global.MaxPrFc = 0;
        for (i = 0; i < _global.ArrFCol.length; i++)
        {
            Parent = "_root";
            eval(Parent).createTextField("cell", 12900, 20, 20, 20, 20);
            eval(Parent + ".cell").html = true;
            eval(Parent + ".cell").htmlText = _global.ArrFCol[i];
            eval(Parent + ".cell").setTextFormat(tabText);
            eval(Parent + ".cell").autoSize = true;
            eval(Parent + ".cell").border = true;
            wdth = eval(Parent + ".cell")._width;
            _global.hght = eval(Parent + ".cell")._height;
            eval(Parent + ".cell").removeTextField();
            if (_global.MaxPrFc < wdth)
            {
                _global.MaxPrFc = wdth;
            } // end if
        } // end of for
        _global.MaxPrFc = _global.MaxPrFc + 30;
        gotoAndPlay(_root._currentframe + 1);
    } // end else if
};

// [Action in Frame 98]
function InitTurn()
{
    var _loc1 = _root;
    var _loc2 = _global;
    _loc1.MC_map.total_mon.text = int(_loc2.Budt[_loc2.year] * 0.900000);
    _loc1.MC_map.total_men.text = _loc2.NasAm[_loc2.year];
    _loc1.MC_map.total_fish.text = _loc2.FishAm[_loc2.year];
    _loc1.MC_map.year_stat.text = _loc1.MSG_year + " " + _loc2.year + " " + _loc1.MSG_of + " " + _loc2.endYear;
    _loc1.MC_map.Par1.text = 0;
    _loc1.MC_map.Par2.text = 0;
    _loc1.MC_map.Par3.text = 0;
    _loc1.MC_map.Par4.text = 0;
    _loc1.MC_map.Par5.text = 0;
    _loc1.MC_map.Par6.text = 5;
    _loc1.MC_map.Par7.text = 5;
    _loc1.MC_map.Ost.text = 10;
    _loc1.MC_map.APar1.text = 0;
    _loc1.MC_map.APar2.text = 0;
    _loc1.MC_map.APar3.text = 0;
    _loc1.MC_map.APar4.text = 0;
    _loc1.MC_map.APar5.text = 0;
    _loc1.MC_map.APar6.text = _loc2.Budt[_loc2.year] * 0.050000;
    _loc1.MC_map.APar7.text = _loc2.Budt[_loc2.year] * 0.050000;
    _loc1.MC_map.AOst.text = int(_loc1.MC_map.APar6.text) + int(_loc1.MC_map.APar6.text);
} // End of the function

// [Action in Frame 99]
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
base = "_root.MC_map.MC_mapvar";
var j = 20;

// [Action in Frame 100]
function FirstConfig()
{
    var _loc1 = _global;
    var _loc2 = _root;
    _loc1.ParX = new Array();
    _loc1.numMapX = 20;
    _loc1.numMapY = 20;
    _loc1.MapArr;
    if (_loc1.MapMode == "Map1")
    {
        MC_map.AQ._x = 11;
        MC_map.AQ._y = 187;
        MC_map.AQ.gotoAndStop(2);
        MC_map.CBK._x = 209;
        MC_map.CBK._y = -99;
        MC_map.CBK.gotoAndStop(2);
        MC_map.CCL._x = -55;
        MC_map.CCL._y = -121;
        MC_map.CCL.gotoAndStop(2);
        MC_map.BCL._x = 231;
        MC_map.BCL._y = 121;
        MC_map.BCL.gotoAndStop(2);
        _loc1.MapArr = [[4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4], [4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4], [4, 4, 4, 4, 4, 4, 4, 4, 14, 14, 14, 14, 14, 4, 4, 4, 4, 4, 4, 4], [4, 4, 15, 15, 15, 14, 14, 14, 14, 14, 14, 14, 4, 4, 4, 4, 4, 4, 4, 4], [4, 4, 15, 15, 15, 14, 5, 5, 5, 5, 5, 14, 4, 4, 15, 15, 15, 4, 4, 4], [14, 4, 4, 4, 4, 14, 5, 5, 5, 5, 5, 14, 4, 4, 15, 15, 15, 4, 4, 4], [3, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 4, 4, 4, 4, 4, 4, 4], [3, 3, 3, 3, 4, 4, 14, 5, 5, 5, 5, 5, 14, 4, 4, 4, 4, 4, 4, 4], [2, 2, 2, 3, 3, 4, 14, 5, 5, 5, 5, 5, 14, 14, 4, 4, 4, 4, 4, 4], [1, 1, 1, 1, 2, 3, 3, 14, 14, 14, 14, 14, 14, 4, 4, 4, 4, 4, 4, 4], [1, 1, 1, 1, 1, 2, 3, 3, 3, 14, 4, 4, 4, 4, 4, 4, 13, 4, 4, 4], [1, 1, 1, 1, 1, 11, 3, 3, 3, 3, 14, 4, 4, 4, 4, 4, 4, 4, 4, 4], [1, 1, 1, 1, 2, 2, 3, 3, 3, 3, 14, 14, 4, 4, 4, 4, 4, 4, 4, 4], [1, 1, 1, 1, 2, 3, 3, 3, 3, 3, 14, 14, 14, 4, 4, 4, 4, 4, 4, 4], [1, 1, 1, 1, 2, 2, 3, 3, 3, 3, 14, 14, 14, 14, 14, 15, 15, 15, 4, 4], [1, 10, 1, 1, 1, 2, 2, 12, 3, 3, 3, 14, 14, 14, 14, 15, 15, 15, 4, 4], [1, 1, 1, 1, 1, 2, 2, 3, 3, 3, 3, 14, 14, 14, 4, 4, 4, 4, 4, 4], [1, 1, 1, 1, 1, 15, 15, 15, 3, 3, 3, 3, 14, 14, 4, 4, 4, 4, 14, 14], [1, 1, 1, 1, 2, 15, 15, 15, 3, 3, 3, 3, 14, 4, 4, 4, 14, 4, 14, 14], [1, 1, 1, 1, 2, 3, 3, 3, 3, 3, 3, 3, 14, 4, 4, 14, 14, 14, 14, 14]];
        _loc2.MC_map.MC_mapvar.gotoAndStop(1);
        _loc1.year = 0;
        _loc1.Budt[0] = 1000;
        _loc1.Tsl1 = 5;
        _loc1.Tsl2 = 5;
        _loc1.Tsl3 = 5;
        _loc1.Tsl4 = 5;
        _loc1.Tsl5 = 5;
        _loc1.Tsl6 = 5;
        _loc1.Tsl7 = 5;
        _loc1.NasEnc = 4.500000;
        _loc1.NasTrud = 40;
        _loc1.NumRCap1 = 0.050000;
        _loc1.NumRCap2 = 0.050000;
        _loc1.NumRCap3 = 0.050000;
        _loc1.NumRCap4 = 0.050000;
        _loc1.NumRCap5 = 0.050000;
        _loc1.NumRCap6 = 0.005000;
        _loc1.NumRCap7 = 0.005000;
        _loc1.PrTr1 = 5;
        _loc1.PrTr2 = 5;
        _loc1.PrTr3 = 5;
        _loc1.PrTr4 = 5;
        _loc1.PrTr5 = 5;
        _loc1.PrTr6 = 100;
        _loc1.PrTr7 = 100;
        _loc1.OmtFact = 10;
        _loc1.EclFact = 10;
        _loc1.OmtOth1 = 10;
        _loc1.EclOth2 = 10;
        _loc1.OmtOth2 = 10;
        _loc1.OmtOth3 = 10;
        _loc1.PhsOth3 = 10;
        _loc1.EclOth4 = 10;
        _loc1.OmtOth4 = 10;
        _loc1.PhsOth4 = 10;
        _loc1.EclOth5 = 10;
        _loc1.OmtOth5 = 10;
        _loc1.EclOthNas = 1;
        _loc1.OmtOthNas = 1;
        _loc1.CenaPar1 = 10;
        _loc1.CenaPar2 = 10;
        _loc1.CenaPar3 = 10;
        _loc1.CenaPar4 = 10;
        _loc1.CenaPar5 = 10;
        _loc1.Inc = 2;
        _loc1.VcPar1 = 0.050000;
        _loc1.VcPar2 = 0.050000;
        _loc1.VcPar3 = 0.050000;
        _loc1.VcPar4 = 0.050000;
        _loc1.VcPar5 = 0.050000;
        _loc1.NalogPrib = 40;
        _loc1.BankProc = 5;
        _loc1.InvPar1[0] = 50;
        _loc1.InvPar2[0] = 50;
        _loc1.InvPar3[0] = 50;
        _loc1.InvPar4[0] = 50;
        _loc1.InvPar5[0] = 50;
        _loc1.InvPar6[0] = 50;
        _loc1.InvPar7[0] = 50;
        _loc1.CapPar1[0] = 750;
        _loc1.CapPar2[0] = 500;
        _loc1.CapPar3[0] = 200;
        _loc1.CapPar4[0] = 200;
        _loc1.CapPar5[0] = 100;
        _loc1.CapPar6[0] = 500;
        _loc1.CapPar7[0] = 500;
        _loc1.FPrvPar1[0] = 150;
        _loc1.FPrvPar2[0] = 100;
        _loc1.FPrvPar3[0] = 40;
        _loc1.FPrvPar4[0] = 40;
        _loc1.FPrvPar5[0] = 20;
        _loc1.FPrvPar6[0] = 100;
        _loc1.FPrvPar7[0] = 100;
        _loc1.AmorPar1[0] = 150;
        _loc1.AmorPar2[0] = 100;
        _loc1.AmorPar3[0] = 40;
        _loc1.AmorPar4[0] = 40;
        _loc1.AmorPar5[0] = 20;
        _loc1.AmorPar6[0] = 100;
        _loc1.AmorPar7[0] = 100;
        _loc1.DohPar1[0] = 1500;
        _loc1.DohPar2[0] = 1000;
        _loc1.DohPar3[0] = 400;
        _loc1.DohPar4[0] = 400;
        _loc1.DohPar5[0] = 200;
        _loc1.PribPar1[0] = 1200;
        _loc1.PribPar2[0] = 800;
        _loc1.PribPar3[0] = 300;
        _loc1.PribPar4[0] = 300;
        _loc1.PribPar5[0] = 100;
        _loc1.ToBgtPar1[0] = 500;
        _loc1.ToBgtPar2[0] = 300;
        _loc1.ToBgtPar3[0] = 140;
        _loc1.ToBgtPar4[0] = 140;
        _loc1.ToBgtPar5[0] = 70;
        _loc1.RasprAm[0] = 100;
        _loc1.NRasprBgt[0] = 900;
        _loc1.DohSum[0] = 3500;
        _loc1.NasAm[0] = 600;
        _loc1.NRTN[0] = 240;
        _loc1.NRSC[0] = 60;
        _loc1.RabAmSum[0] = 60;
        _loc1.RabAmPar1[0] = 25;
        _loc1.RabAmPar2[0] = 18;
        _loc1.RabAmPar3[0] = 7;
        _loc1.RabAmPar4[0] = 6;
        _loc1.RabAmPar5[0] = 2;
        _loc1.RabAmPar6[0] = 1;
        _loc1.RabAmPar7[0] = 1;
        _loc1.UrZan[0] = 25;
        _loc1.UrBezr[0] = 100 - _loc1.UrZan[0];
        _loc1.ProdLive[0] = 75;
        _loc1.FishAm[0] = 2000;
        _loc1.FishEnc = 5;
        _loc1.DegrArr[0] = 0;
        _loc1.DegrLandArr[0] = 0;
        _loc1.DegrSeaArr[0] = 0;
        _loc1.VibEcl[0] = 500;
        _loc1.VibOmt[0] = 5;
        _loc1.VibPhs[0] = 600;
        _loc1.OstEcl[0] = 100;
        _loc1.OstOmt[0] = 100;
        _loc1.OstPhs[0] = 10;
        _loc1.DohSumNDN[0] = 10;
        _loc1.HDev[0] = 50;
        _loc1.QuolOcrSr[0] = 1;
        _loc1.NasEncM[0] = _loc1.NasEnc * _loc1.QuolOcrSr[0];
        _loc1.ShipUCap = 500;
        _loc1.AgroUCap = 20;
        _loc1.TurUCap = 100;
    }
    else if (_loc1.MapMode == "Map2")
    {
        MC_map.AQ._x = 121;
        MC_map.AQ._y = 121;
        MC_map.AQ.gotoAndStop(2);
        MC_map.CBK._x = 11;
        MC_map.CBK._y = -165;
        MC_map.CBK.gotoAndStop(2);
        MC_map.CCL._x = 231;
        MC_map.CCL._y = -143;
        MC_map.CCL.gotoAndStop(2);
        MC_map.BCL._x = 209;
        MC_map.BCL._y = 33;
        MC_map.BCL.gotoAndStop(2);
        _loc1.MapArr = [[1, 3, 14, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 14, 14, 14, 4, 4, 4, 4], [1, 2, 3, 14, 14, 15, 15, 15, 4, 14, 14, 14, 14, 14, 14, 4, 4, 4, 4, 4], [1, 1, 2, 3, 3, 15, 15, 15, 4, 14, 5, 5, 5, 5, 14, 15, 15, 15, 4, 4], [1, 1, 1, 2, 2, 3, 3, 3, 4, 14, 5, 5, 5, 5, 14, 15, 15, 15, 4, 4], [1, 1, 1, 1, 2, 2, 2, 3, 3, 14, 14, 14, 14, 14, 14, 4, 4, 4, 4, 4], [1, 1, 1, 1, 1, 2, 2, 3, 3, 4, 14, 4, 4, 4, 14, 14, 4, 4, 4, 4], [1, 1, 1, 1, 2, 2, 3, 3, 3, 4, 14, 4, 4, 4, 14, 4, 4, 4, 4, 4], [1, 1, 1, 2, 2, 3, 3, 3, 14, 4, 14, 14, 14, 14, 14, 4, 4, 4, 4, 4], [1, 1, 1, 2, 2, 3, 3, 3, 14, 14, 4, 4, 4, 4, 4, 4, 4, 4, 13, 4], [1, 1, 1, 2, 2, 3, 3, 3, 3, 14, 14, 4, 4, 4, 4, 4, 4, 4, 4, 4], [1, 1, 1, 1, 2, 11, 3, 3, 3, 3, 14, 14, 4, 4, 15, 15, 15, 4, 4, 4], [1, 1, 1, 1, 1, 2, 2, 3, 3, 3, 3, 14, 14, 14, 15, 15, 15, 4, 4, 4], [1, 1, 1, 1, 1, 1, 2, 2, 12, 3, 3, 3, 3, 14, 14, 4, 4, 4, 4, 4], [1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 3, 14, 14, 4, 4, 14, 14], [1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 15, 15, 15, 3, 3, 14, 14, 14, 14, 14], [1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 15, 15, 15, 3, 3, 3, 3, 3, 2, 2], [1, 1, 10, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 2, 2, 2], [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2], [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2], [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]];
        _loc2.MC_map.MC_mapvar.gotoAndStop(2);
        _loc1.year = 0;
        _loc1.Budt[0] = 1000;
        _loc1.Tsl1 = 5;
        _loc1.Tsl2 = 5;
        _loc1.Tsl3 = 5;
        _loc1.Tsl4 = 5;
        _loc1.Tsl5 = 5;
        _loc1.Tsl6 = 5;
        _loc1.Tsl7 = 5;
        _loc1.NasEnc = 4.500000;
        _loc1.NasTrud = 40;
        _loc1.NumRCap1 = 0.050000;
        _loc1.NumRCap2 = 0.050000;
        _loc1.NumRCap3 = 0.050000;
        _loc1.NumRCap4 = 0.050000;
        _loc1.NumRCap5 = 0.050000;
        _loc1.NumRCap6 = 0.005000;
        _loc1.NumRCap7 = 0.005000;
        _loc1.PrTr1 = 5;
        _loc1.PrTr2 = 5;
        _loc1.PrTr3 = 5;
        _loc1.PrTr4 = 5;
        _loc1.PrTr5 = 5;
        _loc1.PrTr6 = 100;
        _loc1.PrTr7 = 100;
        _loc1.OmtFact = 10;
        _loc1.EclFact = 10;
        _loc1.OmtOth1 = 10;
        _loc1.EclOth2 = 10;
        _loc1.OmtOth2 = 10;
        _loc1.OmtOth3 = 10;
        _loc1.PhsOth3 = 10;
        _loc1.EclOth4 = 10;
        _loc1.OmtOth4 = 10;
        _loc1.PhsOth4 = 10;
        _loc1.EclOth5 = 10;
        _loc1.OmtOth5 = 10;
        _loc1.EclOthNas = 1;
        _loc1.OmtOthNas = 1;
        _loc1.CenaPar1 = 10;
        _loc1.CenaPar2 = 10;
        _loc1.CenaPar3 = 10;
        _loc1.CenaPar4 = 10;
        _loc1.CenaPar5 = 10;
        _loc1.Inc = 2;
        _loc1.VcPar1 = 0.050000;
        _loc1.VcPar2 = 0.050000;
        _loc1.VcPar3 = 0.050000;
        _loc1.VcPar4 = 0.050000;
        _loc1.VcPar5 = 0.050000;
        _loc1.NalogPrib = 40;
        _loc1.BankProc = 5;
        _loc1.InvPar1[0] = 50;
        _loc1.InvPar2[0] = 50;
        _loc1.InvPar3[0] = 50;
        _loc1.InvPar4[0] = 50;
        _loc1.InvPar5[0] = 50;
        _loc1.InvPar6[0] = 50;
        _loc1.InvPar7[0] = 50;
        _loc1.CapPar1[0] = 750;
        _loc1.CapPar2[0] = 500;
        _loc1.CapPar3[0] = 200;
        _loc1.CapPar4[0] = 200;
        _loc1.CapPar5[0] = 100;
        _loc1.CapPar6[0] = 500;
        _loc1.CapPar7[0] = 500;
        _loc1.FPrvPar1[0] = 150;
        _loc1.FPrvPar2[0] = 100;
        _loc1.FPrvPar3[0] = 40;
        _loc1.FPrvPar4[0] = 40;
        _loc1.FPrvPar5[0] = 20;
        _loc1.FPrvPar6[0] = 100;
        _loc1.FPrvPar7[0] = 100;
        _loc1.AmorPar1[0] = 150;
        _loc1.AmorPar2[0] = 100;
        _loc1.AmorPar3[0] = 40;
        _loc1.AmorPar4[0] = 40;
        _loc1.AmorPar5[0] = 20;
        _loc1.AmorPar6[0] = 100;
        _loc1.AmorPar7[0] = 100;
        _loc1.DohPar1[0] = 1500;
        _loc1.DohPar2[0] = 1000;
        _loc1.DohPar3[0] = 400;
        _loc1.DohPar4[0] = 400;
        _loc1.DohPar5[0] = 200;
        _loc1.PribPar1[0] = 1200;
        _loc1.PribPar2[0] = 800;
        _loc1.PribPar3[0] = 300;
        _loc1.PribPar4[0] = 300;
        _loc1.PribPar5[0] = 100;
        _loc1.ToBgtPar1[0] = 500;
        _loc1.ToBgtPar2[0] = 300;
        _loc1.ToBgtPar3[0] = 140;
        _loc1.ToBgtPar4[0] = 140;
        _loc1.ToBgtPar5[0] = 70;
        _loc1.RasprAm[0] = 100;
        _loc1.NRasprBgt[0] = 900;
        _loc1.DohSum[0] = 3500;
        _loc1.NasAm[0] = 600;
        _loc1.NRTN[0] = 240;
        _loc1.NRSC[0] = 60;
        _loc1.RabAmSum[0] = 60;
        _loc1.RabAmPar1[0] = 25;
        _loc1.RabAmPar2[0] = 18;
        _loc1.RabAmPar3[0] = 7;
        _loc1.RabAmPar4[0] = 6;
        _loc1.RabAmPar5[0] = 2;
        _loc1.RabAmPar6[0] = 1;
        _loc1.RabAmPar7[0] = 1;
        _loc1.UrZan[0] = 25;
        _loc1.UrBezr[0] = 100 - _loc1.UrZan[0];
        _loc1.ProdLive[0] = 75;
        _loc1.FishAm[0] = 2000;
        _loc1.FishEnc = 5;
        _loc1.DegrArr[0] = 0;
        _loc1.DegrLandArr[0] = 0;
        _loc1.DegrSeaArr[0] = 0;
        _loc1.VibEcl[0] = 500;
        _loc1.VibOmt[0] = 5;
        _loc1.VibPhs[0] = 600;
        _loc1.OstEcl[0] = 100;
        _loc1.OstOmt[0] = 100;
        _loc1.OstPhs[0] = 10;
        _loc1.DohSumNDN[0] = 10;
        _loc1.HDev[0] = 50;
        _loc1.QuolOcrSr[0] = 1;
        _loc1.NasEncM[0] = _loc1.NasEnc * _loc1.QuolOcrSr[0];
        _loc1.ShipUCap = 500;
        _loc1.AgroUCap = 20;
        _loc1.TurUCap = 100;
    }
    else if (_loc1.MapMode == "Map3")
    {
        MC_map.AQ._x = 143;
        MC_map.AQ._y = -77;
        MC_map.AQ.gotoAndStop(2);
        MC_map.CBK._x = 275;
        MC_map.CBK._y = -187;
        MC_map.CBK.gotoAndStop(2);
        MC_map.CCL._x = 99;
        MC_map.CCL._y = -187;
        MC_map.CCL.gotoAndStop(2);
        MC_map.BCL._x = 275;
        MC_map.BCL._y = -33;
        MC_map.BCL.gotoAndStop(2);
        _loc1.MapArr = [[1, 1, 1, 1, 1, 1, 2, 3, 14, 15, 15, 15, 4, 4, 4, 4, 4, 15, 15, 15], [1, 1, 1, 1, 1, 1, 1, 2, 3, 15, 15, 15, 4, 4, 4, 4, 4, 15, 15, 15], [1, 1, 1, 1, 1, 1, 1, 1, 11, 3, 3, 14, 14, 4, 4, 4, 4, 4, 4, 4], [1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 3, 3, 3, 4, 14, 14, 13, 14, 14], [1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 14, 4, 4, 4, 14], [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 15, 15, 15, 3, 3, 4, 4, 4, 14], [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 15, 15, 15, 3, 3, 3, 14, 14, 14], [1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 15, 15, 15], [1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 15, 15, 15], [1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3], [1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 12, 3, 3, 3], [1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3], [1, 1, 1, 1, 1, 10, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2], [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2], [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2], [1, 2, 3, 3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2], [1, 1, 3, 3, 3, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1], [1, 1, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1], [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1], [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]];
        _loc2.MC_map.MC_mapvar.gotoAndStop(3);
        _loc1.year = 0;
        _loc1.Budt[0] = 1000;
        _loc1.Tsl1 = 5;
        _loc1.Tsl2 = 5;
        _loc1.Tsl3 = 5;
        _loc1.Tsl4 = 5;
        _loc1.Tsl5 = 5;
        _loc1.Tsl6 = 5;
        _loc1.Tsl7 = 5;
        _loc1.NasEnc = 4.500000;
        _loc1.NasTrud = 40;
        _loc1.NumRCap1 = 0.050000;
        _loc1.NumRCap2 = 0.050000;
        _loc1.NumRCap3 = 0.050000;
        _loc1.NumRCap4 = 0.050000;
        _loc1.NumRCap5 = 0.050000;
        _loc1.NumRCap6 = 0.005000;
        _loc1.NumRCap7 = 0.005000;
        _loc1.PrTr1 = 5;
        _loc1.PrTr2 = 5;
        _loc1.PrTr3 = 5;
        _loc1.PrTr4 = 5;
        _loc1.PrTr5 = 5;
        _loc1.PrTr6 = 100;
        _loc1.PrTr7 = 100;
        _loc1.OmtFact = 10;
        _loc1.EclFact = 10;
        _loc1.OmtOth1 = 10;
        _loc1.EclOth2 = 10;
        _loc1.OmtOth2 = 10;
        _loc1.OmtOth3 = 10;
        _loc1.PhsOth3 = 10;
        _loc1.EclOth4 = 10;
        _loc1.OmtOth4 = 10;
        _loc1.PhsOth4 = 10;
        _loc1.EclOth5 = 10;
        _loc1.OmtOth5 = 10;
        _loc1.EclOthNas = 1;
        _loc1.OmtOthNas = 1;
        _loc1.CenaPar1 = 10;
        _loc1.CenaPar2 = 10;
        _loc1.CenaPar3 = 10;
        _loc1.CenaPar4 = 10;
        _loc1.CenaPar5 = 10;
        _loc1.Inc = 2;
        _loc1.VcPar1 = 0.050000;
        _loc1.VcPar2 = 0.050000;
        _loc1.VcPar3 = 0.050000;
        _loc1.VcPar4 = 0.050000;
        _loc1.VcPar5 = 0.050000;
        _loc1.NalogPrib = 40;
        _loc1.BankProc = 5;
        _loc1.InvPar1[0] = 50;
        _loc1.InvPar2[0] = 50;
        _loc1.InvPar3[0] = 50;
        _loc1.InvPar4[0] = 50;
        _loc1.InvPar5[0] = 50;
        _loc1.InvPar6[0] = 50;
        _loc1.InvPar7[0] = 50;
        _loc1.CapPar1[0] = 750;
        _loc1.CapPar2[0] = 500;
        _loc1.CapPar3[0] = 200;
        _loc1.CapPar4[0] = 200;
        _loc1.CapPar5[0] = 100;
        _loc1.CapPar6[0] = 500;
        _loc1.CapPar7[0] = 500;
        _loc1.FPrvPar1[0] = 150;
        _loc1.FPrvPar2[0] = 100;
        _loc1.FPrvPar3[0] = 40;
        _loc1.FPrvPar4[0] = 40;
        _loc1.FPrvPar5[0] = 20;
        _loc1.FPrvPar6[0] = 100;
        _loc1.FPrvPar7[0] = 100;
        _loc1.AmorPar1[0] = 150;
        _loc1.AmorPar2[0] = 100;
        _loc1.AmorPar3[0] = 40;
        _loc1.AmorPar4[0] = 40;
        _loc1.AmorPar5[0] = 20;
        _loc1.AmorPar6[0] = 100;
        _loc1.AmorPar7[0] = 100;
        _loc1.DohPar1[0] = 1500;
        _loc1.DohPar2[0] = 1000;
        _loc1.DohPar3[0] = 400;
        _loc1.DohPar4[0] = 400;
        _loc1.DohPar5[0] = 200;
        _loc1.PribPar1[0] = 1200;
        _loc1.PribPar2[0] = 800;
        _loc1.PribPar3[0] = 300;
        _loc1.PribPar4[0] = 300;
        _loc1.PribPar5[0] = 100;
        _loc1.ToBgtPar1[0] = 500;
        _loc1.ToBgtPar2[0] = 300;
        _loc1.ToBgtPar3[0] = 140;
        _loc1.ToBgtPar4[0] = 140;
        _loc1.ToBgtPar5[0] = 70;
        _loc1.RasprAm[0] = 100;
        _loc1.NRasprBgt[0] = 900;
        _loc1.DohSum[0] = 3500;
        _loc1.NasAm[0] = 600;
        _loc1.NRTN[0] = 240;
        _loc1.NRSC[0] = 60;
        _loc1.RabAmSum[0] = 60;
        _loc1.RabAmPar1[0] = 25;
        _loc1.RabAmPar2[0] = 18;
        _loc1.RabAmPar3[0] = 7;
        _loc1.RabAmPar4[0] = 6;
        _loc1.RabAmPar5[0] = 2;
        _loc1.RabAmPar6[0] = 1;
        _loc1.RabAmPar7[0] = 1;
        _loc1.UrZan[0] = 25;
        _loc1.UrBezr[0] = 100 - _loc1.UrZan[0];
        _loc1.ProdLive[0] = 75;
        _loc1.FishAm[0] = 2000;
        _loc1.FishEnc = 5;
        _loc1.DegrArr[0] = 0;
        _loc1.DegrLandArr[0] = 0;
        _loc1.DegrSeaArr[0] = 0;
        _loc1.VibEcl[0] = 500;
        _loc1.VibOmt[0] = 5;
        _loc1.VibPhs[0] = 600;
        _loc1.OstEcl[0] = 100;
        _loc1.OstOmt[0] = 100;
        _loc1.OstPhs[0] = 10;
        _loc1.DohSumNDN[0] = 10;
        _loc1.HDev[0] = 50;
        _loc1.QuolOcrSr[0] = 1;
        _loc1.NasEncM[0] = _loc1.NasEnc * _loc1.QuolOcrSr[0];
        _loc1.ShipUCap = 500;
        _loc1.AgroUCap = 20;
        _loc1.TurUCap = 100;
    } // end else if
    SetMMap();
    InitTurn();
    _loc1.ParX[_loc1.year] = _loc1.year;
    ++_loc1.year;
    _loc1.is_over = false;
} // End of the function

// [Action in Frame 101]
function PrintTable(kx, ky, dx, dy)
{
    xx = 50;
    yy = 20;
    Parent = "_root.PrintMC";
    ++_global.page;
    eval(Parent).createEmptyMovieClip("page" + _global.page, _global.page);
    Parent = "_root.PrintMC.page" + _global.page;
    eval(Parent).createTextField("title", 0, 20, 20, 20, 20);
    eval(Parent + ".title").html = true;
    eval(Parent + ".title").htmlText = "<b>" + _level0.AN_name + "</b>";
    eval(Parent + ".title").setTextFormat(tabText);
    eval(Parent + ".title").autoSize = "center";
    eval(Parent + ".title")._x = xx;
    eval(Parent + ".title")._y = yy;
    yy = yy + (eval(Parent + ".title")._height) + delta;
    eval(Parent).createTextField("date_and_page", 1, 20, 20, 20, 20);
    eval(Parent + ".date_and_page").html = true;
    myDate = new Date();
    mytext = myDate.getFullYear() + "/" + (myDate.getMonth() + 1) + "/" + myDate.getDate() + "      " + _level0.AN_page + ": " + _global.page;
    eval(Parent + ".date_and_page").htmlText = "<b>" + mytext + "</b>";
    eval(Parent + ".date_and_page").setTextFormat(tabText);
    eval(Parent + ".date_and_page").autoSize = "center";
    eval(Parent + ".date_and_page")._x = xx;
    eval(Parent + ".date_and_page")._y = yy;
    yy = yy + (eval(Parent + ".date_and_page")._height) + delta;
    eval(Parent).createTextField("column_ftsm", 2, 20, 20, 20, 20);
    eval(Parent + ".column_ftsm").html = true;
    eval(Parent + ".column_ftsm").htmlText = "<b> </b>";
    eval(Parent + ".column_ftsm").setTextFormat(tabText);
    eval(Parent + ".column_ftsm").border = true;
    eval(Parent + ".column_ftsm").background = true;
    eval(Parent + ".column_ftsm").backgroundColor = 13421772;
    eval(Parent + ".column_ftsm")._width = _global.MaxPrFc;
    eval(Parent + ".column_ftsm")._height = _global.hght;
    eval(Parent + ".column_ftsm")._x = xx;
    eval(Parent + ".column_ftsm")._y = yy;
    xx = xx + delta + _global.MaxPrFc;
    for (x = kx; x < kx + dx; x++)
    {
        eval(Parent).createTextField("column_tsm" + x, 3 + x, 20, 20, 20, 20);
        eval(Parent + ".column_tsm" + x).html = true;
        eval(Parent + ".column_tsm" + x).htmlText = "<b>" + _global.ParX[x] + "</b>";
        eval(Parent + ".column_tsm" + x).setTextFormat(tabText);
        eval(Parent + ".column_tsm" + x).border = true;
        eval(Parent + ".column_tsm" + x).background = true;
        eval(Parent + ".column_tsm" + x).backgroundColor = 13421772;
        eval(Parent + ".column_tsm" + x)._width = _global.MaxPrAc;
        eval(Parent + ".column_tsm" + x)._height = _global.hght;
        eval(Parent + ".column_tsm" + x)._x = xx;
        eval(Parent + ".column_tsm" + x)._y = yy;
        xx = xx + delta + _global.MaxPrAc;
    } // end of for
    yy = yy + delta + _global.hght;
    xx = 50;
    for (y = ky; y < ky + dy; y++)
    {
        eval(Parent).createTextField("column_csm" + y, 100 + y, 20, 20, 20, 20);
        eval(Parent + ".column_csm" + y).html = true;
        eval(Parent + ".column_csm" + y).htmlText = "<b>" + _global.ArrFCol[y] + "</b>";
        eval(Parent + ".column_csm" + y).setTextFormat(tabText);
        eval(Parent + ".column_csm" + y).border = true;
        eval(Parent + ".column_csm" + y).background = true;
        eval(Parent + ".column_csm" + y).backgroundColor = 13421772;
        eval(Parent + ".column_csm" + y)._height = _global.hght;
        eval(Parent + ".column_csm" + y)._width = _global.MaxPrFc;
        eval(Parent + ".column_csm" + y)._x = xx;
        eval(Parent + ".column_csm" + y)._y = yy;
        xx = xx + delta + _global.MaxPrFc;
        for (x = kx; x < kx + dx; x++)
        {
            eval(Parent).createTextField("column_sm" + y + "_" + x, 500 + (y + 1) * 100 + x + 1, 20, 20, 20, 20);
            eval(Parent + ".column_sm" + y + "_" + x).html = true;
            eval(Parent + ".column_sm" + y + "_" + x).htmlText = _global.ArrPrEnd[x][y];
            eval(Parent + ".column_sm" + y + "_" + x).setTextFormat(tabText);
            eval(Parent + ".column_sm" + y + "_" + x).border = true;
            eval(Parent + ".column_sm" + y + "_" + x).background = true;
            eval(Parent + ".column_sm" + y + "_" + x).backgroundColor = 16777215;
            eval(Parent + ".column_sm" + y + "_" + x)._width = _global.MaxPrAc;
            eval(Parent + ".column_sm" + y + "_" + x)._height = _global.hght;
            eval(Parent + ".column_sm" + y + "_" + x)._x = xx;
            eval(Parent + ".column_sm" + y + "_" + x)._y = yy;
            xx = xx + delta + _global.MaxPrAc;
        } // end of for
        yy = yy + delta + _global.hght;
        xx = 50;
    } // end of for
    getURL("print:", Parent);
    trace ("page=" + _global.page);
    if (x < _global.ArrPrEnd[x].length)
    {
        kx = x;
        PrintTable(kx, ky, dx, dy);
    }
    else
    {
        kx = 0;
        if (y < _global.ArrFCol.length)
        {
            ky = y;
            PrintTable(kx, ky, dx, dy);
        }
        else
        {
            return;
        } // end else if
    } // end else if
} // End of the function
function BuildPrContent()
{
    for (i = _global.ArrPrEnd.length; i > 0; i--)
    {
        _global.ArrPrEnd.pop();
    } // end of for
    cnt = _global.ParX.length;
    for (j = 0; j < cnt; j++)
    {
        LineArr = new Array();
        LineArr.push(" " + _global.DohSumNDN[j] + " ");
        LineArr.push(" " + _global.HDev[j] + " ");
        LineArr.push(" " + _global.QuolOcrSr[j] + " ");
        LineArr.push(" " + _global.FishAm[j] + " ");
        LineArr.push(" " + _global.FPrvPar2[j] + " ");
        LineArr.push(" " + _global.VibEcl[j] + " ");
        LineArr.push(" " + _global.VibPhs[j] + " ");
        LineArr.push(" " + _global.VibOmt[j] + " ");
        LineArr.push(" " + _global.OstEcl[j] + " ");
        LineArr.push(" " + _global.OstPhs[j] + " ");
        LineArr.push(" " + _global.OstOmt[j] + " ");
        LineArr.push(" " + _global.DegrLandArr[j] + " ");
        LineArr.push(" " + _global.DegrSeaArr[j] + " ");
        LineArr.push(" " + _global.FPrvPar6[j] + " ");
        LineArr.push(" " + _global.FPrvPar7[j] + " ");
        LineArr.push(" " + _global.NasAm[j] + " ");
        LineArr.push(" " + _global.NasEncM[j] + " ");
        LineArr.push(" " + _global.ProdLive[j] + " ");
        LineArr.push(" " + _global.NRTN[j] + " ");
        LineArr.push(" " + _global.NRSC[j] + " ");
        LineArr.push(" " + _global.RabAmSum[j] + " ");
        LineArr.push(" " + _global.RabAmPar1[j] + " ");
        LineArr.push(" " + _global.RabAmPar2[j] + " ");
        LineArr.push(" " + _global.RabAmPar3[j] + " ");
        LineArr.push(" " + _global.RabAmPar4[j] + " ");
        LineArr.push(" " + _global.RabAmPar5[j] + " ");
        LineArr.push(" " + _global.RabAmPar6[j] + " ");
        LineArr.push(" " + _global.RabAmPar7[j] + " ");
        LineArr.push(" " + _global.UrZan[j] + " ");
        LineArr.push(" " + _global.UrBezr[j] + " ");
        LineArr.push(" " + _global.InvPar1[j] + " ");
        LineArr.push(" " + _global.InvPar2[j] + " ");
        LineArr.push(" " + _global.InvPar3[j] + " ");
        LineArr.push(" " + _global.InvPar4[j] + " ");
        LineArr.push(" " + _global.InvPar5[j] + " ");
        LineArr.push(" " + _global.InvPar6[j] + " ");
        LineArr.push(" " + _global.InvPar7[j] + " ");
        LineArr.push(" " + _global.CapPar1[j] + " ");
        LineArr.push(" " + _global.CapPar2[j] + " ");
        LineArr.push(" " + _global.CapPar3[j] + " ");
        LineArr.push(" " + _global.CapPar4[j] + " ");
        LineArr.push(" " + _global.CapPar5[j] + " ");
        LineArr.push(" " + _global.CapPar6[j] + " ");
        LineArr.push(" " + _global.CapPar7[j] + " ");
        LineArr.push(" " + _global.AmorPar1[j] + " ");
        LineArr.push(" " + _global.AmorPar2[j] + " ");
        LineArr.push(" " + _global.AmorPar3[j] + " ");
        LineArr.push(" " + _global.AmorPar4[j] + " ");
        LineArr.push(" " + _global.AmorPar5[j] + " ");
        LineArr.push(" " + _global.AmorPar6[j] + " ");
        LineArr.push(" " + _global.AmorPar7[j] + " ");
        LineArr.push(" " + _global.FPrvPar1[j] + " ");
        LineArr.push(" " + _global.FPrvPar2[j] + " ");
        LineArr.push(" " + _global.FPrvPar3[j] + " ");
        LineArr.push(" " + _global.FPrvPar4[j] + " ");
        LineArr.push(" " + _global.FPrvPar5[j] + " ");
        LineArr.push(" " + _global.FPrvPar6[j] + " ");
        LineArr.push(" " + _global.FPrvPar7[j] + " ");
        LineArr.push(" " + _global.DohSum[j] + " ");
        LineArr.push(" " + _global.DohPar1[j] + " ");
        LineArr.push(" " + _global.DohPar2[j] + " ");
        LineArr.push(" " + _global.DohPar3[j] + " ");
        LineArr.push(" " + _global.DohPar4[j] + " ");
        LineArr.push(" " + _global.DohPar5[j] + " ");
        LineArr.push(" " + _global.PribPar1[j] + " ");
        LineArr.push(" " + _global.PribPar2[j] + " ");
        LineArr.push(" " + _global.PribPar3[j] + " ");
        LineArr.push(" " + _global.PribPar4[j] + " ");
        LineArr.push(" " + _global.PribPar5[j] + " ");
        LineArr.push(" " + _global.ToBgtPar1[j] + " ");
        LineArr.push(" " + _global.ToBgtPar2[j] + " ");
        LineArr.push(" " + _global.ToBgtPar3[j] + " ");
        LineArr.push(" " + _global.ToBgtPar4[j] + " ");
        LineArr.push(" " + _global.ToBgtPar5[j] + " ");
        LineArr.push(" " + _global.RasprAm[j] + " ");
        LineArr.push(" " + _global.NRasprBgt[j] + " ");
        LineArr.push(" " + _global.RabAmSum[j] + " ");
        LineArr.push(" " + _global.RabAmPar1[j] + " ");
        LineArr.push(" " + _global.RabAmPar2[j] + " ");
        LineArr.push(" " + _global.RabAmPar3[j] + " ");
        LineArr.push(" " + _global.RabAmPar4[j] + " ");
        LineArr.push(" " + _global.RabAmPar5[j] + " ");
        LineArr.push(" " + _global.RabAmPar6[j] + " ");
        LineArr.push(" " + _global.RabAmPar7[j] + " ");
        _global.ArrPrEnd.push(LineArr);
    } // end of for
    _global.MaxPrAc = 0;
    cnt = _global.ParX.length;
    for (j = 0; j < cnt; j++)
    {
        for (i = 0; i < _global.ArrFCol.length; i++)
        {
            Parent = "_root";
            eval(Parent).createTextField("cell", 12900, 20, 20, 20, 20);
            eval(Parent + ".cell").html = true;
            eval(Parent + ".cell").htmlText = _global.ArrPrEnd[j][i];
            eval(Parent + ".cell").setTextFormat(tabText);
            eval(Parent + ".cell").autoSize = true;
            eval(Parent + ".cell").border = true;
            wdth = eval(Parent + ".cell")._width;
            hght = eval(Parent + ".cell")._height;
            eval(Parent + ".cell").removeTextField();
            if (_global.MaxPrAc < wdth)
            {
                _global.MaxPrAc = wdth;
            } // end if
        } // end of for
    } // end of for
    trace ("PrAc=" + _global.MaxPrAc);
    prHght = 315;
    prWdth = 534.600000;
    delta = 2;
    xx = 0;
    yy = 0;
    PrintTable(0, 0, int((prWdth - _global.MaxPrFc - delta) / (_global.MaxPrAc + delta)), int(prHght / (hght + delta)));
} // End of the function
depth_base = 10;
tabText = new TextFormat();
tabText.font = "Arial";
tabText.align = "center";
tabText.size = 8;
_global.page = 0;
depth_base_pr = 20;
_global.ArrPrEnd = new Array();

// [Action in Frame 144]
LangList.addItem("English", "eng");
LangList.addItem("Russian", "rus");

// [Action in Frame 145]
stop ();

// [Action in Frame 146]
stop ();

// [Action in Frame 177]
function TextShad()
{
    if (MC_shad._visible == true)
    {
        MC_menu.BT_new.enabled = false;
        MC_menu.BT_help.enabled = false;
        MC_menu.BT_ab.enabled = false;
        MC_menu.BT_ex.enabled = false;
        MC_topmenu.BT_menu.enabled = false;
        MC_topmenu.BT_help.enabled = false;
        MC_topmenu.BT_ab.enabled = false;
        if (msgmode == "MC_map")
        {
            MC_topmenu.BT_map.enabled = false;
        }
        else if (msgmode == "MC_charts")
        {
            MC_topmenu.BT_charts.enabled = false;
        } // end else if
        MC_help.BT_rew.enabled = false;
        MC_mapsel.BT_mapsel.enabled = false;
    }
    else
    {
        MC_menu.BT_new.enabled = true;
        MC_menu.BT_help.enabled = true;
        MC_menu.BT_ab.enabled = true;
        MC_menu.BT_ex.enabled = true;
        MC_topmenu.BT_menu.enabled = true;
        MC_topmenu.BT_help.enabled = true;
        MC_topmenu.BT_ab.enabled = true;
        if (msgmode == "MC_map")
        {
            MC_topmenu.BT_map.enabled = true;
        }
        else if (msgmode == "MC_charts")
        {
            MC_topmenu.BT_charts.enabled = true;
        } // end else if
        MC_help.BT_rew.enabled = true;
        MC_mapsel.BT_mapsel.enabled = true;
    } // end else if
} // End of the function
function ShowHelp()
{
    MC_help._visible = true;
    eval(_global.helpmode)._visible = false;
    if (_global.helpmode != "MC_menu")
    {
        MC_topmenu._visible = false;
    } // end if
} // End of the function
function ShowAbout()
{
    MC_title.ex_BT.enabled = false;
    MC_abprg._visible = true;
    MC_shad._visible = true;
} // End of the function
function ShowExit()
{
    MC_title.ex_BT.enabled = false;
    MC_exit._visible = true;
    MC_shad._visible = true;
} // End of the function
function ShowMsg()
{
    MC_title.ex_BT.enabled = false;
    MC_msg._visible = true;
    MC_shad._visible = true;
    Clock_MC._visible = false;
    TextShad();
} // End of the function
_global.helpmode = "MC_menu";
MC_menu._visible = true;
MC_mapsel._visible = false;
MC_map._visible = false;
MC_help._visible = false;
MC_anal._visible = false;
MC_shad._visible = false;
MC_topmenu._visible = false;
MC_msg._visible = false;
MC_abprg._visible = false;
MC_exit._visible = false;
Clock_MC._visible = false;
stop ();
