﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.Common.Enums
{
    public enum RecordNameEnum
    {
        Rca,
        Rce,
        Rcw,
        Rco,
        Rcs,
        Rct,
        Rcu,
        Rcv,
        Rcf,
    }

    public enum FieldTypeEnum
    {
        Numerical_Only,
        Numerical_RightJustify_Zero,
        Numerical_LeftJustify_Blank,
        UpperCase_LeftJustify_Blank,
        CaseSensitive_LeftJustify,
    }

    public enum ZipCodeEnum
    {
        AL = 01,
        AK = 02,
        AZ = 04,
        AR = 05,
        CA = 06,
        CO = 08,
        CT = 09,
        DE = 10,
        DC = 11,
        FL = 12,
        GA = 13,
        HI = 15,
        ID = 16,
        IL = 17,
        IN = 18,
        IA = 19,
        KS = 20,
        KY = 21,
        LA = 22,
        ME = 23,
        MD = 24,
        MA = 25,
        MI = 26,
        MN = 27,
        MS = 28,
        MO = 29,
        MT = 30,
        NE = 31,
        NV = 32,
        NH = 33,
        NJ = 34,
        NM = 35,
        NY = 36,
        NC = 37,
        ND = 38,
        OH = 39,
        OK = 40,
        OR = 41,
        PA = 42,
        RI = 44,
        SC = 45,
        SD = 46,
        TN = 47,
        TX = 48,
        UT = 49,
        VT = 50,
        VA = 51,
        WA = 53,
        WV = 54,
        WI = 55,
        WY = 56,
    }

    public enum TERRITORIES_AND_POSSESSIONS
    {
        AS,
        GU,
        MP,
        PR,
        VI,
    }

    public enum MILITARY_POST_OFFICES
    {
        AP,
        AE,
        AA,
    }
    public enum CountryCode
    {
        AF,
        AX,
        AL,
        AG,
        AN,
        AO,
        AV,
        AY,
        AC,
        AR,
        AM,
        AA,
        AT,
        AS,
        AU,
        AJ,
        BF,
        BA,
        FQ,
        BG,
        BB,
        BS,
        BO,
        BE,
        BH,
        BN,
        BD,
        BT,
        BL,
        BK,
        BC,
        BV,
        BR,
        IO,
        BX,
        BU,
        UV,
        BM,
        BY,
        CB,
        CM,
        CA,
        CV,
        CJ,
        CT,
        CD,
        CI,
        CH,
        KT,
        IP,
        CK,
        CO,
        CN,
        CG,
        CF,
        CW,
        CR,
        CS,
        IV,
        HR,
        CU,
        UC,
        CY,
        EZ,
        DA,
        DX,
        DJ,
        DO,
        DR,
        EC,
        EG,
        ES,
        UK,
        EK,
        ER,
        EN,
        ET,
        EU,
        FK,
        FO,
        FJ,
        FI,
        FR,
        FG,
        FP,
        FS,
        GB,
        GA,
        GZ,
        GG,
        GM,
        GH,
        GI,
        GO,
        GR,
        GL,
        GJ,
        GP,
        GT,
        GK,
        GV,
        PU,
        GY,
        HA,
        HM,
        HO,
        HK,
        HQ,
        HU,
        IC,
        IN,
        ID,
        IR,
        IZ,
        EI,
        IS,
        IT,
        JM,
        JN,
        JA,
        DQ,
        JE,
        JQ,
        JO,
        JU,
        KZ,
        KE,
        KQ,
        KR,
        KN,
        KS,
        KV,
        KU,
        KG,
        LA,
        LG,
        LE,
        LT,
        LI,
        LY,
        LS,
        LH,
        LU,
        MC,
        MK,
        MA,
        MI,
        MY,
        MV,
        ML,
        MT,
        IM,
        RM,
        MB,
        MR,
        MP,
        MF,
        MX,
        FM,
        MQ,
        MD,
        MN,
        MG,
        MJ,
        MH,
        MO,
        MZ,
        WA,
        NR,
        BQ,
        NP,
        NL,
        NC,
        NZ,
        NU,
        NG,
        NI,
        NE,
        NM,
        NF,
        NO,
        MU,
        PK,
        PS,
        LQ,
        PM,
        PP,
        PF,
        PA,
        PE,
        RP,
        PC,
        PL,
        PO,
        QA,
        RE,
        RO,
        RS,
        RW,
        TB,
        SH,
        SC,
        ST,
        RN,
        SB,
        VC,
        WS,
        SM,
        TP,
        SA,
        SG,
        RI,
        SE,
        SL,
        SN,
        NN,
        LO,
        SI,
        BP,
        SO,
        SF,
        SX,
        OD,
        SP,
        PG,
        CE,
        SU,
        NS,
        SV,
        WZ,
        SW,
        SZ,
        SY,
        TW,
        TI,
        TZ,
        TH,
        TT,
        TO,
        TL,
        TN,
        TD,
        TE,
        TS,
        TU,
        TX,
        TK,
        TV,
        UG,
        UP,
        AE,
        UY,
        UZ,
        NH,
        VT,
        VE,
        VM,
        VI,
        WQ,
        WF,
        WE,
        WI,
        YM,
        ZA,
        ZI,
        OC,
    }

    public enum PreparerCodeEnum
    {
        A,
        L,
        S,
        P,
        O,
    }

    public enum KindOfEmployerEnum
    {
        F,
        S,
        T,
        Y,
        N,
    }
    public enum AgentIndicatorCodeEnum
    {
        One = 1,
        Two = 2,
        Three = 3,
    }

    public enum EmploymentCodeEnum
    {
        A,
        H,
        M,
        Q,
        X,
        F,
        R,
    }
}
