﻿using System;

using Windows.UI.Core;
using Windows.UI.ViewManagement;

using WTS_Demos.Helpers;

namespace WTS_Demos.Services
{
    // A custom event that fires whenever the secondary view is ready to be closed. You should
    // clean up any state (including deregistering for events) then close the window in this handler
    public delegate void ViewReleasedHandler(object sender, EventArgs e);

    // Whenever the main view is about to interact with the secondary view, it should call
    // StartViewInUse on this object. When finished interacting, it should call StopViewInUse.
    public sealed class ViewLifetimeControl
    {
        // Window for this particular view. Used to register and unregister for events
        private CoreWindow _window;
        private int _refCount = 0;
        private bool _released = false;

        private event ViewReleasedHandler InternalReleased;

        // Necessary to communicate with the window
        public CoreDispatcher Dispatcher { get; private set; }

        // This id is used in all of the ApplicationViewSwitcher and ProjectionManager APIs
        public int Id { get; private set; }

        public string Title { get; set; }

        public event ViewReleasedHandler Released
        {
            add
            {
                bool releasedCopy = false;
                lock (this)
                {
                    releasedCopy = _released;
                    if (!_released)
                    {
                        InternalReleased += value;
                    }
                }

                if (releasedCopy)
                {
                    throw new InvalidOperationException("ExceptionViewLifeTimeControlViewDisposal".GetLocalized());
                }
            }

            remove
            {
                lock (this)
                {
                    InternalReleased -= value;
                }
            }
        }

        private ViewLifetimeControl(CoreWindow newWindow)
        {
            Dispatcher = newWindow.Dispatcher;
            _window = newWindow;
            Id = ApplicationView.GetApplicationViewIdForWindow(_window);
            RegisterForEvents();
        }

        public static ViewLifetimeControl CreateForCurrentView()
        {
            return new ViewLifetimeControl(CoreWindow.GetForCurrentThread());
        }

        // Signals that the view is being interacted with by another view,
        // so it shouldn't be closed even if it becomes "consolidated"
        public int StartViewInUse()
        {
            bool releasedCopy = false;
            int refCountCopy = 0;

            lock (this)
            {
                releasedCopy = _released;
                if (!_released)
                {
                    refCountCopy = ++_refCount;
                }
            }

            if (releasedCopy)
            {
                throw new InvalidOperationException("ExceptionViewLifeTimeControlViewDisposal".GetLocalized());
            }

            return refCountCopy;
        }

        // Should come after any call to StartViewInUse
        // Signals that the another view has finished interacting with the view tracked by this object
        public int StopViewInUse()
        {
            int refCountCopy = 0;
            bool releasedCopy = false;

            lock (this)
            {
                releasedCopy = _released;
                if (!_released)
                {
                    refCountCopy = --_refCount;
                    if (refCountCopy == 0)
                    {
                        var task = Dispatcher.RunAsync(CoreDispatcherPriority.Low, FinalizeRelease);
                    }
                }
            }

            if (releasedCopy)
            {
                throw new InvalidOperationException("ExceptionViewLifeTimeControlViewDisposal".GetLocalized());
            }

            return refCountCopy;
        }

        private void RegisterForEvents()
        {
            ApplicationView.GetForCurrentView().Consolidated += ViewConsolidated;
        }

        private void UnregisterForEvents()
        {
            ApplicationView.GetForCurrentView().Consolidated -= ViewConsolidated;
        }

        private void ViewConsolidated(ApplicationView sender, ApplicationViewConsolidatedEventArgs e)
        {
            StopViewInUse();
        }

        private void FinalizeRelease()
        {
            bool justReleased = false;
            lock (this)
            {
                if (_refCount == 0)
                {
                    justReleased = true;
                    _released = true;
                }
            }

            if (justReleased)
            {
                UnregisterForEvents();
                InternalReleased(this, null);
            }
        }
    }
}
