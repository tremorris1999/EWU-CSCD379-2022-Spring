<template>
  <v-container>
    <v-row justify="center">
      <v-col cols="8">
        <v-card color="transparent" flat>
          <v-card-title class="justify-center">
            <NotWordleLogo />
          </v-card-title>
          <v-card color="transparent" flat>
            <v-card-title :class=this.class>
              !Wordle
            </v-card-title>
            <v-card-actions class="justify-center">
              <v-btn nuxt to="/game" color="primary" x-large width="300px">
                Play
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang='ts'>
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class IndexPage extends Vue {
  
  get class(): string{
    switch (this.$vuetify.breakpoint.name) {
        case 'xs': case 'sm': return "justify-center text-h3 font-weight-bold"
        default: return "justify-center text-h1 font-weight-bold"
    }
  }

}
</script>
