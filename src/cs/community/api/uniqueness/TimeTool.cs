// SPDX-License-Identifier: MIT
// @path: src/cs/community/api/unique_tool/TimeTool.cs
/*
 * Copyright (c) 2026 DeplayerCT
 * Author : Deplayer515 <deplayer515@hotmail.com>
*/

namespace DeplayerCT.Corn.kit.community.api.uniqueness;

/// <summary>
/// Corn.kit Timer 工具类。<br/>
/// 用于验时、存储时间或时刻记录等场景。<br/>
/// </summary>
public class TimeTool
{
    /// <summary>
    /// 确定是记录时刻还是时间的关键bool
    /// </summary>
    private readonly bool _isDataTime;

    private int UtcOffset;
    private DateOnly Date;
    private TimeOnly Time;
    
    private int Year;
    private int Month;
    private int Day;
    private int Hours;
    private int Minutes;
    private int Seconds;
    
    private int Year_START;
    private int Month_START;
    private int Day_START;
    private int Hours_START;
    private int Minutes_START;
    private int Seconds_START;
    
    private int Year_END;
    private int Month_END;
    private int Day_END;
    private int Hours_END;
    private int Minutes_END;
    private int Seconds_END;
    
    
    private DateTime StartTime;
    private DateTime EndTime;
    
    /// <summary>
    /// Corn.kit Timer 工具类构造函数。<br/>
    /// </summary>
    /// <param name="recordingDateTimeOrNot">是否记录时刻。如果否，则记录时间</param>
    /// <param name="utcOffset">时区设置</param>
    public TimeTool(bool recordingDateTimeOrNot, int utcOffset)
    {
        this._isDataTime = recordingDateTimeOrNot;
        this.UtcOffset = utcOffset;
    }
    
    /// <summary>
    /// 静态时刻记录器。<br/>
    /// 手动输入 DateOnly 和 TimeOnly 类型，前者日期，后者当天时间。<br/>
    /// </summary>
    public void TimeRecord(DateOnly date, TimeOnly time)
    {
        if (_isDataTime)
        {
            this.Date = date;
            this.Time = time;
        }
    }
    
    /// <summary>
    /// 静态时刻记录器。<br/>
    /// 手动输入年月日时分秒。<br/>
    /// 不使用 DateOnly 和 TimeOnly 类型，而是Int类型。<br/>
    /// </summary>
    public void TimeRecord(int year, int month, int day, int hours, int minutes, int seconds)
    {
        if (_isDataTime)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }
    }
    
    /// <summary>
    /// 静态时间记录器。<br/>
    /// 手动输入 DateTime 类型。<br/>
    /// </summary>
    public void T2TRecord(DateTime startTime, DateTime endTime)
    {
        if (_isDataTime == false)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
    
    /// <summary>
    /// 静态时间记录器。<br/>
    /// 手动输入开始和结束的年月日时分秒。<br/>
    /// 不使用 DateTime 类型，而是Int类型。<br/>
    /// </summary>
    public void T2TRecord(int year_start, int month_start, int day_start, int hours_start, int minutes_start, int seconds_start,
        int year_end, int month_end, int day_end, int hours_end, int minutes_end, int seconds_end)
    {
        if (_isDataTime == false)
        {
            this.Year_START = year_start;
            this.Month_START = month_start;
            this.Day_START = day_start;
            this.Hours_START = hours_start;
            this.Minutes_START = minutes_start;
            this.Seconds_START = seconds_start;

            this.Year_END = year_end;
            this.Month_END = month_end;
            this.Day_END = day_end;
            this.Hours_END = hours_end;
            this.Minutes_END = minutes_end;
            this.Seconds_END = seconds_end;
        }
    }
}