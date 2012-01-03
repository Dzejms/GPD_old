Timer = function () {
    this.timeLeft = 0;

    this.Tick = function () {
        this.timeLeft--;
    };

    this.Start = function (seconds) {
        this.timeLeft = seconds;
    };

    this.Minutes = function () {
        return Math.floor(this.timeLeft / 60);
    };

    this.Seconds = function () {
        return this.timeLeft - (this.Minutes() * 60);
    };

    this.FormattedSeconds = function () {
        if (this.Seconds() < 10) {
            return "0" + this.Seconds();
        } else {
            return this.Seconds();
        }
    };

    this.FormattedMinutes = function () {
        if (this.Minutes() < 10) {
            return "0" + this.Minutes();
        } else {
            return this.Minutes();
        }
    };

    this.FormattedTime = function () {
        if (this.timeLeft > 0) {
            return this.FormattedMinutes() + ":" + this.FormattedSeconds();
        } else {
            return "00:00";
        }
    };
};
taskTimer = new Timer();
taskTimer.Start(60 * 25);
function UpdateTime() {
    taskTimer.Tick();
    jQuery('#timeLeft').html(taskTimer.FormattedTime()); 
}
setInterval("UpdateTime();", 1000);
