export default class Stopwatch {
  date: Date
  start: number

  constructor() {
    this.date = new Date()
    this.start = this.date.getTime()
  }

  getElapsed() {
    return (this.date.getTime() - this.start) / 1000
  }

  restart() {
    this.start = this.date.getTime()
  }
}
