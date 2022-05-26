export class Stopwatch {
  startTime: number = 0;
  currentTime: number = 0;
  UpdateProcess: any;
  isRunning: boolean = false;

  Start(): void {
    this.startTime = Date.now()
    this.currentTime = 0
    this.UpdateProcess = setInterval(() => {
      this.currentTime = Date.now() - this.startTime
    });
    this.isRunning = true
  }

  Stop(): void {
    clearInterval(this.UpdateProcess)
    this.isRunning = false
  }

  getFormattedTime() {
    // Fun time formatting things
    return ((this.currentTime / 1000 / 60 / 60) > 1 ? Math.floor(this.currentTime / 1000 / 60 / 60) + ":" : "") // Hours or nothing
      + Math.floor(this.currentTime / 1000 / 60) % 60 // Minutes
      + ":" // minute divider
      + (Math.floor(this.currentTime / 1000 % 60) < 10 ? '0' + Math.floor(this.currentTime / 1000 % 60) : Math.floor(this.currentTime / 1000 % 60)) // Seconds
  }
}
