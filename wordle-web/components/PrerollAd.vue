<template>
  <v-card width="800" height="800">
    <v-container class="overflow-hidden" fluid>
      <v-row justify="center">
        <v-col>
          <!-- <Adsense
            data-ad-client="ca-pub-1431122584842002"
            data-ad-slot="9479195735"
          ></Adsense> -->
          <!-- That doesn't work without a top-level domain, anyway. Here's a fake ad instead -->
          <a href="https://youtu.be/dQw4w9WgXcQ" target="_blank">
            <v-img src="ad.gif" />
          </a>
        </v-col>
      </v-row>
    </v-container>
  </v-card>
</template>

<script>
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class PrerollAd extends Vue {}
</script>
