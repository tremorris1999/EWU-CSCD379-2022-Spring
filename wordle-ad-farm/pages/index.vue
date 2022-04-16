<template>
  <v-container>
    <v-row justify="center">
      <v-col cols="8">
        <v-card>
          <v-card-title class="justify-center">
            <VuetifyLogo />
          </v-card-title>
            <v-card>
              <v-card-title class="justify-center text-h1 font-weight-bold">
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