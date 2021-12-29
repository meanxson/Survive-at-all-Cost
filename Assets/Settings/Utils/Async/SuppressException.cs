using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public struct SuppressException : ICriticalNotifyCompletion
{
    private Task _task;
    public bool IsCompleted => _task.IsCompleted;
    
    public static SuppressException Await(Task task) => new SuppressException {_task = task};
    
    public SuppressException GetAwaiter() => this;
    
    public void OnCompleted(Action action) => _task.GetAwaiter().OnCompleted(action);
    
    public void UnsafeOnCompleted(Action action) => _task.GetAwaiter().UnsafeOnCompleted(action);

    public void GetResult()
    {
    }
}