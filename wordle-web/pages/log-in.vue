<template>
  <v-app>
    <!-- <v-app-bar app dark color="blue">
      <v-toolbar-title>Vue Login</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn text rounded>Home</v-btn>
      <v-btn text rounded>Login</v-btn>
      <v-btn text rounded>About</v-btn>
      <v-btn text rounded>Contact us</v-btn>
    </v-app-bar> -->

    <v-content>
      <v-card width="500" class="mx-auto mt-9">
        <v-card-title>Log in or Sign up</v-card-title>
        <v-card-text>
          <v-text-field label="Username" prepend-icon="mdi-account-circle"/>
          <v-text-field 
          label="Password" 
          :type="showPassword ? 'text' : 'password'"
          prepend-icon="mdi-lock"
          :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
          @click:append="showPassword = !showPassword"/>
        </v-card-text>

        <v-divider></v-divider>
        <v-card-actions>
          <v-btn color="success">Register</v-btn>
          <v-btn color="warning">Login</v-btn>
        </v-card-actions>
      </v-card>
    </v-content>

    <template>
  <v-footer
    dark
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
<script>
export default {
  data()
  {
    return{
      showPassword:false
    }
  }
}
</script>