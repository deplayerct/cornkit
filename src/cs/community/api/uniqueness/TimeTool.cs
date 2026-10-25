// SPDX-License-Identifier: MIT
// @path: src/cs/community/api/uniqueness/TimeTool.cs
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
    private readonly bool _isInstant;

    private int _utcOffset;
    private DateOnly _date;
    private TimeOnly _time;

    private int _year;
    private int _month;
    private int _day;
    private int _hours;
    private int _minutes;
    private int _seconds;

    private int _yearStart;
    private int _monthStart;
    private int _dayStart;
    private int _hoursStart;
    private int _minutesStart;
    private int _secondsStart;

    private int _yearEnd;
    private int _monthEnd;
    private int _dayEnd;
    private int _hoursEnd;
    private int _minutesEnd;
    private int _secondsEnd;

    private DateTime _startTime;
    private DateTime _endTime;

    /// <summary>
    /// Corn.kit Timer 工具类构造函数。<br/>
    /// </summary>
    /// <param name="recordingDateTimeOrNot">是否记录时刻。如果否，则记录时间</param>
    /// <param name="utcOffset">时区设置</param>
    public TimeTool(bool recordingDateTimeOrNot, int utcOffset)
    {
        this._isInstant = recordingDateTimeOrNot;
        this._utcOffset = utcOffset;
    }

    /// <summary>
    /// 静态时刻记录器。<br/>
    /// 手动输入 DateOnly 和 TimeOnly 类型，前者日期，后者当天时间。<br/>
    /// </summary>
    public void TimeRecord(DateOnly date, TimeOnly time)
    {
        if (_isInstant)
        {
            this._date = date;
            this._time = time;
        }
    }

    /// <summary>
    /// 静态时刻记录器。<br/>
    /// 手动输入年月日时分秒。<br/>
    /// 不使用 DateOnly 和 TimeOnly 类型，而是Int类型。<br/>
    /// </summary>
    public void TimeRecord(int year, int month, int day, int hours, int minutes, int seconds)
    {
        if (_isInstant)
        {
            this._year = year;
            this._month = month;
            this._day = day;
            this._hours = hours;
            this._minutes = minutes;
            this._seconds = seconds;
        }
    }

    /// <summary>
    /// 静态时间记录器。<br/>
    /// 手动输入 DateTime 类型。<br/>
    /// </summary>
    public void T2TRecord(DateTime startTime, DateTime endTime)
    {
        if (_isInstant == false)
        {
            this._startTime = startTime;
            this._endTime = endTime;
        }
    }

    /// <summary>
    /// 静态时间记录器。<br/>
    /// 手动输入开始和结束的年月日时分秒。<br/>
    /// 不使用 DateTime 类型，而是Int类型。<br/>
    /// </summary>
    public void T2TRecord(int yearStart, int monthStart, int dayStart, int hoursStart, int minutesStart, int secondsStart,
        int yearEnd, int monthEnd, int dayEnd, int hoursEnd, int minutesEnd, int secondsEnd)
    {
        if (_isInstant == false)
        {
            this._yearStart = yearStart;
            this._monthStart = monthStart;
            this._dayStart = dayStart;
            this._hoursStart = hoursStart;
            this._minutesStart = minutesStart;
            this._secondsStart = secondsStart;

            this._yearEnd = yearEnd;
            this._monthEnd = monthEnd;
            this._dayEnd = dayEnd;
            this._hoursEnd = hoursEnd;
            this._minutesEnd = minutesEnd;
            this._secondsEnd = secondsEnd;
        }
    }
}
