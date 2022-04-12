<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <v-card class="logo py-4 d-flex justify-center" >
        <NuxtLogo />
        <VuetifyLogo />
      </v-card>
      <v-card>
        <v-card-title class="headline">
          Play Not-Wordle
        </v-card-title>
        <v-card-actions>
          <v-btn color="primary" nuxt to="/game"> PLAY </v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>