using Windows.ApplicationModel.Background;

namespace WTS_Demos.Services
{
    internal interface IBackgroundTaskService
    {
        void RegisterBackgroundTasks();

        void Start(IBackgroundTaskInstance taskInstance);
    }
}
