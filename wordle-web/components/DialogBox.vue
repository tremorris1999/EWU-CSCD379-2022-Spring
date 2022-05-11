<template>
  <v-alert width="80%" class="ma-auto">
    <v-card class="dialog_content">
      <h2 class="dialog_title ml-3">Save Stats?</h2>
      <v-row>
        <v-text-field
          name="username"
          id="username"
          placeholder="create a username"
          class="px-6 mt-4"
          outlined
          v-model="userName"
        ></v-text-field>
      </v-row>
      <v-container>
        <v-btn class="dontSavePlayAgain mx-6 purple" @click="playGame()"
          >nevermind, i'll play again without saving</v-btn
        >
        <v-btn class="saveCredentials mx-6 green" @click="saveCredentials()"
          >save username {{ userName }}</v-btn
        >
      </v-container>
    </v-card>
  </v-alert>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class DialogBox extends Vue {
  visible: boolean = false

  userName: string = ''

  playGame() {}



  showDialog() {
    this.visible = !this.visible
  }
}
</script>