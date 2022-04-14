<template>
  <v-card>
      <v-container>
          <v-row>
            <v-col>

            </v-col>
          </v-row>
      </v-container>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { WordleGame } from '@/scripts/wordleGame';

@Component({ components: {} })
export default class Gameboard extends Vue {
    @Prop({ required: true })
    wordleGame!: WordleGame;
}
</script>
