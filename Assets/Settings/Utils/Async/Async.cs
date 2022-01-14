using System.Threading;
using System.Threading.Tasks;

namespace Settings.Utils.Async
{
    public static class Async
    {
        public static Task<bool> DelayWithoutCancellationException(int delayMilliseconds, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            var ctr = default(CancellationTokenRegistration);

            Timer timer = null;

            timer = new Timer(_ =>
            {
                ctr.Dispose();
                timer.Dispose();
                tcs.TrySetResult(false);
            }, null, Timeout.Infinite, Timeout.Infinite);

            ctr = cancellationToken.Register(() =>
            {
                timer.Dispose();
                tcs.TrySetResult(true);
            });

            timer.Change(delayMilliseconds, Timeout.Infinite);

            return tcs.Task;
        }
    }
}