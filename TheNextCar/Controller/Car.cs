using System;
using System.Collections.Generic;
using TheNextCar.Controller;
using System.Text;

namespace TheNextCar.Controller
{
    class Car
    {
        AccubatteryController accubatteryController;
        DoorController doorController;
        OnCarEngineStatusChanged callbackCarEngineStatusChanged;
        public Car(AccubatteryController accubaterryController,
        DoorController doorController,
        OnCarEngineStatusChanged callbackCarEngineStatusChanged)
        {
            this.accubatteryController = accubaterryController;
            this.doorController = doorController;
            this.callbackCarEngineStatusChanged = callbackCarEngineStatusChanged;
        }
        public void turnOnPower()
        {
            this.accubatteryController.turnOn();
        }
        public void turnOfPower()
        {
            this.accubatteryController.turnOff();
        }
        public bool powerIsReady()
        {
            return this.accubatteryController.accubatterryIsOn();
        }
        public void closeTheDoor()
        {
            this.doorController.close();
        }
        public void openTheDoor()
        {
            this.doorController.open();
        }
        public void lockTheDoor()
        {
            this.doorController.activateLock();
        }
        public void unlockTheDoor()
        {
            this.doorController.unlock();
        }
        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }
        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }
        public void toggleStartEngineButton()
        {
            if (!doorIsClosed())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "door is open");
                return;
            }
            if (!doorIsLocked())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "door unlocked");
                return;
            }
            if (!powerIsReady())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED",
                "no power available");
                return;
            }
            this.callbackCarEngineStatusChanged.carEngineStatusChanged("STARTED", "Engine started");
        }
        public void toggleTheLoockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.lockTheDoor();
            }
            else
            {
                this.unlockTheDoor();
            }
        }
        public void toggleTheDoorButton()
        {
            if (!doorIsClosed())
            {
                this.closeTheDoor();
            }
            else
            {
                this.openTheDoor();
            }
        }
        public void toggleThePowerButton()
        {
            if (!powerIsReady())
            {
                this.turnOnPower();
            }
            else
            {
                this.turnOfPower();
            }
        }
    }
    interface OnCarEngineStatusChanged
    {
        void carEngineStatusChanged(string value, string message);
    }
}
