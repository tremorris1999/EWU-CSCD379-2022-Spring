<template>
  <div class>
    <v-container @click="toggleDialog">
      Settings <v-icon>mdi-cog</v-icon>
    </v-container>

    <v-dialog v-model="dialog" width="450">
      <v-card>
        <v-container>
          <v-card-title>Settings</v-card-title>

          <v-card-text>
            <v-menu offset-y>
              <template #activator="{ on, attrs }">
                <v-btn
                  color="primary"
                  class="mb-5"
                  dark
                  v-bind="attrs"
                  v-on="on"
                >
                  Pick Theme
                </v-btn>
              </template>
              <v-list>
                <v-list-item-group>
                  <v-list-item @click="turnOnTheLights">
                    <v-list-item-title> Light Mode </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="turnOffTheLights">
                    <v-list-item-title> Dark Mode </v-list-item-title>
                  </v-list-item>
                </v-list-item-group>
              </v-list>
            </v-menu>

            <v-menu offset-y>
              <template #activator="{ on, attrs }">
                <v-btn color="primary" dark v-bind="attrs" v-on="on">
                  Change Color Scheme
                </v-btn>
              </template>
              <v-list>
                <v-list-item-group>
                  <v-list-item @click="defaultTheme">
                    <v-list-item-title> Wild </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="cottonCandyTheme">
                    <v-list-item-title> Cotton Candy </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="lavenderTheme">
                    <v-list-item-title> Lavender </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="oceanTheme">
                    <v-list-item-title> Ocean Vacation </v-list-item-title>
                  </v-list-item>
                </v-list-item-group>
              </v-list>
            </v-menu>
          </v-card-text>
        </v-container>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { colors } from 'vuetify/lib'

@Component({})
export default class SettingsDialog extends Vue {
  dialog = false
  defaultDarkTheme = this.$vuetify.theme.themes.dark
  defaultLightTheme = this.$vuetify.theme.themes.light

  toggleDialog() {
    this.dialog = !this.dialog
  }

  turnOnTheLights() {
    this.$vuetify.theme.dark = false
  }

  turnOffTheLights() {
    this.$vuetify.theme.dark = true
  }

  cottonCandyTheme() {
    const cottonCandyTheme = {
      primary: colors.pink,
      accent: colors.purple.accent3,
      secondary: colors.blue.lighten4,
      info: '#D81B60',
      warning: colors.pink.accent1 ,
      error: colors.brown.lighten4,
      success: colors.blue.lighten2,
    }
    this.$vuetify.theme.themes.dark = cottonCandyTheme
    this.$vuetify.theme.themes.light = cottonCandyTheme
  }

  lavenderTheme() {
    const lavenderTheme = {
      primary: colors.purple.accent4,
      accent: colors.orange.accent3,
      secondary: colors.purple.darken2 ,
      info: '#7B1FA2',
      warning: colors.purple.accent4,
      error: colors.deepPurple.lighten4,
      success: colors.purple.accent2,
    }
    this.$vuetify.theme.themes.dark = lavenderTheme
    this.$vuetify.theme.themes.light = lavenderTheme
  }

  oceanTheme() { 
    const oceanTheme = {
      primary: colors.blue.darken1,
      accent: colors.brown.base,
      secondary: colors.cyan.lighten2,
      info: '#29B6F6',
      warning: colors.lightBlue.lighten1,
      error: colors.blueGrey.lighten1,
      success: colors.indigo.accent3,
    }
    this.$vuetify.theme.themes.dark = oceanTheme
    this.$vuetify.theme.themes.light = oceanTheme
  }

  defaultTheme() {
    // this.$vuetify.theme.themes.dark = this.defaultDarkTheme
    // this.$vuetify.theme.themes.light = this.defaultLightTheme
    const defaultTheme = {
      primary: colors.lightGreen.darken1,
      accent: colors.brown.base,
      secondary: colors.amber.darken2,
      info: '#F57F17',
      warning: colors.red.lighten1,
      error: colors.brown.lighten4,
      success: colors.teal.accent3,
    }
    this.$vuetify.theme.themes.dark = defaultTheme
    this.$vuetify.theme.themes.light = defaultTheme
    
  }
}
</script>

<style>
#app {
  background: url('https://ohlaladani.com.br/wp-content/uploads/wallpaper-OHLALADANI_DESKTOP_WALLPAPERS_AVENTURA-2.jpg')
    no-repeat center center fixed !important;
  background-size: cover;
}
</style>