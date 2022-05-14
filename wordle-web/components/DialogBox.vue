<template>
  <v-dialog v-model="visible" width="80%" class="ma-auto" persistent>
    <template #activator="{ on, attrs }">
      <v-btn v-model="name" v-bind="attrs" v-on="on">
        Hello, {{ user }}!
      </v-btn>
    </template>

    <v-card class="dialog_content">
      <h2 class="dialog_title ml-3">Change Username</h2>
      <v-row>
        <v-text-field
          v-model="user"
          name="username"
          placeholder="Create a username"
          class="px-6 mt-4"
          outlined
          maxlength="14"
        ></v-text-field>
      </v-row>
      <v-container>
        <v-btn class="dontSavePlayAgain mx-6 purple" @click="load"
          >cancel</v-btn
        >
        <v-btn class="saveCreds mx-6 green" @click="save"
          >save username {{ user }}</v-btn
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

  mounted() {
    this.load()
  }

  save() {
    this.visible = false
    localStorage.setItem('user', this.user)
    this.$emit('loaded-name', this.user)
  }

  load() {
    this.visible = false
    const stored = localStorage.getItem('user')
    this.user = stored == null ? 'Guest' : stored
    this.$emit('loaded-name', this.user)
  }
}
</script>
