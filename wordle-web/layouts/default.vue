<template>
  <v-app dark>
    <v-app-bar :clipped-left="clipped" fixed app>
      <v-toolbar-title>
        <v-btn nuxt to="/">
          <v-icon x-large>mdi-file-word-box</v-icon>
          {{ title }}
        </v-btn>
      </v-toolbar-title>
      <v-spacer />
      <v-btn icon @click.stop="rightDrawer = !rightDrawer">
        <v-icon>mdi-menu</v-icon>
      </v-btn>
    </v-app-bar>
    <v-main>
      <Nuxt />
    </v-main>

    <v-navigation-drawer v-model="rightDrawer" :right="right" temporary fixed>
      <v-list>
        <v-list-item>
          <v-list-item-title class="d-flex justify-center">
            <v-icon x-large>mdi-file-word-box</v-icon>
          </v-list-item-title>
        </v-list-item>
        <v-list-item>
          <v-btn text block nuxt to="/"> Home <v-icon>mdi-home</v-icon></v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn text block nuxt to="/game">
            Play <v-icon>mdi-controller-classic</v-icon></v-btn
          >
        </v-list-item>

        <v-list-item>
          <v-btn text block nuxt to="/game_otd">
            Word of the Day <v-icon>mdi-calendar-outline</v-icon></v-btn
          >
        </v-list-item>

        <v-list-item v-if="$vuetify.breakpoint.mobile">
          <v-btn text block nuxt to="/aboutMobile">
            About <v-icon>mdi-help-circle</v-icon></v-btn
          >
        </v-list-item>

        <v-list-item v-else>
          <v-btn text block nuxt to="/about">
            About <v-icon>mdi-help-circle</v-icon></v-btn
          >
        </v-list-item>

        <v-list-item>
          <v-btn text block nuxt to="/leaderboard">
            Leaderboard <v-icon>mdi-star</v-icon></v-btn
          >
        </v-list-item>

        <v-list-item>
          <v-btn text block nuxt to="/instructions">
            Instructions <v-icon>mdi-cloud-question</v-icon></v-btn
          >
        </v-list-item>

        <v-list-item>
          <v-btn text block nuxt to="/stats">
            Stats <v-icon>mdi-beach</v-icon></v-btn
          >
        </v-list-item>

        
        <v-list-item>
          <v-btn text block nuxt to="/word-editor">
            Word Editor <v-icon>mdi-notebook-edit</v-icon></v-btn
          >
        </v-list-item>

        <v-list-item>
          <v-btn text block nuxt to="/log-in">
            Log In <v-icon>mdi-notebook-edit</v-icon></v-btn
          >
        </v-list-item>        

        <v-list-item>
          <v-btn text block>
            <SettingsDialog />
          </v-btn>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-footer app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

import Vue from 'vue' import Component from 'vue-class-component' @Component
export default class IndexPage extends Vue { get cols(): string{
switch(this.$vuetify.breakpoint.name){ case'xs':case'sm': return "12" default:
return "9" } } }

<script lang="ts">
export default {
  name: 'DefaultLayout',

  data() {
    return {
      clipped: false,
      right: true,
      rightDrawer: false,
      title: '!Wordle',
    }
  },
}
</script>

<!-- 
<v-tooltip bottom>
      <template #activator="{ on, attrs }">
        <v-btn color="info" nuxt to="/leaderboard" fab v-bind="attrs" v-on="on">
          <v-icon> mdi-equalizer </v-icon>
        </v-btn>
      </template>
      <span> Leader Board </span>
    </v-tooltip> -->
