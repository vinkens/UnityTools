using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDataTime
{
    static PlayerDataTime ins;

    public static PlayerDataTime Ins {
        get
        {
            if (null == ins)
            {
                ins = new PlayerDataTime();
            }
            return ins;
        }
     }


    #region 登录时间

    public void UpdateStartTime()
    {
        UpdateStartTime(DateTime.Now);
    }

    public void UpdateStartTime(DateTime now)
    {
        startTime = now;

        //首次启动时间
        string textFirstStartTime= PlayerPrefs.GetString("FirstStartTime");
        if (string.IsNullOrEmpty(textFirstStartTime))
        {
            IsFirstStart = true;
            firstStartTime = startTime;
            PlayerPrefs.SetString("FirstStartTime", firstStartTime.Ticks.ToString());
        }
        else
        {
            IsFirstStart = false;
            firstStartTime = new DateTime(long.Parse(textFirstStartTime));
        }

        //最后一次启动时间
        string textLastStartTime = PlayerPrefs.GetString("LastStartTime", startTime.Ticks.ToString());
        LastStartTime = new DateTime(long.Parse(textLastStartTime));
        PlayerPrefs.SetString("LastStartTime", startTime.Ticks.ToString());
        PlayerPrefs.Save();

        this.IsFirstStartOfDay = IsFirstStart || (StartTime.DayOfYear != LastStartTime.DayOfYear);

        if (IsFirstStartOfDay)
        {
            StartDayCount++;
        }

        LimitClaim();
    }



    DateTime firstStartTime;

    /// <summary>
    /// app 首次启动时间
    /// </summary>
    DateTime FirstStartTime
    {
        get
        {
            return this.firstStartTime;
        }
    }

    /// <summary>
    /// app 上次启动时间
    /// </summary>
    DateTime LastStartTime { get; set; }


    DateTime startTime;

    /// <summary>
    /// app 本次启动时间
    /// </summary>
    public DateTime StartTime
    {
        get
        {
            return startTime;
        }
    }

    /// <summary>
    /// 启动次数,每天最多累计一次
    /// </summary>
    public int StartDayCount
    {
        get
        {
            return PlayerPrefs.GetInt("StartDayCount", 0);
        }
        set
        {
            PlayerPrefs.SetInt("StartDayCount", value);
            PlayerPrefs.Save();
        }
    }


    /// <summary>
    /// 首次启动到现在的天数
    /// </summary>
    public int DaySinceFirstStart
    {
        get
        {
            TimeSpan ts = StartTime - FirstStartTime;
            return (int)ts.TotalDays;
        }

    }

    /// <summary>
    /// app 首次启动
    /// </summary>
    public bool IsFirstStart { get; private set; }

    /// <summary>
    /// 当天首次启动
    /// </summary>
    public bool IsFirstStartOfDay { get; private set; }


    /// <summary>
    /// 收集的时间点，相对于首次启动那一天
    /// </summary>
    public  int ClaimDaySinceFirstDay
    {
        get
        {
            return PlayerPrefs.GetInt("ClaimDaySinceFirstDay", -1);
        }
        set
        {
            PlayerPrefs.SetInt("ClaimDaySinceFirstDay", value);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// 连续收集的天数
    /// </summary>
    public  int ClaimDayCount
    {
        get
        {
            int day = DaySinceFirstStart - ClaimDaySinceFirstDay;
            //如果2天后没有打开，重置为0
            if (day > 2)
            {
                PlayerPrefs.SetInt("ClaimDayCount", 0);
                PlayerPrefs.Save();
            }
            return PlayerPrefs.GetInt("ClaimDayCount", 0);
        }
        set
        {
            PlayerPrefs.SetInt("ClaimDayCount", value);
            PlayerPrefs.Save();
        }
    }

    public  bool HasClaimDay
    {
        get
        {
            int day = DaySinceFirstStart - ClaimDaySinceFirstDay;
            return day > 0;
        }
    }

    public bool Claim()
    {
        if (HasClaimDay)
        {
            ClaimDayCount++;
            ClaimDaySinceFirstDay = DaySinceFirstStart;
            return true;
        }

        return false;
    }

    void LimitClaim()
    {
        //如果连续收集了7天，重写开始
        if (ClaimDayCount >= 7)
        {
            ClaimDayCount = 0;
        }
    }

    #endregion
}
