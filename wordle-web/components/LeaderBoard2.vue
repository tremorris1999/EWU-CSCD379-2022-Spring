<template>
  <v-container>
    <v-row 
      v-for="t in arr"
      :key="t"
      justify="center"
      >
      <v-col col="8"  justify="center">
        {{t.name}}
      </v-col>
      <v-col cols="4">
        {{t.score}}
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'

  type testData = {
    name: string;
    score: number;
  }


@Component
export default class LeaderBoard2 extends Vue{
  arr: testData[] = [
    {'name': "test1", 'score': 1},
    {'name': "test2", 'score': 2},
    {'name': "test3", 'score': 3},
    {'name': "test4", 'score': 4},
    {'name': "test5", 'score': 5},
    {'name': "test6", 'score': 6},
    {'name': "test7", 'score': 7},
    {'name': "test8", 'score': 8},
    {'name': "test9", 'score': 9},
    {'name': "test10", 'score': 10}
  ]
}
</script>