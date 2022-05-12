
export function stopwatch() {
    const startTime = new Date().getTime();
    return {
        get seconds() {
            const seconds = Math.ceil((new Date().getTime() - startTime)/1000)
            return seconds;
        }
    }
}

