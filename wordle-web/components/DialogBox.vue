<template>
  <v-alert width="80%" class="ma-auto">
    <v-card class="dialog_content">
      <h2 class="dialog_title ml-3">Save Stats?</h2>
      <v-row>
        <v-text-field
          v-model="userName"
          name="username"
          placeholder="create a username"
          class="px-6 mt-4"
          outlined
          @change="emitUserName()"
        ></v-text-field>
      </v-row>
      <v-container>
        <v-btn class="dontSavePlayAgain mx-6 purple" @click="noSave()"
          >nevermind, i'll play without saving</v-btn
        >
        <v-btn class="saveCreds mx-6 green" @click="saveCredentials()"
          >save username {{ userName }}</v-btn
        >
      </v-container>
    </v-card>
  </v-alert>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component
export default class DialogBox extends Vue {
  visible: boolean = false

  // @Prop({ required: true })
  userName: string = 'Guest'

  noSave() {
    console.log('http post here')
    this.$emit('reset', this.userName)
  }

  saveCredentials() {
    console.log('http post here')
    // POST
    this.$emit('reset', this.userName)
  }

  visibility(v: boolean) {
    this.visible = v
  }

  emitUserName() {
    this.$emit('update-user', this.userName)
  }
}
</script>
