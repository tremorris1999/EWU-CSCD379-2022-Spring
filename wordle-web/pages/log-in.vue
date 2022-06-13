<template>
  <v-app>

    <v-content>
      <v-card width="500" class="mx-auto mt-9">
        <v-card-title>Log in or Sign up</v-card-title>
        <v-card-text>
          <v-text-field label="Username" v-model="user" prepend-icon="mdi-account-circle"/>
          <v-text-field 
          v-model="pass"
          label="Password" 
          :type="showPassword ? 'text' : 'password'"
          prepend-icon="mdi-lock"
          :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
          @click:append="showPassword = !showPassword"/>
        </v-card-text>

        <v-divider></v-divider>
        <v-card-actions>
          <v-btn color="success">Register</v-btn>
          <v-btn color="warning" @click="login(user, pass)">Login</v-btn>
        </v-card-actions>
      </v-card>
    </v-content>

    <template>
  <v-footer
    padless
  >
    <v-card
      class="flex"
      flat
      tile
    >
      <v-card-title class="teal">
       

        <v-spacer></v-spacer>

        <v-btn
          v-for="icon in icons"
          :key="icon"
          class="mx-4"
          dark
          icon
        >
          <v-icon size="24px">
            {{ icon }}
          </v-icon>
        </v-btn>
      </v-card-title>

      <v-card-text class="py-2 white--text text-center">
        {{ new Date().getFullYear() }} — <strong>Vuetify</strong>
      </v-card-text>
    </v-card>
  </v-footer>
</template>
  </v-app>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { JWT } from '~/scripts/jwt'

@Component
export default class LoginPage extends Vue {

  showPassword: boolean = false
  user: string = ""
  pass: string = ""

  login()
  {
    this.$axios
      .post('Token/GetToken', {
        username: this.user,
        password: this.pass,
      })
      .then((result) => {
        JWT.setToken(result.data.token, this.$axios)
        // console.log(result)
        console.log(JWT.tokenData)
        console.log(JWT.tokenData.roles)
        // this.$axios.defaults.headers.common.Authorization =
        //   'Bearer ' + result.data.token
        this.$axios.get('Token/TestAdmin').then((result) => {
          console.log(result)
        })
      })
  }
}
</script>