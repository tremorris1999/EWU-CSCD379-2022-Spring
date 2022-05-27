<template>
  <v-container>
    <v-row justify="center">
      <v-col cols="8">
        <v-card color="transparent" flat>
          <v-card-title class="justify-center">
            <NotWordleLogo />
          </v-card-title>
          <v-card color="transparent" flat>
            <v-card-actions class="justify-center">
              <v-btn nuxt to="/game" color="primary" x-large width="200px">
                Play
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import {Component, Vue }from 'vue-property-decorator'

@Component
export default class IndexPage extends Vue {}
</script>

