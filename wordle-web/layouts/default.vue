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
          <v-btn text block nuxt to="/about">
            About <v-icon>mdi-help-circle</v-icon></v-btn
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

<script>
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
