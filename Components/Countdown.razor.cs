using System.Timers;
using Microsoft.AspNetCore.Components;

namespace QuizGame.Components;

public partial class Countdown : ComponentBase, IDisposable
{
    [Parameter]
    public EventCallback TimerOut { get; set; }
    private System.Timers.Timer _timer = null!;
    private int _secondsToRun = 0;
    protected string Time { get; set; } = "00:00";
    public int TimeBarWidthNumber { get; set; } = 0;

    public string TimeBarWidthStyle => TimeBarWidthNumber + "px";
    public string countdownVisibility { get; set; } = "hidden";

    protected override async Task OnInitializedAsync()
    {
        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += OnTimedEvent;
        _timer.AutoReset = true;
    }
    
    public void Start(int secondsToRun, int timeBarwidth)
    {
        _secondsToRun = secondsToRun;
        TimeBarWidthNumber = timeBarwidth;

        if (_secondsToRun > 0)
        {
            Time = TimeSpan.FromSeconds(_secondsToRun).ToString(@"mm\:ss");
            StateHasChanged();
            _timer.Start();
        }
    }

    public void Stop()
    {
        _timer.Stop();
    }
    
    private void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
        _ = HandleTimerElapsedAsync();
    }

    private async Task HandleTimerElapsedAsync()
    {
        _secondsToRun--;
        TimeBarWidthNumber -= 20;

        await InvokeAsync(() =>
        {
            Time = TimeSpan.FromSeconds(_secondsToRun).ToString(@"mm\:ss");
            StateHasChanged();
        });

        if (_secondsToRun <= 0)
        {
            _timer.Stop();
            await TimerOut.InvokeAsync();
        }
    }

    public void Dispose()
    {
        _timer.Dispose();    
    }
}