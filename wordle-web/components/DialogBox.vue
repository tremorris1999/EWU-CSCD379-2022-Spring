<template>
  <v-dialog width="80%" class="ma-auto" v-model="visible" persistent>
    <template #activator="{ on, attrs }">
      <v-btn v-bind="attrs" v-on="on" v-model="name">
        Hello, {{ user }}!
      </v-btn>
    </template>

    <v-card class="dialog_content">
      <h2 class="dialog_title ml-3">Save Stats?</h2>
      <v-row>
        <v-text-field
          v-model="user"
          name="username"
          placeholder="create a username"
          class="px-6 mt-4"
          outlined
          maxlength="14"
        ></v-text-field>
      </v-row>
      <v-container>
        <v-btn class="dontSavePlayAgain mx-6 purple" @click="visible = false"
          >nevermind, i'll play without saving</v-btn
        >
        <v-btn class="saveCreds mx-6 green" @click="visible = false"
          >save username {{ userName }}</v-btn
        >
      </v-container>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component
export default class DialogBox extends Vue {
  visible: boolean = false
  user: string = 'Guest'
}
</script>
