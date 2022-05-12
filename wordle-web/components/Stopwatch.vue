<template>
  <v-container>
    <v-card v-model="displayTime">hello {{ displayTime }}</v-card>
    <v-btn>HI</v-btn>
  </v-container>
</template>

<script lang="ts">
import { Vue } from 'vue-property-decorator'

export default class stopwatch extends Vue {
  startTime = new Date().getTime()
  currentTime = new Date()
  displayTime: number = 0
  // start() {
  curTime = setInterval(() => this.getDif(), 1000)
  // }

  getDif() {
    this.displayTime = this.currentTime.getTime() - this.startTime
    console.log(this.displayTime)
    // return this.displayTime
  }

  // data() {
  //   return {
  //     get seconds() {
  //       const seconds = Math.ceil(
  //         (new Date().getTime() - this.startTime) / 1000
  //       )
  //       return seconds
  //     },
  //     watch: {
  //       updateTime(seconds) {
  //         this.time = seconds
  //       },
  //     },
  //   }
  // }
}
</script>
