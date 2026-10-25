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

    private readonly int _utcOffset;
    private DateOnly _date;
    private TimeOnly _time;

    private bool _timerStarted;

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

    private DateTimeOffset _startTime;
    private DateTimeOffset _endTime;

    /// <summary>
    /// Corn.kit Timer 工具类构造函数。<br/>
    /// </summary>
    /// <param name="recordingInstantOrNot">是否记录时刻。如果否，则记录时间</param>
    /// <param name="utcOffset">时区设置</param>
    public TimeTool(bool recordingInstantOrNot, int utcOffset)
    {
        this._isInstant = recordingInstantOrNot;
        this._utcOffset = utcOffset;
    }

    /// <summary>
    /// 静态时刻记录器。<br/>
    /// 手动输入 DateOnly 和 TimeOnly 类型，前者日期，后者当天时间。<br/>
    /// </summary>
    public void TimeRecord(DateOnly date, TimeOnly time)
    {
        if (!_isInstant)
        {
            return;
        }

        this._date = date;
        this._time = time;
    }

    /// <summary>
    /// 静态时刻记录器。<br/>
    /// 手动输入年月日时分秒。<br/>
    /// 不使用 DateOnly 和 TimeOnly 类型，而是Int类型。<br/>
    /// </summary>
    public void TimeRecord(int year, int month, int day, int hours, int minutes, int seconds)
    {
        if (!_isInstant)
        {
            return;
        }

        this._year = year;
        this._month = month;
        this._day = day;
        this._hours = hours;
        this._minutes = minutes;
        this._seconds = seconds;
    }

    /// <summary>
    /// 静态时间记录器。<br/>
    /// 手动输入 DateTimeOffset 类型。<br/>
    /// </summary>
    public void T2TRecord(DateTimeOffset startTime, DateTimeOffset endTime)
    {
        if (_isInstant)
        {
            return;
        }

        this._startTime = startTime;
        this._endTime = endTime;
    }

    /// <summary>
    /// 静态时间记录器。<br/>
    /// 手动输入开始和结束的年月日时分秒。<br/>
    /// 不使用 DateTime 类型，而是Int类型。<br/>
    /// </summary>
    public void T2TRecord(int yearStart, int monthStart, int dayStart, int hoursStart, int minutesStart,
        int secondsStart,
        int yearEnd, int monthEnd, int dayEnd, int hoursEnd, int minutesEnd, int secondsEnd)
    {
        if (_isInstant)
        {
            return;
        }

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

    /// <summary>
    /// 动态时刻记录器。<br/>
    /// 自动获取当前时间，同时填充 DateOnly/TimeOnly 与 int 两套字段。<br/>
    /// </summary>
    public void TimeRecord()
    {
        if (!_isInstant)
        {
            return;
        }

        DateTimeOffset now = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(_utcOffset));

        // now.DateTime 返回按 _utcOffset 表示的墙钟时间，Kind = Unspecified，
        // 正好适合转成 DateOnly / TimeOnly，不会被误当作 UTC 再偏移。
        _date = DateOnly.FromDateTime(now.DateTime);
        _time = TimeOnly.FromDateTime(now.DateTime);

        _year = now.Year;
        _month = now.Month;
        _day = now.Day;
        _hours = now.Hour;
        _minutes = now.Minute;
        _seconds = now.Second;
    }

    /// <summary>
    /// 动态时间记录器。<br/>
    /// 首次调用记录起点，再次调用记录终点，可反复使用。<br/>
    /// 同时填充 DateTimeOffset 与 int 两套字段。<br/>
    /// 如需要判断是否在计时状态，请参考<see cref="IsTimerStarted"/>。
    /// </summary>
    public void T2TRecord()
    {
        if (_isInstant)
        {
            return;
        }

        DateTimeOffset now = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(_utcOffset));

        if (!_timerStarted)
        {
            _startTime = now;
            _yearStart = now.Year;
            _monthStart = now.Month;
            _dayStart = now.Day;
            _hoursStart = now.Hour;
            _minutesStart = now.Minute;
            _secondsStart = now.Second;
            _timerStarted = true;
        }
        else
        {
            _endTime = now;
            _yearEnd = now.Year;
            _monthEnd = now.Month;
            _dayEnd = now.Day;
            _hoursEnd = now.Hour;
            _minutesEnd = now.Minute;
            _secondsEnd = now.Second;
            _timerStarted = false;
        }
    }

    /// <summary>
    /// 表示当前是否处于计时状态。
    /// </summary>
    /// <value>true 表示正在计时，false 表示未在计时。</value>
    public bool IsTimerStarted => _timerStarted;

    /// <summary>
    /// 尝试获取上一次计时的时长。
    /// </summary>
    /// <param name="span">成功时输出起止点差值。</param>
    /// <returns>
    /// 若当前为时刻模式、计时尚未结束、未记录起止点、起止点非法或终点早于起点，
    /// 返回 <c>false</c>；否则返回 <c>true</c>。
    /// </returns>
    private bool TryGetElapsedSpan(out TimeSpan span)
    {
        span = default;

        if (_isInstant || _timerStarted)
        {
            return false;
        }

        DateTimeOffset start;
        DateTimeOffset end;

        if (_startTime != default && _endTime != default)
        {
            start = _startTime;
            end = _endTime;
        }
        else if (_yearStart != 0 && _yearEnd != 0)
        {
            TimeSpan offset = TimeSpan.FromHours(_utcOffset);
            try
            {
                start = new DateTimeOffset(
                    _yearStart, _monthStart, _dayStart,
                    _hoursStart, _minutesStart, _secondsStart, offset);
                end = new DateTimeOffset(
                    _yearEnd, _monthEnd, _dayEnd,
                    _hoursEnd, _minutesEnd, _secondsEnd, offset);
            }
            catch (ArgumentOutOfRangeException)
            {
                // 调用方传入了非法日期（如 2 月 30 日）或非法时分秒
                return false;
            }
        }
        else
        {
            return false;
        }

        if (end < start)
        {
            return false;
        }

        span = end - start;
        return true;
    }

    /// <summary>
    /// 在计时完成后，计算上一次计时的时间长度，精确到毫秒。
    /// </summary>
    /// <returns>
    /// 格式为 <c>{天:D7}d-{时:D2}:{分:D2}:{秒:D2}.{毫秒:D3}</c> 的字符串，
    /// 例如 <c>0000000d-00:00:05.123</c>。
    /// 天数按 24 小时累计，不受日历月份、闰年影响。
    /// 若当前不处于"已完成一次计时"的状态，返回 <see cref="string.Empty"/>。
    /// </returns>
    public string TotalTime()
    {
        if (!TryGetElapsedSpan(out TimeSpan span))
        {
            return string.Empty;
        }

        return $"{span.Days:D7}d-{span.Hours:D2}:{span.Minutes:D2}:{span.Seconds:D2}.{span.Milliseconds:D3}";
    }

    /// <summary>
    /// 表示上一次计时的总秒数（向下取整）。
    /// </summary>
    /// <value>
    /// 已完成一次计时时返回实际经过的秒数；
    /// 若当前不处于"已完成一次计时"的状态，返回 <c>0</c>。
    /// </value>
    public long TotalSeconds
    {
        get
        {
            if (!TryGetElapsedSpan(out TimeSpan span))
            {
                return 0;
            }

            return (long)span.TotalSeconds;
        }
    }

    /// <summary>
    /// 表示上一次计时的总毫秒数（向下取整）。
    /// </summary>
    /// <value>
    /// 已完成一次计时时返回实际经过的毫秒数；
    /// 若当前不处于"已完成一次计时"的状态，返回 <c>0</c>。
    /// </value>
    public long TotalMilliseconds
    {
        get
        {
            if (!TryGetElapsedSpan(out TimeSpan span))
            {
                return 0;
            }

            return (long)span.TotalMilliseconds;
        }
    }
}